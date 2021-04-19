using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;

namespace Pripev.Web.UI.UserControls
{
    #region // Custom events

    public class FileBrowserCommandEventArgs
    {
        public String RelativePath { get; set; }

        public String AbsolutePath { get; set; }

        public String FileName { get; set; }

        public String Url { get; set; }
    }

    public delegate void FileBrowserCommandEventHandler( object sender, FileBrowserCommandEventArgs e );

    #endregion

    public enum AllowedFiles
    {
        SoundFiles,
        AllFilesNoSubDirs,
        AllFilesAndSubDirs,
        Everything
    }

    #region // FileBrowserFileInfo

    [Serializable]
    public class FileBrowserFileInfo
    {
        private readonly String _fileName;
        private readonly bool _folder;
        private readonly int _btnNum;

        public FileBrowserFileInfo( DirectoryInfo di, int btnNum )
        {
            _fileName = di.Name;
            _folder = true;
            _btnNum = btnNum;
        }

        public FileBrowserFileInfo(FileInfo fi, int btnNum)
        {
            _fileName = fi.Name;
            _folder = false;
            _btnNum = btnNum;
        }

        public override bool Equals( object obj )
        {
            return (FileName.CompareTo( ((FileBrowserFileInfo)obj).FileName ) == 0);
        }

        public override int GetHashCode()
        {
            return (FileName.GetHashCode());
        }

        public override string ToString()
        {
            return (FileName);
        }

        public String FileName
        {
            get { return (_fileName); }
        }

        public bool IsFolder
        {
            get { return (_folder); }
        }

        public String ButtonId
        {
            get { return ((IsFolder ? "fd" : "fl") + _btnNum); }
        }

        public String CssClass
        {
            get { return _folder ? "fld" : new FileInfo(FileName).Extension.Replace(".", ""); }
        }

        public LinkButton Button
        {
            get { return new LinkButton {Text = _fileName, ID = ButtonId, CssClass = CssClass}; }
        }
    }

    #endregion

    #region // FileBrowserFileList

    [Serializable]
    public class FileBrowserFileList : List<FileBrowserFileInfo>
    {
        [NonSerialized]
        private static readonly String[] _allowExt = new[] {".mp3", ".wma", ".ogg", ".waw"};

        public AllowedFiles FilesMode;

        public FileBrowserFileList( int capacity ) : base( capacity )
        {
            FilesMode = AllowedFiles.SoundFiles;
        }

        public new void Add( FileBrowserFileInfo fi )
        {
            if ( fi.IsFolder && !Contains( fi ) )
            {
                if (FilesMode != AllowedFiles.AllFilesAndSubDirs && FilesMode != AllowedFiles.Everything && fi.FileName.ToLower() == "images") return;
                base.Add( fi );
            }
            else
            {
// ReSharper disable PossibleNullReferenceException
                var ext = Path.GetExtension( fi.FileName ).ToLower();
// ReSharper restore PossibleNullReferenceException

                if (FilesMode == AllowedFiles.AllFilesNoSubDirs || FilesMode == AllowedFiles.AllFilesAndSubDirs || FilesMode == AllowedFiles.Everything || _allowExt.Any(s => s == ext && !Contains(fi)))
                    base.Add( fi );
            }
        }

        public new void Sort()
        {
            Sort( new FiComparer() );
        }

        private class FiComparer : IComparer<FileBrowserFileInfo>
        {
            public int Compare( FileBrowserFileInfo a, FileBrowserFileInfo b )
            {
                if ( a == null ) return (b == null ? 0 : -1);
                if ( b == null ) return (1);
                if ( a.IsFolder && !b.IsFolder ) return (-1);
                if ( !a.IsFolder && b.IsFolder ) return (1);
                return (a.FileName.CompareTo( b.FileName ));
            }
        }
    }

    #endregion

    public partial class FileBrowser : UserControl
    {
        private List<String> _rootFolders;
        private HtmlTableCell[] _aTc;
        private FileBrowserFileList _lstFiles;
        private const int MaxCol = 4;

        public event FileBrowserCommandEventHandler NodeChanged;
        public event FileBrowserCommandEventHandler FileSelected;

