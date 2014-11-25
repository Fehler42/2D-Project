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

        // Variablen
        private Vector2f direction = new Vector2f (0,0) ;
        int shotspeed = 0;
        int range = 0;
        // position und startposition von Projektilen
        Vector2f position;
        Vector2f sPosition;
        // Texture, Scale of Texture and width and height
        private Sprite projektSprite;

        // Ende der Variablen
        //================================================================================================
        //================================================================================================


        // Erstellen von Projektilen 
        // Projektile werden inizialisiert. Dafür wird ihnen (Richtungsvektor, Startpositionsvektor in Abhängigkeit des Players) übergeben 
        public Projektile(Player player)
        {
                if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                {
                    ProjektileInilization(new Vector2f(0, -1), new Vector2f(player.playerPosition.X + 0.5f * player.getWidth(), player.playerPosition.Y));
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                {
                    ProjektileInilization(new Vector2f(-1, 0), new Vector2f(player.playerPosition.X, player.playerPosition.Y ));
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                {
                    ProjektileInilization(new Vector2f(0, 1), new Vector2f(player.playerPosition.X + 0.5f * player.getWidth(), player.playerPosition.Y + 0.5f * player.getHeight()));
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                {
                    ProjektileInilization(new Vector2f(1, 0), new Vector2f(player.playerPosition.X + 0.5f * player.getWidth(), player.playerPosition.Y));
                }
            }
        public Projektile(Vector2f _direction, Vector2f startPosition, int shotpeed , int rang)
        {
            position = startPosition;
            sPosition = startPosition;
            // Rechung für Vektorlänge , da ansonsten Error mit den Playerprojektilen
            direction = new Vector2f(_direction.X - startPosition.X, _direction.Y - startPosition.Y);
            float n = (float)Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y);
            direction = new Vector2f(direction.X / n, direction.Y / n);
            // Standartstuff
            projektSprite = new Sprite(new Texture("pictures/bulle.png"));
            projektSprite.Position = position;
            projektSprite.Scale = new Vector2f(1, 1);
            shotspeed = shotpeed;
            range = rang;
 
        }


        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        // Festlegen von Sprites Positionen und Skalierung
        public void ProjektileInilization(Vector2f _direction, Vector2f startPosition )
        {
            projektSprite = new Sprite(new Texture("pictures/bull.png"));
            position = startPosition;
            sPosition = startPosition;
            direction = _direction;
            projektSprite.Position = position;
            projektSprite.Scale = new Vector2f(1, 1); // 1, 1
        }
        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        // draw 
        public void draw(RenderWindow win)
        {
            win.Draw(projektSprite);
    
        }

        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        // Berechnung der Flugbahn  unter einbeziehen von Schusstempo und Range
        public List<Projektile> update(List<Projektile> list, int i , int speed , int Range , Map map)
        {
            // erstellt einen Vektor für die nächste Position des Projektils
            Vector2f wallCollisionTest = new Vector2f(position.X + (direction.X * speed), position.Y + (direction.Y * speed));

            // Überprüft ob an der zukünftigen Stelle Platz vorhanden ist 
            bool freeWay = map.isWalkable((int)wallCollisionTest.X /50,(int) wallCollisionTest.Y/50);

            // setzt das Projektil falls es sich innerhalb der Reichweite des Players befindet und der Weg frei ist in seine Richtung weiter oder entfernt es ggf. aus der Liste
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
        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        public List<Projektile> update(List<Projektile> list, int i, Map map)
        {
            // erstellt einen Vektor für die nächste Position des Projektils
            Vector2f wallCollisionTest = new Vector2f(position.X + (direction.X * shotspeed), position.Y + (direction.Y * shotspeed));

            // Überprüft ob an der zukünftigen Stelle Platz vorhanden ist 
            bool freeWay = map.isWalkable((int)wallCollisionTest.X / 50, (int)wallCollisionTest.Y / 50);

            // setzt das Projektil falls es sich innerhalb der Reichweite des Players befindet und der Weg frei ist in seine Richtung weiter oder entfernt es ggf. aus der Liste
            if (Math.Abs(sPosition.X - position.X) + Math.Abs(sPosition.Y - position.Y) < range && freeWay)
            {
                position = new Vector2f(position.X + (direction.X * shotspeed), position.Y + (direction.Y * shotspeed));
                projektSprite.Position = position;
            }
            else
            {
                list.RemoveAt(i);
                return list;
            }
            return list;

        }
        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        // Getter-Funktionen für die Projektilklasse

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
        // Ende der Getterfunktion
        //================================================================================================
        //================================================================================================
    }
}
