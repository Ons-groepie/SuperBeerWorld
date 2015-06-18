﻿using Windows.UI.Xaml;
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
    public class Class1 : Game
    {

        GraphicsDeviceManager graphics;
        GraphicsDevice device;
        SpriteBatch spriteBatch;

        Texture2D BierVast;
        Texture2D BierAanDeMond;

        Texture2D geslaagd;

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
        bool isDrunk;
        Texture2D arrowDown, arrowUp, arrowLeft, arrowRight, frame;

        bool  isArrowUpPress, isArrowDownPress, isArrowLeftPress, isArrowRightPress;
        

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
            isDrunk = false;
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
            geslaagd = Content.Load<Texture2D>("geslaagd");

            arrowDown = Content.Load<Texture2D>("arrow-down");
            arrowUp = Content.Load<Texture2D>("arrow-up");
            arrowLeft = Content.Load<Texture2D>("arrow-left");
            arrowRight = Content.Load<Texture2D>("arrow-right");
            frame = Content.Load<Texture2D>("frame");


            _0 = Content.Load<Texture2D>("numbers1/_0");
            _1 = Content.Load<Texture2D>("numbers1/_1");
            _2 = Content.Load<Texture2D>("numbers1/_2");
            _3 = Content.Load<Texture2D>("numbers1/_3");
            _4 = Content.Load<Texture2D>("numbers1/_4");
            _5 = Content.Load<Texture2D>("numbers1/_5");
            _6 = Content.Load<Texture2D>("numbers1/_6");
            _7 = Content.Load<Texture2D>("numbers1/_7");
            _8 = Content.Load<Texture2D>("numbers1/_8");
            _9 = Content.Load<Texture2D>("numbers1/_9");
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

            if (timer > TimeSpan.Zero)
                timer -= gameTime.ElapsedGameTime;
            if (timer < TimeSpan.Zero && Ap >= 100)
            {
                timer = TimeSpan.Zero;
                isDrunk = true;
                
            }
            if (Ap >= 100)
            {
                isDrunk = true;
            
            }

            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);
            int procenten = 800 / 100 * Ap;
            int hoogtePlaatje = (805 - procenten) + 140;

            
            
            // Start de spriteBatch
            spriteBatch.Begin();

            // Bepaal de schermresolutie
            screenWidth = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;

            //Draw alles

            //(int)(screenWidth * 0.8f)

            spriteBatch.Draw(Background, new Rectangle(0, 0, (int)(screenWidth * 0.8f), screenHeight), Color.White);
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

            if (isDrunk == true)
            {
                spriteBatch.Draw(geslaagd, new Rectangle(538, 317, 844, 446), Color.White);
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
