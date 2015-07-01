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
    class Settings
    {
        // Background
        Texture2D blank;
        Texture2D background;

        Texture2D musicOn;
        Texture2D musicOff;

        Texture2D backButton;

        // MouseState
        MouseState oldMouseState;

        
        bool music;

        int screenWidth;
        int screenHeight; 

        public Settings(ContentManager content, int screenWidth, int screenHeight, bool music)
        {
            this.music = music;
            blank = content.Load<Texture2D>("blank");
            background = content.Load<Texture2D>("background-main");

            musicOn = content.Load<Texture2D>("volume-on");
            musicOff = content.Load<Texture2D>("volume-off");

            backButton = content.Load<Texture2D>("go-back");
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
           
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice device, MouseState mouseState)
        {

            int musicPosX = 100;
            int musicPosY = 300;
            int musicWidth = 100;
            int musicHeight = 100;

            int backPosX = 100;
            int backPosY = 100;
            int backWidth = 100;
            int backHeight = 100;
             
            // Teken de sprites
            spriteBatch.Draw(background, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);

            if (mouseState.X >= musicPosX && mouseState.X <= musicPosX + musicWidth)
            {
                if (mouseState.Y >= musicPosY && mouseState.Y <= musicPosY + musicHeight)
                {
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        spriteBatch.Draw(musicOn, new Rectangle(musicPosX, musicPosY, musicWidth, musicHeight), Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(musicOff, new Rectangle(musicPosX, musicPosY, musicWidth, musicHeight), Color.White);
                    }
                    if (oldMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released)
                    {
                        if(music == true)
                        {
                            music = false;
                        }
                        else { music = true; }
                    }
                }
                else
                {
                    spriteBatch.Draw(musicOn, new Rectangle(musicPosX, musicPosY, musicWidth, musicHeight), Color.White);
                }
            }
            else
            {
                spriteBatch.Draw(musicOff, new Rectangle(musicPosX, musicPosY, musicWidth, musicHeight), Color.White);
            }

         
            // settings onclick
            if (mouseState.X >= backPosX && mouseState.X <= backPosX + backWidth)
            {
                if (mouseState.Y >= backPosY && mouseState.Y <= backPosY + backHeight)
                {
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        spriteBatch.Draw(backButton, new Rectangle(backPosX, backPosY, backWidth, backHeight), Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(backButton, new Rectangle(backPosX, backPosY, backWidth, backHeight), Color.White);
                    }
                    if (oldMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released)
                    {
                        Game1.CurrentScreen = Game1.Screens.MainMenu;
                    }
                }
                else
                {
                    spriteBatch.Draw(backButton, new Rectangle(backPosX, backPosY, backWidth, backHeight), Color.White);
                }
            }
            else
            {
                spriteBatch.Draw(backButton, new Rectangle(backPosX, backPosY, backWidth, backHeight), Color.White);
            }

            oldMouseState = mouseState;
        }




        public bool getMusic()
        {
            return music;
        }
    }
}
