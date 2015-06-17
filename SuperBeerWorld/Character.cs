using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBeerWorld
{
    class Character
    {
        String naam;
        String character;
        int AP;
        int levens;
        int statiegeld;

        // Default constructor
        public Character(String naam)
        {
            checkCharacter(this.naam);
            naam = character;
            AP = 0;
            statiegeld = 0;
            levens = 3;
        }

        // Constructor met extra parameters
        public Character(String naam, int statiegeld, int AP, int levens)
        {
            checkCharacter(this.naam);
            naam = character;
            AP = this.AP;
            statiegeld = this.statiegeld;
            levens = this.levens;
        }

        // Controleren of de ingegeven naam bestaat in onze game.
        // Zo niet, dan default character gebruiken.
        // De variabel naam wordt eerst omgezet naar lowercase.
        private void checkCharacter(String naam)
        {
            if (naam.ToLower() == "daniel" || naam.ToLower() == "jolt" || naam.ToLower() == "maaike" || naam.ToLower() == "falco" || naam.ToLower() == "martijn")
            {
                character = this.naam.ToLower();
            }
            else
            {
                // Set default character (Daniel)
                character = "daniel";
            }
        }

        // AP verhogen
        public void setAP(int AP)
        {
            AP = AP + this.AP;
        }

        // Levens instellen
        public void setLevens(int levens)
        {
            levens = this.levens;
        }

        // Statiegeld verhogen
        public void setStatiegeld(int statiegeld)
        {
            statiegeld = statiegeld + this.statiegeld;
        }

        // Return Alcohol Promilage
        public int getAP()
        {
            return AP;
        }

        // Return aantal levens
        public int getLevens()
        {
            return levens;
        }

        // Return statiegeld
        public int getStatiegeld()
        {
            return statiegeld;
        }

        // Return character
        public String getCharacter()
        {
            return character;
        }

        // Return naam
        public String getNaam()
        {
            return naam;
        }

    }
}
