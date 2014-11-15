using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Projekt
{
    class Charger
    {
        // Variablen
        Sprite enemySprite = new Sprite(new Texture("pictures/charger.png"));
        Vector2f position;
        public int life = 1;


        // Constructor
        public Charger()
        {

            position = new Vector2f(200, 400);
            enemySprite.Position = position;
            enemySprite.Scale = new Vector2f(0.5f, 0.5f);
        }

        // draw
        public void draw(RenderWindow win)
        {
            win.Draw(enemySprite);
        }
        // calculates next step to player (ignores walls) + charge
        public void update(Vector2f destination)
        {
            int xcharge = 1, ycharge = 1;
            float n = (float)Math.Sqrt((destination.X - position.X) * (destination.X - position.X) + (destination.Y - position.Y) * (destination.Y - position.Y));
                // if(same Y position)  charge
                if ((position.Y - 10 <= destination.Y) && (position.Y + 10 >= destination.Y))
                {
                    xcharge = 5;
                }
                // if(same Y position)  charge
                if ((position.X - 10 <= destination.X) && (position.X + 10 >= destination.X))
                {
                    ycharge = 5;
                }


                position = new Vector2f(position.X + (destination.X - position.X) * xcharge / n, position.Y + (destination.Y - position.Y) * ycharge / n);
               
                
            
          
            enemySprite.Position = position;

            }
        

       
        public FloatRect getEnemyRect()
        {
            return new FloatRect(position.X, position.Y, this.getWidth(), this.getHeight());
        }

        public float getHeight()
        {
            return enemySprite.Texture.Size.Y * enemySprite.Scale.Y;
        }

        public float getWidth()
        {
            return enemySprite.Texture.Size.X * enemySprite.Scale.X;
        }
    }
}