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
        int speed = 5;


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

            Vector2f merkPosition = new Vector2f(position.X, position.Y);
            float normSkalarDiff = (float)Math.Sqrt((position.X - ownDirection.X) * (position.X - ownDirection.X) + (position.Y - ownDirection.Y) * (position.Y - ownDirection.Y));

            if ((position.Y - 10 <= destination.Y) && (position.Y + 60 >= destination.Y))
            {
                xcharge = 5;
                chargeCheck = true;
            }

            position = new Vector2f(position.X + (destination.X - position.X) * xcharge *speed / normSkalarDiff, position.Y + (destination.Y - position.Y)*speed/ normSkalarDiff);

            bool up = map.isWalkable((int)position.X / 50, (int)position.Y / 50);
            bool down =  map.isWalkable((int)position.X / 50, (int)(position.Y + 42) / 50);
            bool right = map.isWalkable((int)(position.X +42) / 50, (int)position.Y / 50);
            if (up && down && right )
            {
                enemySprite.Position = position;
            }
            else
            {
                merkPosition = new Vector2f(position.X + ownDirection.X * speed, position.Y + ownDirection.Y * speed);
                //float normSkalarDiff = (float)Math.Sqrt((position.X - ownDirection.X) * (position.X - ownDirection.X) + (position.Y - ownDirection.Y) * (position.Y - ownDirection.Y));

                if ((ownDirection.X == 0.5f) && (ownDirection.Y == 0.5f))
                {

                    if (!map.isWalkable((int)merkPosition.X / 50, (int)merkPosition.Y / 50) || !map.isWalkable((int)(merkPosition.X + this.getWidth()) / 50, (int)(merkPosition.Y + this.getHeight()) / 50))
                    {
                        ownDirection = new Vector2f(0.5f, -0.5f);
                        merkPosition = new Vector2f(position.X + ownDirection.X * speed, position.Y + ownDirection.Y * speed);
                    }
                    if (!map.isWalkable((int)merkPosition.X / 50, (int)merkPosition.Y / 50) || !map.isWalkable((int)(merkPosition.X + this.getWidth()) / 50, (int)(merkPosition.Y + this.getHeight()) / 50))
                    {
                        ownDirection = new Vector2f(-0.5f, +0.5f);
                        merkPosition = new Vector2f(position.X + ownDirection.X * speed, position.Y + ownDirection.Y * speed);
                    }
                    if (!map.isWalkable((int)merkPosition.X / 50, (int)merkPosition.Y / 50) || !map.isWalkable((int)(merkPosition.X + this.getWidth()) / 50, (int)(merkPosition.Y + this.getHeight()) / 50))
                    {
                        ownDirection = new Vector2f(-0.5f, -0.5f);
                        merkPosition = new Vector2f(position.X + ownDirection.X * speed, position.Y + ownDirection.Y * speed);
                    }

                }
                if ((ownDirection.X == -0.5f) && (ownDirection.Y == 0.5f))
                {

                    if (!map.isWalkable((int)merkPosition.X / 50, (int)merkPosition.Y / 50) || !map.isWalkable((int)(merkPosition.X + this.getWidth()) / 50, (int)(merkPosition.Y + this.getHeight()) / 50))
                    {
                        ownDirection = new Vector2f(+0.5f, +0.5f);
                        merkPosition = new Vector2f(position.X + ownDirection.X * speed, position.Y + ownDirection.Y * speed);
                    }
                    if (!map.isWalkable((int)merkPosition.X / 50, (int)merkPosition.Y / 50) || !map.isWalkable((int)(merkPosition.X + this.getWidth()) / 50, (int)(merkPosition.Y + this.getHeight()) / 50))
                    {
                        ownDirection = new Vector2f(-0.5f, -0.5f);
                        merkPosition = new Vector2f(position.X + ownDirection.X * speed, position.Y + ownDirection.Y * speed);
                    }
                    if (!map.isWalkable((int)merkPosition.X / 50, (int)merkPosition.Y / 50) || !map.isWalkable((int)(merkPosition.X + this.getWidth()) / 50, (int)(merkPosition.Y + this.getHeight()) / 50))
                    {
                        ownDirection = new Vector2f(+0.5f, -0.5f);
                        merkPosition = new Vector2f(position.X + ownDirection.X * speed, position.Y + ownDirection.Y * speed);
                    }

                }
                if ((ownDirection.X == -0.5f) && (ownDirection.Y == -0.5f))
                {

                    if (!map.isWalkable((int)merkPosition.X / 50, (int)merkPosition.Y / 50) || !map.isWalkable((int)(merkPosition.X + this.getWidth()) / 50, (int)(merkPosition.Y + this.getHeight()) / 50))
                    {
                        ownDirection = new Vector2f(0.5f, -0.5f);
                        merkPosition = new Vector2f(position.X + ownDirection.X * speed, position.Y + ownDirection.Y * speed);
                    }
                    if (!map.isWalkable((int)merkPosition.X / 50, (int)merkPosition.Y / 50) || !map.isWalkable((int)(merkPosition.X + this.getWidth()) / 50, (int)(merkPosition.Y + this.getHeight()) / 50))
                    {
                        ownDirection = new Vector2f(-0.5f, +0.5f);
                        merkPosition = new Vector2f(position.X + ownDirection.X * speed, position.Y + ownDirection.Y * speed);
                    }
                    if (!map.isWalkable((int)merkPosition.X / 50, (int)merkPosition.Y / 50) || !map.isWalkable((int)(merkPosition.X + this.getWidth()) / 50, (int)(merkPosition.Y + this.getHeight()) / 50))
                    {
                        ownDirection = new Vector2f(+0.5f, +0.5f);
                        merkPosition = new Vector2f(position.X + ownDirection.X * speed, position.Y + ownDirection.Y * speed);
                    }

                }
                if ((ownDirection.X == 0.5f) && (ownDirection.Y == -0.5f))
                {

                    if (!map.isWalkable((int)merkPosition.X / 50, (int)merkPosition.Y / 50) || !map.isWalkable((int)(merkPosition.X + this.getWidth()) / 50, (int)(merkPosition.Y + this.getHeight()) / 50))
                    {
                        ownDirection = new Vector2f(-0.5f, -0.5f);
                        merkPosition = new Vector2f(position.X + ownDirection.X * speed, position.Y + ownDirection.Y * speed);
                    }
                    if (!map.isWalkable((int)merkPosition.X / 50, (int)merkPosition.Y / 50) || !map.isWalkable((int)(merkPosition.X + this.getWidth()) / 50, (int)(merkPosition.Y + this.getHeight()) / 50))
                    {
                        ownDirection = new Vector2f(0.5f, 0.5f);
                        merkPosition = new Vector2f(position.X + ownDirection.X * speed, position.Y + ownDirection.Y * speed);
                    }
                    if (!map.isWalkable((int)merkPosition.X / 50, (int)merkPosition.Y / 50) || !map.isWalkable((int)(merkPosition.X + this.getWidth()) / 50, (int)(merkPosition.Y + this.getHeight()) / 50))
                    {
                        ownDirection = new Vector2f(-0.5f, 0.5f);
                        merkPosition = new Vector2f(position.X + ownDirection.X * speed, position.Y + ownDirection.Y * speed);
                    }

                }
                position = merkPosition;
                enemySprite.Position = merkPosition;
            }



        }

        // Ende der Funktion
        //================================================================================================
        //================================================================================================
        public List<Projektile> shoot(List<Projektile> list , Vector2f t)
        {
            if (chargeCheck == false)
            {
                list.Add(new Projektile(t, new Vector2f ( position.X +15 , position.Y+15 ), shotspeed, range));
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
