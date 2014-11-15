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
        static int[,] enemies = { {1,100,200}
                                , {1,200,300},
                                  {2,600,550},
                                  {2,300,500}};

        static int FireRateCounter = 0;

        // Epic loot 
        static List<PowerUp> powerup;
        static bool LootTaken = false;
        static Random Rnd;
        static int powerupKind;

        static void initialize()
        {
            player = new Player();
            map = new Map();
            playerProjektileList = new List<Projektile>();
            enemyList = new List<dynamic>();
            powerup = new List<PowerUp>();
            Rnd = new Random();
            powerupKind = Rnd.Next(1,6);



        }
        static void win_Closed(object sender, EventArgs e)
        {
            // Fenster Schließen
            ((RenderWindow)sender).Close();
        }
        static void loadContent()
        {

            for (int i = 0; i < enemies.GetLength(0); i++)
            {
                if (enemies[i,0] == 1)
                {
                    enemyList.Add(new FollowerE(enemies[i,1],enemies[i,2]));
                }
                if (enemies[i,0] == 2)
                {
                    enemyList.Add(new Charger(enemies[i, 1], enemies[i, 2]));
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


            // Projektil mit Gegnerkontakt, Feind schaden und entfernen von Feinden 
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

           if (enemyList.Count == 0 && LootTaken== false)
           {
               powerup.Add(new PowerUp(powerupKind));

               if (collision(player.getplayerRect(), powerup.ElementAt(0).getPowerUpRect()))
               {
                   powerup.ElementAt(0).giveThePower(player);
                   LootTaken = true;
               }
     
           }


        }


        // Aktualisieren der Sprites im Fenster

        static void draw(RenderWindow win)
        {
            map.draw(win);
            // draw Projektiles of Player
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

            // draw PowerUp
            if (powerup.Count != 0)
            {
                powerup.ElementAt(0).draw(win);
                powerup.RemoveAt(0);
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