using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Facebook.Client.Controls;
using Microsoft.Xna.Framework.Media;

namespace SuperBeerWorld
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {

        LoginButton button;

        GraphicsDeviceManager graphics;
        GraphicsDevice device;
        SpriteBatch spriteBatch;

        Class1 class1;
        MainMenu mainmenu;
        Settings settings;

        private Song backgroundMusic1;
        private Song backgroundMusic2;

        // Vars
        int screenWidth;
        int screenHeight;

        public enum Screens
        {
            Class1,
            Settings,
            MainMenu,
          
        }

        public static Screens CurrentScreen { get; set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            CurrentScreen = Screens.MainMenu;
        }

        public void Login(LoginButton button)
        {
            this.button = button;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {

            backgroundMusic1 = Content.Load<Song>("background-music");
            backgroundMusic2 = Content.Load<Song>("GuusMeeuwis");
            
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            device = graphics.GraphicsDevice;

            // Bepaal de schermresolutie
            screenWidth = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;

            mainmenu = new MainMenu(Content,screenWidth,screenHeight);
            class1 = new Class1(Content);
            settings = new Settings(Content, screenWidth, screenHeight);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            switch (CurrentScreen)
            {
                case Screens.Class1:
                    class1.Update(gameTime);
                    button.Visibility = Visibility.Collapsed;
                    if (!class1.isPlayingMusic)
                    {
                       MediaPlayer.Play(backgroundMusic1);
                       class1.isPlayingMusic = true;
                    }
                    break;
                case Screens.MainMenu:
                    mainmenu.Update(gameTime);
                    button.Visibility = Visibility.Visible;
                    if (!mainmenu.isPlayingMusic)
                    {
                        MediaPlayer.Play(backgroundMusic2);
                        mainmenu.isPlayingMusic = true;
                    }
                    break;
                case Screens.Settings:
                    button.Visibility = Visibility.Collapsed;
                    break;
            }

            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            MouseState mouseState = Mouse.GetState();
            spriteBatch.Begin();
            switch (CurrentScreen)
            {
                case Screens.Class1:
                    class1.Draw(gameTime, spriteBatch, device);
                    break;
                case Screens.MainMenu:
                    mainmenu.Draw(spriteBatch, device, mouseState);
                    break;
                case Screens.Settings:
                    settings.Draw(spriteBatch, device, mouseState);
                    break;
            }
            spriteBatch.End();
         
            base.Draw(gameTime);
        }
    }
}
