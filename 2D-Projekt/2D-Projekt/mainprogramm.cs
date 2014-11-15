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
            // Startscreen 
                while (!(Keyboard.IsKeyPressed(Keyboard.Key.Space)))
                {
                    win.Draw(new Sprite(new Texture("pictures/startscreen.png")));
                    win.Display();
                }


            initialize();
            loadContent();

            // Das eigentliche Spiel
            while (win.IsOpen())
            {
                // Schauen ob Fenster geschlossen werden soll
                win.DispatchEvents();
                // Positionsupdate aller Figuren 
                update(win);
                draw(win);

            }
        }



        // Ende der Funktion
        //================================================================================================
        //================================================================================================
        // wichtig Variablen 

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


        // Ende der Variablen für die Main
        //================================================================================================
        //================================================================================================

        // Initialisierung aller wichtigen Instanzen 
        static void initialize()
        {
            player = new Player();
            map = new Map(1);
            playerProjektileList = new List<Projektile>();
            enemyList = new List<dynamic>();
            powerup = new List<PowerUp>();
            Rnd = new Random();
            powerupKind = Rnd.Next(1,6);



        }

        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        static void win_Closed(object sender, EventArgs e)
        {
            // Fenster Schließen
            ((RenderWindow)sender).Close();
        }

        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        // Schreibt die Gegnerliste mit Gegner nach Form wie unten 
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


        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        // Updatefunktion

        static void update( RenderWindow win)
        {
            // Überprüfung Tod des Spielers
            if (player.life == 0)
            {
                deadPlayer(win);
            }

           player.update(map);

            // Berechnet die Bewegung der Gegner in Abhängigkeit der Spielerposition
           for (int i = 0; i < enemyList.Count; i++)
           {
               enemyList.ElementAt(i).update(player.playerPosition);
           }

          
        //=============================================================================
            // Erstellen von Kugeln wenn eine Taste gedrückt wird 

           if (FireRateCounter == player.fireRate)
           {
               if (Keyboard.IsKeyPressed(Keyboard.Key.W) || Keyboard.IsKeyPressed(Keyboard.Key.A) || Keyboard.IsKeyPressed(Keyboard.Key.S) || Keyboard.IsKeyPressed(Keyboard.Key.D))
               {
                   playerProjektileList.Add(new Projektile(player));
               }
               // Cooldown bis zum nächsten Schuss. Ansonsten Laser 
               FireRateCounter = 0;
           }
           FireRateCounter++;

            //==========================================================================
            // Projektilpositionsupdate 

           if (playerProjektileList.Count > 0)
           {
               for (int i = 0; i <= playerProjektileList.Count - 1; i++)
               {
                   playerProjektileList = playerProjektileList.ElementAt(i).update(playerProjektileList, i, player.shotSpeed, player.shotRange , map);

               }
           }

<<<<<<< HEAD
            // Kollisionsabfrage mit Lebensverlust


            // mit Trefern
           if ((collision(player.getplayerRect(), enemy1.getEnemyRect()) && player.protectedTime <= 0) || (collision(player.getplayerRect(), enemy2.getEnemyRect()) && player.protectedTime <= 0))


            // mit Treffern
=======
            //============================================================================
            // Untersucht Kollision mit Gegnern in der Gegnerliste. sorgt für kurze Schutzzeit nach Treffern

>>>>>>> 80dcd622714397de4054f022f6f935ba75a12199
           for (int i = 0; i < enemyList.Count; i++)

           {
               if (collision(player.getplayerRect(), enemyList.ElementAt(i).getEnemyRect()) && player.protectedTime <= 0)
               {
                   player.life--;
                   player.protectedTime = 20;
               }
           }
           player.protectedTime--;

<<<<<<< HEAD



            // Projektil mit Gegnerkontakt
           for (int i = 0; i < liste.Count; i++)


            // Projektil mit Gegnerkontakt entfernen von Feinden 

            // Projektil mit Gegnerkontakt, Feind schaden und entfernen von Feinden 

=======
            //============================================================================================
            // Untersucht Kollision zwischen den Projektilen des Spielers und Gegnern. Zieht ggf. Gegnerleben ab oder entfernt diese
>>>>>>> 80dcd622714397de4054f022f6f935ba75a12199
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

            //=====================================================================================
            //Sorgt dafür,dass wenn alle Gegner besiegt sind ein Powerup spawnt und beim Aufnehmen das nächste Level gestartet wird 

           if (enemyList.Count == 0 && LootTaken== false)
           {
               powerup.Add(new PowerUp(powerupKind));

               if (collision(player.getplayerRect(), powerup.ElementAt(0).getPowerUpRect()))
               {
                   powerup.ElementAt(0).giveThePower(player);
                   LootTaken = true;
                   loadNextLevel();
               }
           }
        }

        // Ende der Funktion
        //================================================================================================
        //================================================================================================



        // Aktualisieren der Sprites im Fenster
        static void draw(RenderWindow win)
        {
            // Malt die Map 
            map.draw(win);

            //===================================================
            // Malt alle Projektile in der Liste der Playerprojektile

            if (playerProjektileList.Count != 0)
            {
                for (int i = 0; i <= playerProjektileList.Count - 1; i++)
                {
                    playerProjektileList.ElementAt(i).draw(win);
                }
            }
            // Malt den Player

            player.draw(win);
            //=============================================================
         
            // Malt die Gegner in der Gegnerliste
            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList.ElementAt(i).draw(win);
            }
            // ============================================================
            // Malt das PowerUp falls vorhanden

            if (powerup.Count != 0)
            {
                powerup.ElementAt(0).draw(win);
                powerup.RemoveAt(0);
                
            }

            //=================================================
            //Zeigt alles an 
                win.Display();
 
           
        }

        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        // Kollisionsabfrage über Rechtecke
        // jede wichtige Klasse verfügt bzw. sollte über eine getRekt() Funktion verfügen 
        static bool collision (FloatRect Objekt1, FloatRect Objekt2){

            if (Objekt1.Intersects(Objekt2))
            {
                return true;
            }
            else{
                return false ;
            }
    
    }

        // Ende der Funktion
        //================================================================================================
        //================================================================================================
        // Laden des nächsten Levels

        static void loadNextLevel()
        {

            // Wahl einer Zufälligen Map für das nächste Level 
            int mapvoting = Rnd.Next(1, 4);
            map = new Map(mapvoting);

           

            // Enemies für das nächste Level (Erklärung am Ende)
            int enemyvoting = Rnd.Next(1, 4);

            if(enemyvoting==1)
            enemies = new int[,] { { 1, 100, 450 }, { 1, 350, 450 }, { 1, 400, 450 }, { 1, 700, 450 }, { 1, 100, 300 }, { 1, 650, 300 }, { 1, 100, 250 }, { 1, 650, 250 }, { 1, 100, 100 }, { 1, 350, 100 }, { 1, 400, 100 }, { 1, 650, 100 } };
            if(enemyvoting==2)
            enemies = new int[,] { { 1, 100, 200 }, { 1, 200, 300 }, { 2, 600, 550 }, { 2, 300, 500 } };
            if(enemyvoting==3)
            enemies = new int[,] { { 2, 100, 100 }, { 2, 650, 100 }, { 2, 100, 450 }, { 2, 650, 450 } };
            // variable für das n#chste PowerUp
            powerupKind = Rnd.Next(1, 6);
            // Laden der Gegner
            loadContent();
            // erlaubt Loot zu nehmen 
            LootTaken = false;

        }
        // Ende der Funktion
        //================================================================================================
        //================================================================================================
        static void deadPlayer(RenderWindow win)
        {
            while (player.life == 0)
            {
                win.Draw(new Sprite(new Texture("pictures/gameoverscreen.png")));
                win.Display();
                if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                {
                    player.life = 3;
                    initialize();
                    loadContent();
                }
                while (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                {

                }
            }
        }
        // Ende der Funktion
        //================================================================================================
        //================================================================================================
    }
}
/******************************************************************
if(enemyvoting==3)
            enemies = new int[,] { { 2, 100, 100 }, { 2, 650, 100 }, { 2, 100, 450 }, { 2, 650, 450 } };
 * 
 * Regeln für die Erstellung von Gegnerkombinationen :
 * in jeder Zeile snd drei Werte
 * 1. Typ des Gegners
 *      1 -> FollowerE ( Verfolgt den Spieler langsam mit drei Leben )
 *      2. -> Charger (selbes Prinzip wie beim FollowerE nur mit Charge falls er sich auf höhe des Spielers befindet
 * 2. X-Koordinate in Pixel
 * 3. Y-Koordinate in Pixel
 * 
 * Implementierung:
 * neue Liste unter if Abfrage mit erhöhtem enemyvoting
 * int enemyvoting = Rnd.Next(1, X); X ein höher als das höchste Enemyvoting setzen
******************************************************************/
