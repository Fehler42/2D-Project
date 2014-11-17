using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Projekt
{
    class Turret
    {
           // Variablen
        Sprite enemySprite = new Sprite();
        Vector2f position;
        public int life = 3;
        int shotspeed = 1;
        int range = 200;
 


        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        // Constructor
        public Turret(int x , int y)
        {
            Texture playerTexture = new Texture("pictures/turret.png");
            enemySprite = new Sprite(playerTexture);
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
            enemySprite.Position = position;
        }

        // Ende der Funktion
        //================================================================================================
        //================================================================================================
        public List<Projektile> shoot(List<Projektile> list,Vector2f playerPosition)
        {
            list.Add(new Projektile(playerPosition, position,shotspeed, range));
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
        public Vector2f getPosition()
        {
            return position;
        }

        // Ende der Getterfunktionen
        //================================================================================================
        //================================================================================================
    
    }
}
