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
    class Class1
    {
        Texture2D BierVast;
        Texture2D BierAanDeMond;

        Texture2D geslaagd;

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

        public Class1(ContentManager content)
        {
            //graphics = new GraphicsDeviceManager(this);
            //Content.RootDirectory = "Content";
            isSpaceDown = false;
            Ap = 0;
            oldState = Keyboard.GetState();

            BierVast = content.Load<Texture2D>("Daniel-met-bier-2");
            BierAanDeMond = content.Load<Texture2D>("Daniel-met-bier");
            Background = content.Load<Texture2D>("background-kroeg");
            ApBar = content.Load<Texture2D>("AP-bar");
            Bier = content.Load<Texture2D>("Bier");
        }

        public void Update(GameTime gameTime)
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
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch,GraphicsDevice device)
        {
            int procenten = 800 / 100 * Ap;
            int hoogtePlaatje = (800 - procenten) + 140;

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
         }
    }
}
