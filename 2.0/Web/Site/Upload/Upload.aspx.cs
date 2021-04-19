using System;
using System.Linq;
using System.Text;
using System.IO;
using darrenjohnstone.net.FileUpload;

namespace Pripev.Web.UI.Popup
{
    public partial class Upload : PopupPage
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if ( !IsPostBack )
            {
                lnkFTP.Text = lnkFTP.NavigateUrl = Utils.Registry.GetString( "FTPUploadURL" );
                txtArtist.Text = Request["Artist"];
                txtAlbum.Text = Request["Album"];
                txtSong.Text = Request["Song"];
                txtEmail.Text = Master.CurrentUser.Email;
            }

            if ( !IsPostBack || UploadController1.Status == null ) return;

            var sb = new StringBuilder( "Спасибо за участие!!!<br><br>Загруженные файлы:<br><ul>" );

            foreach ( var f in UploadController1.Status.UploadedFiles )
            {
                sb.Append( "<li>" );
                sb.Append( f.FileName );
                /*
                    if( f.Identifier != null )
                    {
                       sb.Append( " ID = " );
                       sb.Append( f.Identifier.ToString() );
                    }
                    */
                sb.Append( "</li>" );
                try
                {
                    SaveFileInfo( MoveFile( f ) );
                }
                catch {}
            }

            sb.Append( "</ul>" );

            if ( UploadController1.Status.ErrorFiles.Count > 0 )
            {
                sb.Append( "<br><h3>Ошибка загрузки файлов:<br><ul>" );

                foreach ( var f in UploadController1.Status.ErrorFiles )
                {
                    sb.Append( "<li>" );
                    sb.Append( f.FileName );
                    /*
                        if( f.Identifier != null )
                        {
                           sb.Append( " ID = " );
                           sb.Append( f.Identifier.ToString() );
                        }
                        */
                    if ( f.Exception != null )
                    {
                        sb.Append( "<br><em>" );
                        sb.Append( f.Exception.Message );
                        sb.Append( "</em>" );
                    }

                    sb.Append( "</li>" );
                }
                sb.Append( "</ul>" );
            }
            litResults.Text = sb.ToString();
            plhText.Visible = false;
        }

        private String MoveFile( UploadedFile f )
        {
            var uploadPath = Utils.Tools.GetAppSetting( "UploadPath" ).Contains( ':' ) ? Utils.Tools.GetAppSetting( "UploadPath" ) : Server.MapPath( Utils.Tools.GetAppSetting( "UploadPath" ) );
            var newPath = new StringBuilder( uploadPath );

            newPath.Append( String.IsNullOrEmpty( txtArtist.Text ) ? "/UnknownArtist." + Utils.Tools.GUID : "/" + Utils.Tools.EnsureFileName( txtArtist.Text ) );
            if ( !Directory.Exists( newPath.ToString() ) ) Directory.CreateDirectory( newPath.ToString() );

            newPath.Append( String.IsNullOrEmpty( txtAlbum.Text ) ? "/UnknownAlbum" : "/" + Utils.Tools.EnsureFileName( txtAlbum.Text ) );
            if ( !Directory.Exists( newPath.ToString() ) ) Directory.CreateDirectory( newPath.ToString() );

            newPath.Append( "/" );
            newPath.Append( f.LocalFileName );

            var ret = newPath.ToString();
            File.Move( f.LocalFullFileName, ret );
            return (ret);
        }

        private void SaveFileInfo( String path )
        {
            var fu = new BLL.FileUpload( txtArtist.Text, txtAlbum.Text, txtSong.Text, path, txtEmail.Text, txtComment.Text );
            fu.Save();
        }
    }
}
