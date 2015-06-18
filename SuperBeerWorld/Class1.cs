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
    public class Class1 : Game
    {
        GraphicsDeviceManager graphics;
        GraphicsDevice device;
        SpriteBatch spriteBatch;

        Texture2D BierVast;
        Texture2D BierAanDeMond;

        Texture2D ApBar;

        Texture2D Background;

        Texture2D arrowDown, arrowUp, arrowLeft, arrowRight, frame;

        bool isSpaceDown, isArrowUpPress, isArrowDownPress, isArrowLeftPress, isArrowRightPress;
        

        // Vars
        int screenWidth;
        int screenHeight;

        public Class1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            isSpaceDown = false;
            
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            device = graphics.GraphicsDevice;
            BierVast=Content.Load<Texture2D>("Daniel-met-bier-2");
            BierAanDeMond = Content.Load<Texture2D>("Daniel-met-bier");
            Background = Content.Load<Texture2D>("background-kroeg");
            ApBar = Content.Load<Texture2D>("AP-bar");
            arrowDown = Content.Load<Texture2D>("arrow-down");
            arrowUp = Content.Load<Texture2D>("arrow-up");
            arrowLeft = Content.Load<Texture2D>("arrow-left");
            arrowRight = Content.Load<Texture2D>("arrow-right");
            frame = Content.Load<Texture2D>("frame");
        }

        protected override void UnloadContent() 
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
           // TODO: Add your update logic here
            KeyboardState keyboard = Keyboard.GetState();
            // spacebar pressed / not 
            if (keyboard.IsKeyDown(Keys.Space)) {isSpaceDown = true;}
            else { isSpaceDown = false;}
            // arrow up pressed / not
            if (keyboard.IsKeyDown(Keys.Up)) { isArrowUpPress = true; }
            else { isArrowUpPress = false; }
            // arrow down pressed / not
            if (keyboard.IsKeyDown(Keys.Down)) { isArrowDownPress = true; }
            else { isArrowDownPress = false; }
            // arrow left pressed / not
            if (keyboard.IsKeyDown(Keys.Left)) { isArrowLeftPress = true; }
            else { isArrowLeftPress = false; }
            // arrow right pressed / not
            if (keyboard.IsKeyDown(Keys.Right)) { isArrowRightPress = true; }
            else { isArrowRightPress = false; }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);

            // Start de spriteBatch
            spriteBatch.Begin();

            // Bepaal de schermresolutie
            screenWidth = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;

            //Draw alles
            spriteBatch.Draw(Background, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
            spriteBatch.Draw(ApBar, new Rectangle(50, 120, 320, 840), Color.White);
            if (isSpaceDown == false)
            {
                spriteBatch.Draw(BierVast, new Rectangle(1050, 508, 500, 500), Color.White);
            }
            else if (isSpaceDown == true)
            {
                spriteBatch.Draw(BierAanDeMond, new Rectangle(1050, 508, 500, 500), Color.White);
            }
           
            // End de spireBatch
            spriteBatch.End();

            base.Draw(gameTime);
         }

    }
}
