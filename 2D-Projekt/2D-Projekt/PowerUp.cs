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
        public PowerUp(int i)
        {
            kind = i;

            if (i == 1)
            {
                upSprite = new Sprite(new Texture("pictures/rangeUp.png"));
            }
            if (i == 2)
            {
                upSprite = new Sprite(new Texture("pictures/heart.png"));

            }

            position = new Vector2f(200, 300);
            upSprite.Position = position;
        }
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

        }
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
