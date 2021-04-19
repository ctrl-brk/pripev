using System;
using System.Collections.Generic;
using System.Configuration;
using Pripev.Utils.Web;
using Pripev.BLL;
using darrenjohnstone.net.FileUpload;

namespace Pripev.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start( object sender, EventArgs e )
        {
            Application["nOnlineUsers"] = 0;
            Application["nSessions"] = 0;
            Application["OnlineUsers"] = new List<WebUserSession>( 500 );

            //Uncomment one of the following lines to select a processor

            //UploadManager.Instance.BufferSize = 1024;
            UploadManager.Instance.ProcessorType = typeof ( FileSystemProcessor );
            //UploadManager.Instance.ProcessorType = typeof(SQLProcessor);
            UploadManager.Instance.ProcessorInit += Processor_Init;
        }

        protected void Session_Start( object sender, EventArgs e )
        {
            Application.Lock();
            Application["nSessions"] = Convert.ToInt32( Application["nSessions"] ) + 1;
            Application.UnLock();
        }

        protected void Application_BeginRequest( object sender, EventArgs e ) {}

        protected void Application_AuthenticateRequest( object sender, EventArgs e ) {}

        protected void Application_Error( object sender, EventArgs e )
        {
            var objErr = Server.GetLastError().GetBaseException();

            if ( objErr.Message.StartsWith( "Path" ) && objErr.Message.Contains( ".asp" ) && !objErr.Message.Contains( ".aspx" ) && objErr.Message.EndsWith( "forbidden." ) )
            {
                Response.Redirect( Request.RawUrl.Replace( ".asp", ".aspx" ), true );
                return;
            }

            if ( !Convert.ToBoolean( ConfigurationManager.AppSettings["EnableSMTP"] ) ) return;

            try
            {
                var usr = WebUser.CreateUser();
                var body = Email.CreateErrorEmailBody( objErr, usr.Id );
                Utils.Email.ErrorMail( "Error 500", body );
            }

            catch ( System.Exception ex )
            {
                var err = "Error Caught in Application_Error event\n" + "Error in Application_Error event handler: " + Request.Url + "\nError Message:" + ex;

                System.Diagnostics.EventLog.WriteEntry( "Application", err, System.Diagnostics.EventLogEntryType.Error );

                Utils.Email.ErrorMail( "Pripev.ru error handler error", err, false );
            }
        }

        protected void Session_End( object sender, EventArgs e )
        {
            Application.Lock();
            Application["nSessions"] = Convert.ToInt32( Application["nSessions"] ) - 1;
            Application.UnLock();
        }

        protected void Application_End( object sender, EventArgs e ) {}

        void Processor_Init( object sender, FileProcessorInitEventArgs args )
        {
            if ( args.Processor is FileSystemProcessor )
            {
                var processor = args.Processor as FileSystemProcessor;

                // Set up the download path here - default to the root of the web application
                //processor.OutputPath = "/Upload/Files";
                processor.OutputPath = ConfigurationManager.AppSettings["UploadPath"];
            }
            /*else if ( args.Processor is SQLProcessor )
            {
                var processor = args.Processor as SQLProcessor;

                // Set up the connection string
                processor.ConnectionString = "server=(local);initial catalog=FileUpload;integrated security=true";
            }*/
        }
    }
}
