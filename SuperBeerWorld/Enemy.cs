using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBeerWorld
{
    class Enemy
    {
        // xpos ypos type damage speed en afbeelding voor enemy
        int xpos, ypos, type, damage, speed;
        String afbeelding;
        // constructor
        public Enemy(int xpos, int ypos, int type, String afbeelding, int damage, int speed)
        {
            this.xpos = xpos;
            this.ypos = ypos;
            this.type = type;
            this.afbeelding = afbeelding;
            this.damage = damage;
            this.speed = speed;

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
        // setter voor afbeelding
        public void setAfbeelding(string afbeelding)
        {
            this.afbeelding = afbeelding;
        }
        // setter voor damage
        public void setDamage(int damage)
        {
            this.damage = damage;
        }
        // setter voor speed
        public void setSpeed(int speed)
        {
            this.speed = speed;
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
        // getter voor afbeelding
        public String getAfbeelding()
        {
            return afbeelding;
        }
        // getter voor damage
        public int getDamage()
        {
            return damage;
        }
        // getter voor speed
        public int getSpeed()
        {
            return speed;
        }
    }
}
