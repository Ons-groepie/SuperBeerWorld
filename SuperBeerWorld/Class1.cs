using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SuperBeerWorld
{
    class Class1 : Game
    {

        GraphicsDeviceManager graphics;
        GraphicsDevice device;
        SpriteBatch spriteBatch;

        Texture2D BierVast;
        Texture2D BierAanDeMond;

        Texture2D ApBar;
        Texture2D Bier;

        Texture2D Background;
        KeyboardState oldState;

        bool isSpaceDown;

        int Ap; 
        TimeSpan timer = new TimeSpan(0, 0, 10); //10 second
        // Vars
        int screenWidth;
        int screenHeight;

        public Class1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            isSpaceDown = false;
            Ap = 0;
            oldState = Keyboard.GetState();
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
            Bier = Content.Load<Texture2D>("Bier");
        }

        protected override void UnloadContent() 
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
           // TODO: Add your update logic here
            
            var newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.Space) && !oldState.IsKeyDown(Keys.Space))
            {
                isSpaceDown = true;
                Ap++;               
            }
            else if (newState.IsKeyUp(Keys.Space))
            {
                isSpaceDown = false;
            }
            oldState = newState;

            if (timer > TimeSpan.Zero)
                timer -= gameTime.ElapsedGameTime;

            if (timer < TimeSpan.Zero && Ap >= 100)
            {
                timer = TimeSpan.Zero;
                
            } 
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);
            int procenten = 800 / 100 * Ap;
            int hoogtePlaatje = (800 - procenten) + 140;


            
            // Start de spriteBatch
            spriteBatch.Begin();

            // Bepaal de schermresolutie
            screenWidth = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;

            //Draw alles
            spriteBatch.Draw(Background, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
            spriteBatch.Draw(ApBar, new Rectangle(50, 120, 320, 840), Color.White);
            spriteBatch.Draw(Bier, new Rectangle(197,hoogtePlaatje,145,procenten), Color.White);
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
