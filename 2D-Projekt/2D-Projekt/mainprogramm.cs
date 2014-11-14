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
            win.SetFramerateLimit(45);
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
        static List<Projektile> liste;
        static Projektile schuss;
        static void initialize()
        {
            player = new Player();
            map = new Map();
            liste = new List<Projektile>();
            schuss = new Projektile(player.getPosition());

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
           player.update(map);


           if (schuss.RangeCounter < (int) schuss.getRange())
           {
               schuss.update();
               schuss.RangeCounter ++;
           }
           else
           {
               schuss = new Projektile(player.getPosition());
           }
          
           
           if (liste.Count != 0)
           {
               for (int i = 0; i <= liste.Count -1; i++)
               {
                   liste.ElementAt(i).update();
               }
           }

        }

        // Aktualisieren der Sprites im Fenster

        static void draw(RenderWindow win)
        {
            map.draw(win);
            player.draw(win);
            if (schuss.getSprite() != null)
            {
                schuss.draw(win);
            }
            win.Display();
            
            if (liste.Count != 0)
            {
                for (int i = 0; i <= liste.Count -1; i++)
                {
                    liste.ElementAt(i).draw(win);
                }
            }
        }
        // Kollisionsabfrage über Rechtecke
        static bool collision (FloatRect Objekt1, FloatRect Objekt2){

            if (Objekt1.Intersects(Objekt2))
            {
                return true;
            }
            else{
                return false ;
            }
    
    }
        

    }
}
