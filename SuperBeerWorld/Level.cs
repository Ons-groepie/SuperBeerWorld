using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBeerWorld
{
    public class Level
    { 
        private Character character;
        private Enemy enemy;
        private Item item;
        private int level;
        private String background;
        private int width;
        private int height;

        public Level(int level)
        {
            this.level = level;
        }

        public void setLevel(int level)
        {
            this.level = level;
        }

        public void setBackground(String background)
        {
            this.background = background;
        }

        public void setWidth(int width)
        {
            this.width = width;
        }

        public void setHeight(int height)
        {
            this.height = height;
        }

        public int getLevel()
        {
            return level;
        }

        public String getBackground()
        {
            return background;
        }

        public int getWidth()
        {
            return width;
        }

        public int getHeight()
        {
            return height;
        }

    }
}