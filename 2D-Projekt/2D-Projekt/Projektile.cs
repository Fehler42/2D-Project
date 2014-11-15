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
        private Sprite projektSprite;
        // position und startposition von Projektilen
        Vector2f position;
        Vector2f sPosition;
        // Texture, Scale of Texture and width and height
        Texture projectTexture = new Texture("pictures/bull.png");

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

        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        // Festlegen von Sprites Positionen und Skalierung
        public void ProjektileInilization(Vector2f _direction, Vector2f startPosition )
        {
            
            projektSprite = new Sprite(projectTexture);
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
