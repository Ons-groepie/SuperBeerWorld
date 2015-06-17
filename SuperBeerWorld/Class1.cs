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

        //numbers
        Texture2D _0;
        Texture2D _1;
        Texture2D _2;
        Texture2D _3;
        Texture2D _4;
        Texture2D _5;
        Texture2D _6;
        Texture2D _7;
        Texture2D _8;
        Texture2D _9;

        Texture2D Background;
        KeyboardState oldState;

        bool isSpaceDown;

        int Ap;
        int tijd;
        TimeSpan timer = new TimeSpan(0, 0, 30); //10 second
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

            _0 = Content.Load<Texture2D>("numbers/_0");
            _1 = Content.Load<Texture2D>("numbers/_1");
            _2 = Content.Load<Texture2D>("numbers/_2");
            _3 = Content.Load<Texture2D>("numbers/_3");
            _4 = Content.Load<Texture2D>("numbers/_4");
            _5 = Content.Load<Texture2D>("numbers/_5");
            _6 = Content.Load<Texture2D>("numbers/_6");
            _7 = Content.Load<Texture2D>("numbers/_7");
            _8 = Content.Load<Texture2D>("numbers/_8");
            _9 = Content.Load<Texture2D>("numbers/_9");
        }

        protected override void UnloadContent() 
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
           // TODO: Add your update logic here

            tijd = (int)timer.TotalSeconds;
            var newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.Space) && !oldState.IsKeyDown(Keys.Space))
            {
                isSpaceDown = true;
                if(Ap <= 100)
                {
                    Ap++;  
                }
                              
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

            switch (tijd)
            {
                case 1:
                    spriteBatch.Draw(_0, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_1, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 2:
                    spriteBatch.Draw(_0, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_2, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 3: 
                    spriteBatch.Draw(_0, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_3, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 4:
                    spriteBatch.Draw(_0, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_4, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 5:
                    spriteBatch.Draw(_0, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_5, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 6:
                    spriteBatch.Draw(_0, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_6, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 7:
                    spriteBatch.Draw(_0, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_7, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 8:
                    spriteBatch.Draw(_0, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_8, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 9:
                    spriteBatch.Draw(_0, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_9, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 10:
                    spriteBatch.Draw(_1, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_0, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 11:
                    spriteBatch.Draw(_1, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_1, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 12:
                    spriteBatch.Draw(_1, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_2, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 13:
                    spriteBatch.Draw(_1, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_3, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 14:
                    spriteBatch.Draw(_1, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_4, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 15:
                    spriteBatch.Draw(_1, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_5, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 16:
                    spriteBatch.Draw(_1, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_6, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 17:
                    spriteBatch.Draw(_1, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_7, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 18:
                    spriteBatch.Draw(_1, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_8, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 19:
                    spriteBatch.Draw(_1, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_9, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 20:
                    spriteBatch.Draw(_2, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_0, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 21:
                    spriteBatch.Draw(_2, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_1, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 22:
                    spriteBatch.Draw(_2, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_2, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 23:
                    spriteBatch.Draw(_2, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_3, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 24:
                    spriteBatch.Draw(_2, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_4, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 25:
                    spriteBatch.Draw(_2, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_5, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 26:
                    spriteBatch.Draw(_2, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_6, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 27:
                    spriteBatch.Draw(_2, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_7, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 28:
                    spriteBatch.Draw(_2, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_8, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 29:
                    spriteBatch.Draw(_2, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_9, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                case 30:
                    spriteBatch.Draw(_3, new Rectangle(1750, 50, 100, 100), Color.White);
                    spriteBatch.Draw(_0, new Rectangle(1800, 50, 100, 100), Color.White);
                    break;
                default:
                    break;
            }
           
            // End de spireBatch
            spriteBatch.End();

            base.Draw(gameTime);
         }

    }
}
