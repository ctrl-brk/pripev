using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pripev.Silverlight.Chat
{
   [ScriptableType]
   public partial class ChatPage : UserControl
	{
	   private ChatSession _chatSession;
      private String _userName;

      public ChatPage( string userName )
		{
			// Required to initialize variables
			InitializeComponent();
         _userName = userName;
         Loaded += ChatPage_Loaded;
		}

      void ChatPage_Loaded(object sender, RoutedEventArgs e)
      {
         _chatSession = new ChatSession();
         _chatSession.PropertyChanged += chatSession_PropertyChanged;
         //lbChat.DataContext = chatSession.MessageHistory;
         lbChat.ItemsSource = _chatSession.MessageHistory;
         InputTextBox.KeyUp += InputTextBox_KeyUp;
         SendButton.Click += SendButton_Click;
         HtmlPage.RegisterScriptableObject("ChatApp", this);
         if ( !String.IsNullOrEmpty( _userName ) )
            Connect( _userName );
      }

      [ScriptableMember]
      public void Connect( string userName )
      {
         if (HtmlPage.IsEnabled)
            _chatSession.Connect(userName, Dispatcher );
      }

      private void chatSession_PropertyChanged(object sender, PropertyChangedEventArgs e)
      {
         if ( e.PropertyName == "UserName" )
            UserName.Text = _chatSession.UserName;

         if ( e.PropertyName == "MessageHistory" && lbChat.Items.Count > 0 )
         {
            lbChat.SelectedIndex = lbChat.Items.Count - 1;
            lbChat.UpdateLayout();
            lbChat.ScrollIntoView(lbChat.Items[lbChat.Items.Count - 1]);
         }
      }

      void InputTextBox_KeyUp(object sender, KeyEventArgs e)
      {
         if ( e.Key == Key.Enter )
            SendButton_Click( sender, new RoutedEventArgs() );
      }

      void SendButton_Click( object sender, RoutedEventArgs e)
      {
         if ( _chatSession == null || String.IsNullOrEmpty(InputTextBox.Text.Trim()) )
            return;

         _chatSession.SendMessage( InputTextBox.Text );
         InputTextBox.Text = String.Empty;
      }
	}
}
