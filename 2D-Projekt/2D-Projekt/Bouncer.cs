using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Projekt
{
    class Bouncer
    {
        // Variablen
        Sprite enemySprite = new Sprite();
        Vector2f position;
        Vector2f ownDirection = new Vector2f(0.5f, 0.5f);
        public int life = 3;


        int shotspeed = 1;
        int range = 200;
        int speed = 5;


        // Ende der Funktion
        //================================================================================================
        //================================================================================================
        public Bouncer(int x , int y){

            Texture texture = new Texture("pictures/bouncer.png");
            enemySprite = new Sprite(texture);
            position = new Vector2f(x, y);
            enemySprite.Position = position;
            enemySprite.Scale = new Vector2f(0.5f, 0.5f);
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
            Vector2f merkPosition = new Vector2f(position.X + ownDirection.X * speed, position.Y + ownDirection.Y * speed);
            //float normSkalarDiff = (float)Math.Sqrt((position.X - ownDirection.X) * (position.X - ownDirection.X) + (position.Y - ownDirection.Y) * (position.Y - ownDirection.Y));
            
            if ((ownDirection.X == 0.5f) && (ownDirection.Y == 0.5f)){

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

        // Ende der Funktion
        //================================================================================================
        //================================================================================================
        public List<Projektile> shoot(List<Projektile> list , Vector2f t)
        {
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
