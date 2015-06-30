using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBeerWorld
{
    public class MainMenu
    {
        // Background
        Texture2D blank;
        Texture2D background;

        // Start buttons
        Texture2D startNormal;
        Texture2D startHover;
        Texture2D startClick;
        Texture2D startClicked;
        Texture2D facebook;
        Texture2D settings;

        // MouseState
        MouseState oldMouseState;

        int screenWidth;
        int screenHeight;

        public bool isPlayingMusic;

        public MainMenu(ContentManager content, int screenWidth, int screenHeight)
        {
            blank = content.Load<Texture2D>("blank");
            background = content.Load<Texture2D>("background-main");
            startNormal = content.Load<Texture2D>("start-normal");
            startHover = content.Load<Texture2D>("start-hover");
            startClick = content.Load<Texture2D>("start-click");
            startClicked = content.Load<Texture2D>("start-clicked");
            facebook = content.Load<Texture2D>("FacebookButton");
            settings = content.Load<Texture2D>("settings-button");

            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
           
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice device, MouseState mouseState)
        {
       
            int startPosX = 300;
            int startPosY = 500;
            int startWidth = 400;
            int startHeight = 144;

            
            int settingWidth = 100;
            int settingHeight= 100;
            int settingPosX = screenWidth - 20 - settingWidth;
            int settingPosY = 20;
            // Teken de sprites
            spriteBatch.Draw(background, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
            spriteBatch.Draw(settings, new Rectangle(settingPosX, settingPosY, settingWidth, settingHeight), Color.White);

            // start onclick and hover
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
                        Game1.CurrentScreen = Game1.Screens.Class1;
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

            // settings onclick
            if (mouseState.X >= settingPosX && mouseState.X <= settingPosX + settingWidth)
            {
                if (mouseState.Y >= settingPosY && mouseState.Y <= settingPosY + settingHeight)
                {
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                       
                    }
                    else
                    {
                       
                    }
                    if (oldMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released)
                    {
                        Game1.CurrentScreen = Game1.Screens.Settings;
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
        }
    }
}
