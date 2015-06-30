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
    public class Settings
    {
        // Background
        Texture2D blank;
        Texture2D background;
        Texture2D musicOn;
        Texture2D musicOff;
        Game1 game;
       

        // MouseState
        MouseState oldMouseState;

        int screenWidth;
        int screenHeight; 

        public Settings(ContentManager content, int screenWidth, int screenHeight)
        {
            blank = content.Load<Texture2D>("blank");
            background = content.Load<Texture2D>("background-main");
            musicOn = content.Load<Texture2D>("volume-on");
            musicOff = content.Load<Texture2D>("volume-off");
            game = new Game1();
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
           
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice device, MouseState mouseState)
        {

            int musicPosX = 300;
            int musicPosY = 500;
            int musicWidth = 400;
            int musicHeight = 144;

            // Teken de sprites
            spriteBatch.Draw(background, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);

            //if (mouseState.X >= musicPosX && mouseState.X <= musicPosX + musicWidth)
            //{
            //    if (mouseState.Y >= musicPosY && mouseState.Y <= musicPosY + musicHeight)
            //    {
            //        if (mouseState.LeftButton == ButtonState.Pressed)
            //        {
            //            if (game.mainmenu.isPlayingMusic == true) { 
            //                spriteBatch.Draw(musicOn, new Rectangle(musicPosX, musicPosY, musicWidth, musicHeight), Color.White);
            //            }
            //            else
            //            {
            //                spriteBatch.Draw(musicOff, new Rectangle(musicPosX, musicPosY, musicWidth, musicHeight), Color.White);
            //            }
            //        }
            //        else
            //        {
            //            if (game.mainmenu.isPlayingMusic == true)
            //            {
            //                spriteBatch.Draw(musicOn, new Rectangle(musicPosX, musicPosY, musicWidth, musicHeight), Color.White);
            //            }
            //            else
            //            {
            //                spriteBatch.Draw(musicOff, new Rectangle(musicPosX, musicPosY, musicWidth, musicHeight), Color.White);
            //            }
            //        }
            //        if (oldMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released)
            //        {
            //            if(game.mainmenu.isPlayingMusic == true)
            //            {
            //                game.mainmenu.isPlayingMusic = false;
            //            }
            //            else
            //            {
            //                game.mainmenu.isPlayingMusic = true;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (game.mainmenu.isPlayingMusic == true)
            //        {
            //            spriteBatch.Draw(musicOn, new Rectangle(musicPosX, musicPosY, musicWidth, musicHeight), Color.White);
            //        }
            //        else
            //        {
            //            spriteBatch.Draw(musicOff, new Rectangle(musicPosX, musicPosY, musicWidth, musicHeight), Color.White);
            //        }
            //    }
            //}
            //else
            //{
            //    if (game.mainmenu.isPlayingMusic == true)
            //    {
            //        spriteBatch.Draw(musicOn, new Rectangle(musicPosX, musicPosY, musicWidth, musicHeight), Color.White);
            //    }
            //    else
            //    {
            //        spriteBatch.Draw(musicOff, new Rectangle(musicPosX, musicPosY, musicWidth, musicHeight), Color.White);
            //    }
            //}


            oldMouseState = mouseState;
        }
    }
}
