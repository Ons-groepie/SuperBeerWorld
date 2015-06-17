using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBeerWorld
{ 
    class Item
    {
        // width height type xpos and ypos van een item
        int width, height, type, xpos, ypos;
        // is mogelijk om het item op te pakken
        bool pickup;

        // constructor met een type, xpos en ypos
        public Item(int  type,int  xpos,int ypos )
        {
            this.xpos = xpos;
            this.ypos = ypos;
            this.type = type;
        }

        // setter voor width
        public void setWidth(int width)
        {
            this.width = width;
        }
        // setter voor height
        public void setHeight(int height)
        {
            this.height = height;
        }
        // setter voor xpos
        public void setXpos(int xpos)
        {
            this.xpos = xpos;
        }
        // setter voor ypos
        public void setYpos(int ypos)
        {
            this.ypos = ypos;
        }
        // setter voor type
        public void setType(int type)
        {
            this.type = type;
        }
        // setter voor pickup
        public void setPickup(bool pickup)
        {
            this.pickup = pickup;
        }
        // getter voor width
        public int getWidth()
        {
            return width;
        }
        // getter voor height
        public int getHeight()
        {
            return height;
        }
        // getter voor xpos
        public int getXpos()
        {
            return xpos;
        }
        // getter voor ypos
        public int getYpos()
        {
            return ypos;
        }
        // getter voor type
        public int getType()
        {
            return type;
        }
        // getter voor pickup
        public bool getPickup()
        {
            return pickup;
        }
    }
}
