using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pripev.BLL
{
   public class FileUpload
   {
      private int? _id;
      private String _artist, _album, _song, _path, _email, _comments;

      public FileUpload() { }

      public FileUpload( String artist, String album, String song, String path, String email, String comments )
      {
         _artist = artist; _album = album; _song = song; _path = path; _email = email; _comments = comments;
      }

      public void Save()
      {
         String sql = "exec PutUpload @Artist=" + Utils.Convert.ToSQLString( _artist ) +
                                    ",@Album=" + Utils.Convert.ToSQLString( _album ) +
                                    ",@Song=" + Utils.Convert.ToSQLString( _song ) +
                                    ",@Email=" + Utils.Convert.ToSQLString( _email ) +
                                    ",@Comment=" + Utils.Convert.ToSQLString( _comments ) +
                                    ",@Path=" + Utils.Convert.ToSQLString( _path );

         _id = System.Convert.ToInt32( DAL.DB.ExecuteScalar( sql ) );
      }

      public int? Id
      {
         get { return ( _id ); }
      }
   }
}
