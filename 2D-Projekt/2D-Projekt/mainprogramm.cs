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
        static List<Projektile> playerProjektileList;

        // Enemy Stuff
        static List<dynamic> enemyList;
        static int[] enemies = { 1, 1, 2, 2 };
        static int enemyListcount  = 0;

        static int FireRateCounter = 0;
        static void initialize()
        {
            player = new Player();
            map = new Map();
            playerProjektileList = new List<Projektile>();
            enemyList = new List<dynamic>();
            //enemy1 = new FollowerE();
            //enemy2 = new Charger();



        }
        static void win_Closed(object sender, EventArgs e)
        {
            // Fenster Schließen
            ((RenderWindow)sender).Close();
        }
        static void loadContent()
        {

            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i] == 1)
                {
                    enemyList.Add(new FollowerE());
                }
                if (enemies[i] == 2)
                {
                    enemyList.Add(new Charger());
                }
            }




        }
        // Updatefunktion

        static void update()
        {
           player.update(map);

            // enemyUpdate
           for (int i = 0; i < enemyList.Count; i++)
           {
               enemyList.ElementAt(i).update(player.playerPosition);
           }

          
        

            // Erstellen von Kugeln wenn eine Taste gedrückt wird 
           if (FireRateCounter == player.fireRate)
           {
               if (Keyboard.IsKeyPressed(Keyboard.Key.W) || Keyboard.IsKeyPressed(Keyboard.Key.A) || Keyboard.IsKeyPressed(Keyboard.Key.S) || Keyboard.IsKeyPressed(Keyboard.Key.D))
               {
                   playerProjektileList.Add(new Projektile(player));
               }
               FireRateCounter = 0;
           }

           FireRateCounter++;

            // Projektilpositionsupdate 
           if (playerProjektileList.Count > 0)
           {
               for (int i = 0; i <= playerProjektileList.Count - 1; i++)
               {
                   playerProjektileList = playerProjektileList.ElementAt(i).update(playerProjektileList, i, player.shotSpeed, player.shotRange , map);

               }
           }

            // Kollisionsabfrage mit Lebensverlust
            // mit Treffern
           for (int i = 0; i < enemyList.Count; i++)
           {
               if (collision(player.getplayerRect(), enemyList.ElementAt(i).getEnemyRect()) && player.protectedTime <= 0)
               {
                   player.life--;
                   player.protectedTime = 20;
               }
           }
           player.protectedTime--;



            // Projektil mit Gegnerkontakt entfernen von Feinden 
           for (int i = 0; i < playerProjektileList.Count; i++)

           {

                   for (int k = enemyList.Count - 1; k >= 0; k--)
                   {


                       if (collision(playerProjektileList.ElementAt(i).getProjektileRekt(), enemyList.ElementAt(k).getEnemyRect()))
                       {
                           playerProjektileList.RemoveAt(i);
                           enemyList.ElementAt(k).life--;

                           if (enemyList.ElementAt(k).life == 0)
                           {
                               enemyList.RemoveAt(k);
                           }
                           break;
                       }
              
               }

           }

        }

        // Aktualisieren der Sprites im Fenster

        static void draw(RenderWindow win)
        {
            map.draw(win);
            
            if (playerProjektileList.Count != 0)
            {
                for (int i = 0; i <= playerProjektileList.Count - 1; i++)
                {
                    playerProjektileList.ElementAt(i).draw(win);
                }
            }
            player.draw(win);

            // drawn von enemies
            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList.ElementAt(i).draw(win);
            }


            win.Display();
           
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