        public AllowedFiles FilesMode
        {
            get { return ViewState["FilesMode"] == null ? AllowedFiles.SoundFiles : (AllowedFiles)ViewState["FilesMode"]; }
            set { ViewState["FilesMode"] = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _rootFolders = Utils.Tools.GetAppSetting("FileBrowserRoots").Split(new[] { ';' }).ToList();
            //if ( FilesMode == AllowedFiles.Everything )
            //    _rootFolders = Utils.Tools.GetAppSetting("FileBrowserRootsHidden").Split(new[] { ';' }).ToList();
            _lstFiles = new FileBrowserFileList( 100 ) {FilesMode = FilesMode};

            if ( IsPostBack )
                RecreateControls();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            plhButtons.Controls.Clear();

            tdHdr.Attributes.Add("colspan", MaxCol.ToString());
            trFiles.Cells.Clear();
            _aTc = new HtmlTableCell[MaxCol];
            for ( var i = 0; i < MaxCol; i++ )
            {
                _aTc[i] = new HtmlTableCell();
                trFiles.Cells.Add( _aTc[i] );
            }

            Browse();
            litPath.Text = String.IsNullOrEmpty( CurrentPath ) ? "/" : CurrentPath;
            FillTable();
        }

        private void OnNodeChanged( FileBrowserCommandEventArgs e, bool bRoot )
        {
            if ( NodeChanged == null ) return;

            if ( !bRoot )
            {
                foreach ( var path in _rootFolders.Select( root => root + CurrentPath ).Where( Directory.Exists ) )
                {
                    e.AbsolutePath = path;
                    break;
                }
            }
            else
                e.RelativePath = "/";

            NodeChanged( this, e );
        }

        private void OnFileSelected( FileBrowserCommandEventArgs e )
        {
            if ( FileSelected == null ) return;

            e.RelativePath = CurrentPath + "/" + e.FileName;

            foreach ( var absolutePath in _rootFolders.Select( s => s + e.RelativePath ).Where( File.Exists ) ) {
                e.AbsolutePath = absolutePath;
                break;
            }
            FileSelected( this, e );
        }

        private FileBrowserFileList _FileList
        {
            get { return (Session["FBFileList"] == null ? null : (FileBrowserFileList)Session["FBFileList"]); }
            set { Session["FBFileList"] = value; }
        }

        public String CurrentPath
        {
            get { return (Session["FBCurrentPath"] == null ? String.Empty : Session["FBCurrentPath"].ToString()); }
            set { Session["FBCurrentPath"] = value; }
        }

        public String CurrentTrack
        {
            get { return (Session["FBCurrentTrack"] == null ? String.Empty : Session["FBCurrentTrack"].ToString()); }
            set { Session["FBCurrentTrack"] = value; }
        }

        private void Browse()
        {
            var btnNum = 1;

            foreach ( var rdi in from root in _rootFolders select root + CurrentPath into path where Directory.Exists( path ) select new DirectoryInfo( path ) )
            {
                foreach ( var di in rdi.GetDirectories() )
                    _lstFiles.Add( new FileBrowserFileInfo( di, btnNum++ ) );

                foreach ( var fi in rdi.GetFiles() )
                    _lstFiles.Add( new FileBrowserFileInfo( fi, btnNum++ ) );
            }
            _lstFiles.Sort();
        }

        private void FillTable()
        {
            var sb = new StringBuilder( 1000*1024 );
            int col = 0, row = 0;
            int maxRow;

            if ( _FileList != null )
            {
                _FileList.Clear();
                _FileList.AddRange( _lstFiles );
            }
            else
                _FileList = _lstFiles;

            if ( _FileList.Count <= 6 )
                maxRow = 10;
            else
            {
                maxRow = _FileList.Count/MaxCol;
                if ( _FileList.Count%MaxCol != 0 ) maxRow++;
            }


            foreach ( var fi in _FileList )
            {
                _aTc[col].Controls.Add( fi.Button );
                row++;
                if ( row < maxRow ) continue;

                col++;
                row = 0;
                sb.Length = 0;
            }
        }

        private void RecreateControls()
        {
            var btnEventHandler = new EventHandler( btnLnk_Click );

            if ( _FileList == null ) return;

            foreach ( var btn in _FileList.Select( fi => fi.Button ) )
            {
                btn.Click += btnEventHandler;
                plhButtons.Controls.Add( btn );
            }
        }

        protected void btnLnk_Click( Object sender, EventArgs e )
        {
            var btn = (LinkButton)sender;
            var fe = new FileBrowserCommandEventArgs();

            if ( btn.ID.StartsWith( "fd" ) )
            {
                CurrentPath += "/" + btn.Text;
                fe.RelativePath = CurrentPath;
                fe.FileName = btn.Text;
                OnNodeChanged( fe, false );
            }
            else
            {
                fe.FileName = btn.Text;
                OnFileSelected( fe );
            }
        }

        protected void lnkUp_Click( Object sender, EventArgs e )
        {
            var fe = new FileBrowserCommandEventArgs();
            var folders = CurrentPath.Split( new[] {'/'} );

            if ( folders.Length > 1 )
            {
                CurrentPath = String.Join( "/", folders, 0, folders.Length - 1 );
                fe.RelativePath = CurrentPath;
                fe.FileName = folders[folders.Length - 1];
                OnNodeChanged( fe, false );
            }
            else
            {
                CurrentPath = String.Empty;
                OnNodeChanged( fe, true );
            }
        }

        protected void lnkRoot_Click( Object sender, EventArgs e )
        {
            CurrentPath = String.Empty;
            OnNodeChanged( new FileBrowserCommandEventArgs(), true );
        }

    }
}
