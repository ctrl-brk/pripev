using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.IO;
using System.ServiceModel.Syndication;
using System.Data;

namespace Pripev.Web
{
   public abstract class SyndicationHandler : IHttpHandler
   {
      private System.Web.HttpContext _context;
      private SyndicationFeed _feed;
      private DateTime _modifiedSince;

      public virtual void ProcessRequest( System.Web.HttpContext context )
      {
         _context = context;
         if( ValidateRequest() )
         {
            _feed = LoadFeed();
            WriteFeed( _feed );
         }
      }

      public virtual bool ValidateRequest()
      {
         _modifiedSince = DateTime.Now.AddDays( -7 );

         if ( !Convert.ToBoolean( Utils.Tools.GetAppSetting( "ExpirePages" ) ) ) return ( true );

         DateTime lastModified = Convert.ToDateTime( DAL.DB.ExecuteScalar( "exec GetLastModifiedDates" ) );
         
         if ( !String.IsNullOrEmpty( Context.Request.ServerVariables["HTTP_IF_MODIFIED_SINCE"] ) )
         {
            try { _modifiedSince = Convert.ToDateTime( Context.Request.ServerVariables["HTTP_IF_MODIFIED_SINCE"] ); }
            catch { }
         }

         if( _modifiedSince <= lastModified || Context.Request.ServerVariables["HTTP_IF_NONE_MATCH"] == lastModified.ToFileTimeUtc().ToString() )
         {
            if ( RespondNotModified() ) return ( false );
         }

         Context.Response.AddHeader( "Last-Modified", lastModified.ToUniversalTime().ToString( "r" ) );
         Context.Response.AddHeader( "Etag", lastModified.ToFileTimeUtc().ToString() );

         return ( true );
      
      }

      public virtual bool RespondNotModified()
      {
         Context.Response.StatusCode = 304;
         Context.Response.StatusDescription = "Not Modified";
         Context.Response.Flush();
         Context.Response.End();
         return ( true );
      }

      public virtual SyndicationFeed LoadFeed()
      {
         SyndicationFeed feed = new SyndicationFeed( "Припевы!", "Припевы! Комплектуются куплетами и аккордами.", new Uri( Utils.Registry.GetString( "ServerURL" ) ), null, DateTime.Now );

         XmlQualifiedName xqName = new XmlQualifiedName( "encoding" );
         feed.AttributeExtensions.Add( xqName, "windows-1251" );

         feed.Language = "ru";
         feed.Copyright = new TextSyndicationContent( "Copyright (c) 1999-" + DateTime.Now.Year.ToString() + " Aleksey Grachev", TextSyndicationContentKind.Plaintext );

         SyndicationPerson sp = new SyndicationPerson( "webmaster@pripev.ru", "Aleksey Grachev", "http://Aleksey/Grachev" );
         feed.Authors.Add( sp );

         XmlDocument doc = new XmlDocument();
         XmlElement feedElement1 = doc.CreateElement( "webMaster" );
         feedElement1.InnerText = "webmaster@pripev.ru";
         feed.ElementExtensions.Add( feedElement1 );
         XmlElement feedElement2 = doc.CreateElement( "ttl" );
         feedElement2.InnerText = "1440";
         feed.ElementExtensions.Add( feedElement2 );

         SyndicationCategory category = new SyndicationCategory( "Music" );
         feed.Categories.Add( category );

         feed.ImageUrl = new Uri( Pripev.Utils.Registry.GetString( "ServerURL" ) + "/Images/Banners/PripevRSS.gif" );

         List<SyndicationItem> items = new List<SyndicationItem>();

         DataTable dt = DAL.DB.ExecuteDataTable( "exec GetFeed @FeedType='Artists',@StartDate=" + Utils.Convert.ToSQLString( _modifiedSince ) );
         foreach ( DataRow dr in dt.Rows )
         {
            SyndicationItem item = new SyndicationItem( "Исполнитель: " + dr["NAME"].ToString(),
               "Новый исполнитель: " + dr["NAME"].ToString(),
               new Uri( Utils.Registry.GetString( "ServerURL" ) + "/Artist.aspx?Id=" + dr["ARTIST_ID"].ToString() ) );
            items.Add( item );
         }

         dt = DAL.DB.ExecuteDataTable( "exec GetFeed @FeedType='Albums',@StartDate=" + Utils.Convert.ToSQLString( _modifiedSince ) );
         foreach ( DataRow dr in dt.Rows )
         {
            SyndicationItem item = new SyndicationItem( "Альбом: " + dr["AlbumName"].ToString(),
               "Новый альбом: " + dr["AlbumName"].ToString() + "<br>" + "Исполнитель: " + dr["ArtistName"].ToString(),
               new Uri( Utils.Registry.GetString( "ServerURL" ) + "/Album.aspx?Id=" + dr["ALBUM_ID"].ToString() ) );
            items.Add( item );
         }

         dt = DAL.DB.ExecuteDataTable( "exec GetFeed @FeedType='Texts',@StartDate=" + Utils.Convert.ToSQLString( _modifiedSince ) );
         foreach ( DataRow dr in dt.Rows )
         {
            SyndicationItem item = new SyndicationItem( "Текст: " + dr["SongName"].ToString(),
               "Добавлена композиция: " + dr["SongName"].ToString() + "<br>" +
               "Табы/Аккорды: " + ( dr["Chords"].ToString() == "Y" ? "Есть" : "Нет" ) + "<br>" +
               "Исполнитель: " + dr["ArtistName"].ToString() + "<br>" +
               "Альбом: " + dr["AlbumName"].ToString(),
               new Uri( Utils.Registry.GetString( "ServerURL" ) + "/Text.aspx?Id=" + dr["TextId"].ToString() + "&SongId=" + dr["SongId"].ToString() ) );
            items.Add( item );
         }

         dt = DAL.DB.ExecuteDataTable( "exec GetFeed @FeedType='Sounds',@StartDate=" + Utils.Convert.ToSQLString( _modifiedSince ) );
         foreach ( DataRow dr in dt.Rows )
         {
            SyndicationItem item = new SyndicationItem( "Звук: " + dr["SongName"].ToString(),
               "Добавлена композиция: " + dr["SongName"].ToString() + "<br>" +
               "Тип файла: " + dr["SoundType"].ToString() + "<br>" +
               "Исполнитель: " + dr["ArtistName"].ToString() + "<br>" +
               "Альбом: " + dr["AlbumName"].ToString(),
               new Uri( Utils.Registry.GetString( "ServerURL" ) + "/Album.aspx?Id=" + dr["AlbumId"].ToString() ) );
            items.Add( item );
         }

         feed.Items = items;

         return ( feed );
      }

      public abstract void WriteFeed( SyndicationFeed feed );

      public virtual SyndicationFeed Feed
      {
         get { return ( _feed ); }
      }

      public virtual System.Web.HttpContext Context
      {
         get { return ( _context ); }
      }

      public virtual bool IsReusable
      {
         get { return ( true ); }
      }

   }
}
