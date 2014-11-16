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

        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        // Constructor
        public Charger(int x , int y)
        {

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

        // Berechnet den direkten Weg zum Player und initialisiert den Charge ( Wände werden ignoriert)
        public void update(Vector2f destination , Map map)
        {
            int xcharge = 1, ycharge = 1;
            //Skalar das den Vektor auf die Länge 1 kürzen kann
            float n = (float)Math.Sqrt((destination.X - position.X) * (destination.X - position.X) + (destination.Y - position.Y) * (destination.Y - position.Y));

                // löst den Charge bei ähnlichen Y Koordinaten aus
                if ((position.Y - 10 <= destination.Y) && (position.Y + 10 >= destination.Y))
                {
                    xcharge = 5;
                }
                // löst den Charge bei ähnlichen x Koordinaten aus 
                if ((position.X - 10 <= destination.X) && (position.X + 10 >= destination.X))
                {
                    ycharge = 5;
                }
          // Versetzt den Sprite 
          position = new Vector2f(position.X + (destination.X - position.X) * xcharge / n, position.Y + (destination.Y - position.Y) * ycharge / n);
          //  Spritepositionsupdate 
          enemySprite.Position = position;

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

        // GetterFunktionen

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

        // Ende der Getterfunktion
        //================================================================================================
        //================================================================================================
    }
}