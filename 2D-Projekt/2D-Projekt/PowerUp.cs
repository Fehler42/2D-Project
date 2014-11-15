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

        // defines the kind of power up detected
        public int kind = 0;
        //1-> RangeUp 
        //2-> HealthUp
        //3-> Speed
        //4-> Shot Speed
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
                upSprite = new Sprite(new Texture("pictures/heart.png"));
            }
            if (i == 3)
            {
                upSprite = new Sprite(new Texture("pictures/Speed.png"));
            }
            if( i == 4)
            {
                upSprite = new Sprite(new Texture("pictures/ShotSpeed.png"));
            }
            if (i == 5)
            {
                upSprite = new Sprite(new Texture("pictures/firerate.png"));
            }
            position = new Vector2f(200, 300);
            upSprite.Position = position;
        }
        // Bearbeiten der Werte des Players 
        public void giveThePower(Player player)
        {
            if (kind == 1)
            {
                player.shotRange = player.shotRange + 50;
            }
            if (kind == 2)
            {
                player.life++;
            }
            if (kind == 3)
            {
                player.speed =player.speed + 2;
            }
            if (kind == 4)
            {
                player.shotSpeed = player.shotSpeed + 2;
            }
            if (kind == 5)
            {
                player.fireRate = player.fireRate - 5;
            }

        }

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
    }
}
