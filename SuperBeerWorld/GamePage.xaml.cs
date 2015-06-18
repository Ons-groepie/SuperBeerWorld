using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MonoGame.Framework;
using Windows.ApplicationModel.Activation;
using Facebook.Client;
using System.IO;


namespace SuperBeerWorld
{
    /// <summary>
    /// The root page used to display the game.
    /// </summary>
    public sealed partial class GamePage : SwapChainBackgroundPanel
    {
        readonly Game1 _game;

        public GamePage(LaunchActivatedEventArgs args)
        {
            this.InitializeComponent();

            // Create the game.
            this.loginButton.Visibility = Visibility.Collapsed;
            _game = XamlGame<Game1>.Create(args, Window.Current.CoreWindow, this);
            _game.Login(loginButton);
        }

        private void OnSessionStateChanged(object sender, Facebook.Client.Controls.SessionStateChangedEventArgs e)
        {
            this.ContentPanel.Visibility = (e.SessionState == Facebook.Client.Controls.FacebookSessionState.Opened) ? Visibility.Visible : Visibility.Collapsed;
            
        }
    }
}
