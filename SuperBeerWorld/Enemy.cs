using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBeerWorld
{
    class Enemy
    {
        int xpos, ypos, type, damage, speed;
        String afbeelding;

        public Enemy(int xpos, int ypos, int type, String afbeelding, int damage, int speed)
        {
            this.xpos = xpos;
            this.ypos = ypos;
            this.type = type;
            this.afbeelding = afbeelding;
            this.damage = damage;
            this.speed = speed;

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

        public void setAfbeelding(string afbeelding)
        {
            this.afbeelding = afbeelding;
        }

        public void setDamage(int damage)
        {
            this.damage = damage;
        }

        public void setSpeed(int speed)
        {
            this.speed = speed;
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

        public String getAfbeelding()
        {
            return afbeelding;
        }

        public int getDamage()
        {
            return damage;
        }

        public int getSpeed()
        {
            return speed;
        }
    }
}
