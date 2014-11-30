using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Projekt
{
    class PowerUp
    {
        Sprite upSprite;
        Vector2f position;

        // Legt die Art des PowerUps fest 
        public int kind = 0;
        //1-> Reichweite
        //2-> Leben
        //3-> Spielergeschwindigkeit
        //4-> Schusstempo (Buggy : da bei erhöhtem Tempo Kollision ausgelassen werden können TODO : Schwellenwert finden) 

        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        // Constructoe
        public PowerUp(int i)
        {
            kind = i;

            // Auswahl der Sprites dem PowerUp entsprechend
            if (i == 1)
            {
                upSprite = new Sprite(new Texture("pictures/rangeUp.png"));
            }
            if (i == 2)
            {
                upSprite = new Sprite(new Texture("pictures/Herz2.png"));
            }
            if (i == 3)
            {
                upSprite = new Sprite(new Texture("pictures/speedUp.png"));
            }
            if( i == 4)
            {
                upSprite = new Sprite(new Texture("pictures/Shotspeed.png"));
            }
            if (i == 5)
            {
                upSprite = new Sprite(new Texture("pictures/firerate.png"));
            }
            // Positon wird festgelegt aus diesem Grund müssen die Regeln bei der Maperstellung beachtet werden
            position = new Vector2f(375,275);
            upSprite.Position = position;
        }

        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        // Bearbeiten der Werte des Players 
        public void giveThePower(Player player)
        {
            if (kind == 1)
            {
                player.shotRange = player.shotRange + 50;
            }
            if (kind == 2 )
            {
                player.life++;
            }
            if (kind == 3)
            {
                player.speed =player.speed + 1;
            }
            if (kind == 4)
            {
                player.shotSpeed = player.shotSpeed + 2;
            }
            if (kind == 5)
            {
                player.fireRate = player.fireRate - 2;

                if (player.fireRate <= 1)
                {
                    player.fireRate = 2;
                }               
            }

        }

        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        // 0815 drawkrams und getter-Methoden
        public void draw(RenderWindow win)
        {
            win.Draw(upSprite);
        }
        public FloatRect getPowerUpRect()
        {
            return new FloatRect(position.X,position.Y,this.getWidth(),this.getHeight());
        }
        public float getHeight()
        {
            return upSprite.Texture.Size.Y * upSprite.Scale.Y;
        }

        public float getWidth()
        {
            return upSprite.Texture.Size.X * upSprite.Scale.X;
        }

        // Ende der Getterfunktionen
        //================================================================================================
        //================================================================================================
    }
}
