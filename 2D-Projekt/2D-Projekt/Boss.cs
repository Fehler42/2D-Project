using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Projekt
{
    class Boss
    {
          
        // Variablen
        Sprite enemySprite = new Sprite();
        Vector2f position;
        Vector2f ownDirection = new Vector2f(0.5f, 0.5f);
        public int life = 10;
        bool chargeCheck = false;


        int shotspeed = 5;
        int range = 400;
        int speed = 10;


        // Ende der Funktion
        //================================================================================================
        //================================================================================================
        public Boss(int x , int y){

            Texture texture = new Texture("pictures/boss.png");
            enemySprite = new Sprite(texture);
            position = new Vector2f(x, y);
            enemySprite.Position = position;
            enemySprite.Scale = new Vector2f(0.8f, 0.8f);
            }

        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        // draw
        public void draw(RenderWindow win)
        {
            win.Draw(enemySprite);
        }

        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        // Berechnet den direkten Weg zum Player ( Wände werden ignoriert)
        public void update(Vector2f destination , Map map)
        {
            chargeCheck = false;

            int xcharge = 1;

            Vector2f merkPosition = new Vector2f(position.X + ownDirection.X * speed, position.Y + ownDirection.Y * speed);
            float normSkalarDiff = (float)Math.Sqrt((position.X - ownDirection.X) * (position.X - ownDirection.X) + (position.Y - ownDirection.Y) * (position.Y - ownDirection.Y));

            if ((position.Y - 10 <= destination.Y) && (position.Y + 60 >= destination.Y))
            {
                xcharge = 5;
                chargeCheck = true;
            }

            position = new Vector2f(position.X + (destination.X - position.X) * xcharge *speed / normSkalarDiff, position.Y + (destination.Y - position.Y)*speed/ normSkalarDiff);
            enemySprite.Position = position;
        }

        // Ende der Funktion
        //================================================================================================
        //================================================================================================
        public List<Projektile> shoot(List<Projektile> list , Vector2f t)
        {
            if (chargeCheck == false)
            {
                list.Add(new Projektile(t, position, shotspeed, range));
            }
            return list;
        }
        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        // Getter Funktionen 
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

        // Ende der Getterfunktionen
        //================================================================================================
        //================================================================================================
    }
}
