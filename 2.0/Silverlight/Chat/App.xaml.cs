using System.Windows;
using System;
using System.Windows.Browser;
using System.Windows.Controls;

namespace Pripev.Silverlight.Chat
{
	public partial class App : Application 
	{
		Grid mainUI = new Grid();

      public App() 
		{
			this.Startup += this.OnStartup;
			this.Exit += this.OnExit;
			this.UnhandledException += Application_UnhandledException;

			//InitializeComponent();
		}

		private void OnStartup(object sender, StartupEventArgs e) 
		{
         // Load the main control here
         this.RootVisual = mainUI;
         var cp = new ChatPage( e.InitParams["UserName"] );
         mainUI.Children.Add( cp );
		}

		private void OnExit(object sender, EventArgs e) 
		{
		}

		private static void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e) 
		{
			// If the app is running outside of the debugger then report the exception using
			// the browser's exception mechanism. On IE this will display it a yellow alert 
			// icon in the status bar and Firefox will display a script error.
			if (!System.Diagnostics.Debugger.IsAttached)
			{
				// NOTE: This will allow the application to continue running after an exception has been thrown
				// but not handled. 
				// For production applications this error handling should be replaced with something that will 
				// report the error to the website and stop the application.
				e.Handled = true;
				Deployment.Current.Dispatcher.BeginInvoke( () => ReportErrorToDOM( e ) );
			}
		}

		private static void ReportErrorToDOM(ApplicationUnhandledExceptionEventArgs e)
		{
			try
			{
				var errorMsg = e.ExceptionObject.Message + @"\n" + e.ExceptionObject.StackTrace;
				errorMsg = errorMsg.Replace("\"", "\\\"").Replace("\r\n", @"\n");

				HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight 2 Application " + errorMsg + "\");");
			}
			catch {}
		}
	}
}