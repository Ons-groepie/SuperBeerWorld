using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Microsoft.Xna.Framework.Content;

namespace SuperBeerWorld
{
    public class Class1
    {
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


        int procenten;
        int hoogtePlaatje;
        float BierBarHoogte;
        float opvulling;

        public Class1(ContentManager content)
        {
            //graphics = new GraphicsDeviceManager(this);
            //Content.RootDirectory = "Content";
            isSpaceDown = false;
            isDrunk = false;
            Ap = 0;
            oldState = Keyboard.GetState();

            BierVast = content.Load<Texture2D>("Daniel-met-bier-2");
            BierAanDeMond = content.Load<Texture2D>("Daniel-met-bier");
            Background = content.Load<Texture2D>("background-kroeg");
            ApBar = content.Load<Texture2D>("AP-bar");
            Bier = content.Load<Texture2D>("Bier");

            geslaagd = content.Load<Texture2D>("geslaagd");

            arrowDown = content.Load<Texture2D>("arrow-down");
            arrowUp = content.Load<Texture2D>("arrow-up");
            arrowLeft = content.Load<Texture2D>("arrow-left");
            arrowRight = content.Load<Texture2D>("arrow-right");
            frame = content.Load<Texture2D>("frame");


            _0 = content.Load<Texture2D>("numbers1/_0");
            _1 = content.Load<Texture2D>("numbers1/_1");
            _2 = content.Load<Texture2D>("numbers1/_2");
            _3 = content.Load<Texture2D>("numbers1/_3");
            _4 = content.Load<Texture2D>("numbers1/_4");
            _5 = content.Load<Texture2D>("numbers1/_5");
            _6 = content.Load<Texture2D>("numbers1/_6");
            _7 = content.Load<Texture2D>("numbers1/_7");
            _8 = content.Load<Texture2D>("numbers1/_8");
            _9 = content.Load<Texture2D>("numbers1/_9");
        }

        public void Update(GameTime gameTime)
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

            procenten = 800 / 100 * Ap;
            hoogtePlaatje = (805 - procenten) + 140;
            BierBarHoogte = hoogtePlaatje / 1920f;
            opvulling = procenten / 1920f;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch,GraphicsDevice device)
        {


            // Bepaal de schermresolutie
            screenWidth = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;

            //Draw alles

            //(int)(screenWidth * 0.8f)

            spriteBatch.Draw(Background, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
            spriteBatch.Draw(ApBar, new Rectangle((int)(screenWidth * 0.026f), (int)(screenHeight * 0.111f), (int)(screenWidth * 0.167f), (int)(screenHeight * 0.777f)), Color.White);
            spriteBatch.Draw(Bier, new Rectangle((int)(screenWidth * 0.102f), (int)(screenHeight * BierBarHoogte), (int)(screenWidth * 0.075f), (int)(screenHeight * opvulling)), Color.White);
            if (isSpaceDown == false)
            {
                spriteBatch.Draw(BierVast, new Rectangle((int)(screenWidth * 0.546f), (int)(screenHeight * 0.470f), (int)(screenWidth * 0.260f), (int)(screenHeight * 0.462f)), Color.White);
            }
            else if (isSpaceDown == true)
            {
                spriteBatch.Draw(BierAanDeMond, new Rectangle((int)(screenWidth * 0.546f), (int)(screenHeight * 0.470f), (int)(screenWidth * 0.260f), (int)(screenHeight * 0.462f)), Color.White);
            }

            if (isDrunk == true)
            {
                spriteBatch.Draw(geslaagd, new Rectangle((int)(screenWidth * 0.280f), (int)(screenHeight * 0.293f), (int)(screenWidth * 0.439f), (int)(screenHeight * 0.412f)), Color.White);
            }
           
            switch (tijd)
            {
                case 1:
                    spriteBatch.Draw(_0, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_1, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 2:
                    spriteBatch.Draw(_0, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_2, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 3:
                    spriteBatch.Draw(_0, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_3, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 4:
                    spriteBatch.Draw(_0, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_4, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 5:
                    spriteBatch.Draw(_0, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_5, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 6:
                    spriteBatch.Draw(_0, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_6, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 7:
                    spriteBatch.Draw(_0, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_7, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 8:
                    spriteBatch.Draw(_0, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_8, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 9:
                    spriteBatch.Draw(_0, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_9, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 10:
                    spriteBatch.Draw(_1, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_0, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 11:
                    spriteBatch.Draw(_1, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_1, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 12:
                    spriteBatch.Draw(_1, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_2, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 13:
                    spriteBatch.Draw(_1, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_3, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 14:
                    spriteBatch.Draw(_1, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_4, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 15:
                    spriteBatch.Draw(_1, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_5, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 16:
                    spriteBatch.Draw(_1, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_6, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 17:
                    spriteBatch.Draw(_1, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_7, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 18:
                    spriteBatch.Draw(_1, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_8, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 19:
                    spriteBatch.Draw(_1, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_9, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 20:
                    spriteBatch.Draw(_2, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_0, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 21:
                    spriteBatch.Draw(_2, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_1, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 22:
                    spriteBatch.Draw(_2, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_2, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 23:
                    spriteBatch.Draw(_2, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_3, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 24:
                    spriteBatch.Draw(_2, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_4, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 25:
                    spriteBatch.Draw(_2, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_5, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 26:
                    spriteBatch.Draw(_2, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_6, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 27:
                    spriteBatch.Draw(_2, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_7, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 28:
                    spriteBatch.Draw(_2, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_8, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 29:
                    spriteBatch.Draw(_2, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_9, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                case 30:
                    spriteBatch.Draw(_3, new Rectangle((int)(screenWidth * 0.911f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    spriteBatch.Draw(_0, new Rectangle((int)(screenWidth * 0.937f), (int)(screenHeight * 0.046f), (int)(screenWidth * 0.052f), (int)(screenHeight * 0.092f)), Color.White);
                    break;
                default:
                    break;
            }
         }
    }
}
