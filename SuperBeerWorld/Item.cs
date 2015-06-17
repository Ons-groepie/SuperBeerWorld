using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBeerWorld
{
    class Item
    {
        int width, height, type, xpos, ypos;
        bool pickup;

        public Item(int  type,int  xpos,int ypos )
        {
            this.xpos = xpos;
            this.ypos = ypos;
            this.type = type;
        }

        public void setWidth(int width)
        {
            this.width = width;
        }

        public void setHeight(int height)
        {
            this.height = height;
        }

        public void setXpos(int xpos)
        {
            this.xpos = xpos;
        }

        public void setYpos(int ypos)
        {
            this.ypos = ypos;
        }

        public void setType(int type)
        {
            this.type = type;
        }

        public void setPickup(bool pickup)
        {
            this.pickup = pickup;
        }

        public int getWidth()
        {
            return width;
        }

        public int getHeight()
        {
            return height;
        }

        public int getXpos()
        {
            return xpos;
        }

        public int getYpos()
        {
            return ypos;
        }

        public int getType()
        {
            return type;
        }

        public bool getPickup()
        {
            return pickup;
        }
    }
}
