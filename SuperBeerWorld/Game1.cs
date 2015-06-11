using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SuperBeerWorld
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        GraphicsDevice device;
        SpriteBatch spriteBatch;
        MouseState mouseState;
        MouseState oldMouseState;

        // Background
        Texture2D blank;
        Texture2D background;

        // Start buttons
        Texture2D startNormal;
        Texture2D startHover;
        Texture2D startClick;
        Texture2D startClicked;
        Texture2D facebook;

        // Vars
        int screenWidth;
        int screenHeight;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            blank = Content.Load<Texture2D>("blank");
            background = Content.Load<Texture2D>("background-main");
            startNormal = Content.Load<Texture2D>("start-normal");
            startHover = Content.Load<Texture2D>("start-hover");
            startClick = Content.Load<Texture2D>("start-click");
            startClicked = Content.Load<Texture2D>("start-clicked");
            facebook = Content.Load<Texture2D>("FacebookButton");
            device = graphics.GraphicsDevice;
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            mouseState = Mouse.GetState();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // Start de spriteBatch
            spriteBatch.Begin();

            // Bepaal de schermresolutie
            screenWidth = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;

            int startPosX = 300;
            int startPosY = 500;
            int startWidth = 400;
            int startHeight = 144;

            // Teken de sprites
            spriteBatch.Draw(background, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);

            if (mouseState.X >= startPosX && mouseState.X <= startPosX + startWidth)
            {
                if (mouseState.Y >= startPosY && mouseState.Y <= startPosY + startHeight)
                {
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        spriteBatch.Draw(startClick, new Rectangle(startPosX, startPosY, startWidth, startHeight), Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(startHover, new Rectangle(startPosX, startPosY, startWidth, startHeight), Color.White);
                    }
                    if (oldMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released)
                    {
                        // Load other screen
                        goToPage(typeof(GamePage));
                    }
                }
                else
                {
                    spriteBatch.Draw(startNormal, new Rectangle(startPosX, startPosY, startWidth, startHeight), Color.White);
                }
            }
            else
            {
                spriteBatch.Draw(startNormal, new Rectangle(startPosX, startPosY, startWidth, startHeight), Color.White);
            }



            oldMouseState = mouseState;

            // End de spireBatch
            spriteBatch.End();

            base.Draw(gameTime);
        }

        // Methode voor het navigeren tussen de pagina's
        // Geruik als volgende: goToPage(typeof(NAAM_HIER_VAN_PAGINA));
        public void goToPage(System.Type pageName)
        {
            var frame = new Frame();
            frame.Navigate(pageName);
            Windows.UI.Xaml.Window.Current.Content = frame;
            Windows.UI.Xaml.Window.Current.Activate();
        }

        public void goToPage()
        {
            var frame = new Frame();
            frame.Navigate(typeof(Game1));
            Windows.UI.Xaml.Window.Current.Content = frame;
            Windows.UI.Xaml.Window.Current.Activate();
        }
    }
}
