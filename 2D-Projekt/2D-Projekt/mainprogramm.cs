using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;


namespace _2D_Projekt
{
    class mainprogramm
    {
        static void Main(string[] args)
        {
            // Erzeuge ein neues Fenster
            RenderWindow win = new RenderWindow(new VideoMode(800, 600), "Mein erstes Fenster");

            // Achte darauf, ob Fenster geschlossen wird
            win.Closed += win_Closed;

            initialize();
            loadContent();

            // Das eigentliche Spiel
            while (win.IsOpen())
            {
                // Schauen ob Fenster geschlossen werden soll
                win.DispatchEvents();
                // Positionsupdate aller Figuren 
                update();
                draw(win);
            }
        }
        static Player player;
        static Map map;
        static void initialize()
        {
            player = new Player();
            map = new Map();

        }
        static void win_Closed(object sender, EventArgs e)
        {
            // Fenster Schließen
            ((RenderWindow)sender).Close();
        }
        static void loadContent()
        {

        }
        // Updatefunktion

        static void update()
        {
            player.move();
        }

        // Aktualisieren der Sprites im Fenster

        static void draw(RenderWindow win)
        {
            map.draw(win);
            player.draw(win);
            win.Display();
            
        }
        // erstellt einen Vektor der in der X Koordinate den Wert für einen Vector der breite hat und in der Y Koordinate  einen Wert für die Höhe 
        static Vector2f getVectors(float Object1width, float Object1height)
        {
            return new Vector2f (Object1width, Object1height);
        }


        static bool collision (Vector2f Object1Position, Vector2f Object1Vector , Vector2f Object2Position, Vector2f Object2Vector){

            Vector2f positionDifference = positionDifference = new Vector2f(Object2Position.X - Object1Position.X, Object2Position.Y - Object1Position.Y); 

            if (Object1Vector.X - positionDifference.X > 1 || Object1Vector.Y - positionDifference.Y > 1)
            {
                return false;
            }
            else
            {
                return true;
            }    
    }
        

    }
}
