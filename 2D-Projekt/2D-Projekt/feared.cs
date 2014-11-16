using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Projekt
{
    class Feared
    {
        Sprite sprite = new Sprite(new Texture("pictures/feared.png"));
        Vector2f position;
        private float speed = 3;
        public int life = 5;

        // Ende der Variablen
        //================================================================================================
        //================================================================================================

        public Feared(int x , int y)
        {
            position = new Vector2f(x, y);
            sprite.Position = position;
            sprite.Scale = new Vector2f(0.5f, 0.5f);
        }

        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        public void draw(RenderWindow win)
        {
            win.Draw(sprite);
        }

        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        public void update(Vector2f Spielerposition, Map map)
        {
            // Differenzvektor und Skalar erstellen, Ursprungsposition merken 
            Vector2f diffSpielerGegner = new Vector2f(position.X - Spielerposition.X, position.Y - Spielerposition.Y);
            float normSkalarDiff = (float)Math.Sqrt((position.X - Spielerposition.X) * (position.X - Spielerposition.X) + (position.Y - Spielerposition.Y) * (position.Y - Spielerposition.Y));
            Vector2f merkPosition = position;
            // legt den Abstand des Gegners fest 
            if (normSkalarDiff <= 200)
            {
                position = new Vector2f(position.X + (position.X - Spielerposition.X) * speed / normSkalarDiff, position.Y + (position.Y - Spielerposition.Y) * speed / normSkalarDiff);
                if (!map.isWalkable((int)position.X / 50, (int)position.Y / 50) || !map.isWalkable((int)(position.X +this.getWidth())/50 ,(int)(position.Y +this.getHeight())/50))
                {
                    position = merkPosition;
                }
            }
            else
            {
                position = new Vector2f(position.X - (position.X - Spielerposition.X) * speed / normSkalarDiff, position.Y - (position.Y - Spielerposition.Y) * speed / normSkalarDiff);

                if (!map.isWalkable((int)position.X / 50, (int)position.Y / 50) || !map.isWalkable((int)(position.X + this.getWidth()) / 50, (int)(position.Y + this.getHeight()) / 50))
                {
                    position = merkPosition;
                }
            }
            // Sprietupdate
            sprite.Position = position;
        }

        // Ende der Funktion
        //================================================================================================
        //================================================================================================
        public List<Projektile> shoot(List<Projektile> list, Vector2f t)
        {
            return list;
        }
        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        // Getterfunktionen
        public FloatRect getEnemyRect()
        {
            return new FloatRect(position.X, position.Y, this.getWidth(), this.getHeight());
        }

        public float getHeight()
        {
            return sprite.Texture.Size.Y * sprite.Scale.Y;
        }

        public float getWidth()
        {
            return sprite.Texture.Size.X * sprite.Scale.X;
        }
        public Vector2f getPosition()
        {
            return position;
        }


        // Ende der Getterfunktionen
        //================================================================================================
        //================================================================================================
    }
}
