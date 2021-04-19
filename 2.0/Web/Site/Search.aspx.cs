using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Pripev.DAL;

namespace Pripev.Web.UI
{
    public partial class Search : ExpiredWebPage
    {
        String _search;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var pg = PreviousPage == null ? Master : (TemplateControl)PreviousPage.Master;

            Master.Title = "Припевный поиск";
// ReSharper disable PossibleNullReferenceException
            _search = ((TextBox)pg.FindControl( "txtQSearch" )).Text.Replace( "%", "" );
// ReSharper restore PossibleNullReferenceException
            if ( _search.Length < 3 )
            {
                pValidation.Visible = true;
                plhSearch.Visible = false;
                return;
            }
            _search = _search.Replace( 'ё', 'е' ).Replace( 'Ё', 'Е' );

            SearchByArtist();
            SearchByAlbum();
            SearchBySong();
        }

        private void SearchByArtist()
        {
            var dt = DB.ExecuteDataTable( "exec SiteSearch @Type='A', @SearchBy=" + Utils.Convert.ToSQLString( _search ) );
            if ( dt.Rows.Count > 0 )
            {
                trArtistNotFound.Visible = false;
                rptArtists.Visible = true;
                rptArtists.DataSource = dt;
                rptArtists.DataBind();
            }
            else
            {
                trArtistNotFound.Visible = true;
                rptArtists.Visible = false;
            }
        }

        private void SearchByAlbum()
        {
            var dt = DB.ExecuteDataTable( "exec SiteSearch @Type='B', @SearchBy=" + Utils.Convert.ToSQLString( _search ) );
            if ( dt.Rows.Count > 0 )
            {
                trAlbumNotFound.Visible = false;
                rptAlbums.Visible = true;
                rptAlbums.DataSource = dt;
                rptAlbums.DataBind();
            }
            else
            {
                trAlbumNotFound.Visible = true;
                rptAlbums.Visible = false;
            }
        }

        private void SearchBySong()
        {
            var dt = DB.ExecuteDataTable( "exec SiteSearch @Type='S', @SearchBy=" + Utils.Convert.ToSQLString( _search ) );
            if ( dt.Rows.Count > 0 )
            {
                trSongNotFound.Visible = false;
                rptSongs.Visible = true;
                rptSongs.DataSource = dt;
                rptSongs.DataBind();
            }
            else
            {
                trSongNotFound.Visible = true;
                rptSongs.Visible = false;
            }
        }

        private String HighliteString( String name )
        {
            var arr = name.Split( new[] {_search}, StringSplitOptions.None );

            return (arr.Length > 1 ? String.Join( "<b>" + _search + "</b>", arr ) : null);
        }

        private String HighliteSearch( String name, String name1 )
        {
            var ret = HighliteString( name );
            if ( ret == null && !String.IsNullOrEmpty( name1 ) )
            {
                var arr = name1.Split( new[] {'|'} );
                foreach ( var s in arr )
                {
                    ret = HighliteString( s );
                    if ( ret != null ) return (ret);
                }
            }
            return (ret ?? name);
        }

        protected void rptArtists_ItemDataBound( Object Sender, RepeaterItemEventArgs e )
        {
            if ( e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem ) return;
            
            var dr = (DataRowView)e.Item.DataItem;
            var lnk = (HyperLink)e.Item.FindControl( "lnkArtist" );

            lnk.NavigateUrl = "/Artist.aspx?Id=" + dr["ARTIST_ID"];
            lnk.Text = HighliteSearch( dr["NAME"].ToString(), dr["NAME1"].ToString() );
        }

        protected void rptAlbums_ItemDataBound( Object Sender, RepeaterItemEventArgs e )
        {
            if ( e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem ) return;

            var dr = (DataRowView)e.Item.DataItem;
            var lnk = (HyperLink)e.Item.FindControl( "lnkAlbum" );
            var lnk1 = (HyperLink)e.Item.FindControl( "lnkArtist" );

            lnk.NavigateUrl = "/Album.aspx?Id=" + dr["AlbumId"];
            lnk.Text = HighliteSearch( dr["AlbumName"].ToString(), null );

            lnk1.NavigateUrl = "/Artist.aspx?Id=" + dr["ArtistId"];
            lnk1.Text = dr["ArtistName"].ToString();
        }

        protected void rptSongs_ItemDataBound( Object Sender, RepeaterItemEventArgs e )
        {
            if ( e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem ) return;

            var dr = (DataRowView)e.Item.DataItem;
            var lit = (Literal)e.Item.FindControl( "litSong" );
            var songName = HighliteSearch( dr["SongName"].ToString(), null );

            if ( Convert.ToInt32( dr["TextCount"] ) > 0 )
                lit.Text = "<a href='/Text.aspx?SongId=" + dr["SongId"] + "'>" + songName + "</a>";
            else
                lit.Text = songName;
        }
    }
}
