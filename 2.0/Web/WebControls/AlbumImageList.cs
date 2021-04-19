using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pripev.Web.UI.WebControls
{
   public class AlbumImageList : DropDownList
   {
      private int? _artistId = null;
      private int? _albumId = null;
      private String _artistLinkFormat;

      public int? ArtistId
      {
         get { return ( _artistId ); }
         set { _artistId = value; }
      }

      public int? AlbumId
      {
         get { return ( _albumId ); }
         set { _albumId = value; }
      }

      public String ArtistLinkFormat
      {
         get { return ( _artistLinkFormat ); }
         set { _artistLinkFormat = value; }
      }

      protected override void Render( HtmlTextWriter output )
      {
         if( _artistId == null || _albumId == null ) return;

         BLL.Artist artist = new Pripev.BLL.Artist( _artistId );
         BLL.Album album = new Pripev.BLL.Album( _albumId );

         output.Write( "<div class='image'><h1>" );
         if( album.CD ) output.Write( "<div class='CD'>" );
         output.Write( "<a href='" + _artistLinkFormat + _artistId.ToString() + "'>" + artist.Name + "</a>" );
         if( !String.IsNullOrEmpty( album.BuyURL ) ) output.Write( "<a class='Buy' href='" + album.BuyURL + "' title='Купить' target='_blank'>&nbsp;</a>" );
         if( album.CD ) output.Write( "</div>" );
         output.Write( "</h1>" );

         base.Attributes.Add( "onChange", "OnAlbumChange(this)" );
         base.Render( output );

         if ( !String.IsNullOrEmpty( album.LargeImage ) )
            output.Write( "<img src='" + album.LargeImage + "' border='0'>" );
         else if ( album.Year != String.Empty )
            output.Write( "<br>А здесь могла бы быть картинка обложки :(<br>" +
                          "Но не нашел. Так что место вакантно.<br>" +
                          "Если у вас есть таковая - просьба<br><a href='javascript:ShareInfo()'>прислать мне</a>" );
         else
            output.Write( "<br>Понятия не имею из каких альбомов эти песни<br>" +
                          "Если Вы знаете - просьба <a href='javascript:ShareInfo()'>сообщить мне</a>.<br>&nbsp;" );

         output.Write( "</div>" );
      }
   }
}
