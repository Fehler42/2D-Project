using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Projekt
{
    class Projektile
    {

        /*
         * Hier kommen TODOs für diese Klasse hin :
         * -Startposition von Projektilen auf den Player anpassen ! Achtung Projektile werden vllt. noch Skalierbar
         * -Projektile skalierbar machen  
         */

        // Variablen
        private Vector2f direction = new Vector2f (0,0) ;
        private Sprite projektSprite;
        // position and startposition of projectile
        Vector2f position;
        Vector2f sPosition;
       // FloatRect projectileRekt;
        // Texture, Scale of Texture and width and height
        Texture projectTexture = new Texture("pictures/bull.png");
        //fireRate



        // Erstellen von Projektilen 
        public Projektile(Player player)
        {
                if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                {
                    ProjektileInilization(new Vector2f(0, -1), new Vector2f(player.playerPosition.X + 0.5f * player.getWidth(), player.playerPosition.Y));
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                {
                    ProjektileInilization(new Vector2f(-1, 0), new Vector2f(player.playerPosition.X, player.playerPosition.Y - 0.5f * player.getHeight()));
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                {
                    ProjektileInilization(new Vector2f(0, 1), new Vector2f(player.playerPosition.X + 0.5f * player.getWidth(), player.playerPosition.Y));
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                {
                    ProjektileInilization(new Vector2f(1, 0), new Vector2f(player.playerPosition.X, player.playerPosition.Y - 0.5f * player.getHeight()));
                }
            

           

            }

        // Festlegen von Sprites Positionen und Skalierung
        public void ProjektileInilization(Vector2f _direction, Vector2f startPosition )
        {
            
            projektSprite = new Sprite(projectTexture);
            position = startPosition;
            sPosition = startPosition;
            direction = _direction;
            projektSprite.Position = position;
            projektSprite.Scale = new Vector2f(1, 1);
        }

        // draw 
        public void draw(RenderWindow win)
        {
            win.Draw(projektSprite);
    
        }

        // Berechnung der Flugbahn  unter einbeziehen von Schusstempo und Range
        public List<Projektile> update(List<Projektile> list, int i , int speed , int Range , Map map , FollowerE foe)
        {
            Vector2f wallCollisionTest = new Vector2f(position.X + (direction.X * speed), position.Y + (direction.Y * speed));

            bool freeWay = map.isWalkable((int)wallCollisionTest.X /50,(int) wallCollisionTest.Y/50);

            if (Math.Abs(sPosition.X - position.X) + Math.Abs(sPosition.Y - position.Y) < Range && freeWay)
            {
                position = new Vector2f(position.X + (direction.X * speed), position.Y + (direction.Y * speed));
                projektSprite.Position = position;
            }
            else
            {
                list.RemoveAt(i);
                return list;
            }
            return list;

        }

        static bool collision(FloatRect Objekt1, FloatRect Objekt2)
        {

            if (Objekt1.Intersects(Objekt2))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public FloatRect getProjektileRekt()
        {
            return new FloatRect(position.X, position.Y , this.getWidth() , this.getHeight());
        }
        public float getWidth()
        {
            return projektSprite.Texture.Size.X * projektSprite.Scale.X;
        }
        public float getHeight()
        {
            return projektSprite.Texture.Size.Y * projektSprite.Scale.Y;
        }

    }
}
