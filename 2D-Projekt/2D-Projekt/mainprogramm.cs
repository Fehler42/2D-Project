﻿using System;
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
            RenderWindow win = new RenderWindow(new VideoMode(800, 600), "Magic Meadow");
            win.SetFramerateLimit(45);
            // Achte darauf, ob Fenster geschlossen wird
            win.Closed += win_Closed;
            win.Display();
            // Startscreen 
            Sprite start = new Sprite(new Texture("pictures/Titelbildschirm.jpg"));
            Sprite start2 = new Sprite(new Texture("pictures/Titelbildschirm02.jpg"));
            win.Draw(start);
            win.Display();
            Boolean start1 = true;
            GameTime time = new GameTime();
            time.start();

                while (!(Keyboard.IsKeyPressed(Keyboard.Key.Space)))
                {
                    time.update();
                    if (time.TotalTime.Milliseconds == 600 && start1 == true) {
                        start1 = false;
                        win.Draw(start2);
                        time.stop();
                        time.start();
                    win.Display();
                }
                    else if (time.TotalTime.Milliseconds == 600 && start1 == false)
                    {
                        start1 = true;
                        win.Draw(start);
                        time.stop();
                        time.start();
                        win.Display();
                    }
                    win.DispatchEvents();
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
        static int[,] enemies = {{1,250,300}};
        static bool firstBoss = true;
        static int bossfight = 0;
       


        static int FireRateCounter = 0;
        // Enemy Projektilliste
        static List<Projektile> enemyProjektilList;
        static int enemyfireRateCounter= 0;
        static int enemyFireRate = 40;

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
            map = new Map(5); 
            playerProjektileList = new List<Projektile>();
            enemyList = new List<dynamic>();
            powerup = new List<PowerUp>();
            Rnd = new Random();
            powerupKind = Rnd.Next(1,6);
            enemyProjektilList = new List<Projektile>();


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
                if (enemies[i, 0] == 1)
                {
                    enemyList.Add(new FollowerE(enemies[i, 1], enemies[i, 2]));
                }
                if (enemies[i, 0] == 2)
                {
                    enemyList.Add(new Charger(enemies[i, 1], enemies[i, 2]));
                }
                if (enemies[i, 0] == 3)
                {
                    enemyList.Add(new Feared(enemies[i, 1], enemies[i, 2]));
                }
                if (enemies[i, 0] == 4)
                {
                    enemyList.Add(new Turret(enemies[i, 1], enemies[i, 2]));
                }
                if (enemies[i, 0] == 5)
                {
                    enemyList.Add(new flyingTurret(enemies[i, 1], enemies[i, 2]));
                }
                if (enemies[i, 0] == 6)
                {
                    enemyList.Add(new Bouncer(enemies[i, 1], enemies[i, 2]));
                }
                if (enemies[i, 0] == 7)
                {
                    enemyList.Add(new TurretBouncer(enemies[i, 1], enemies[i, 2]));

                }
                if (enemies[i, 0] == 8)
                {
                    enemyList.Add(new Boss(enemies[i, 1], enemies[i, 2]));

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
            if (player.life <= 0)
            {
                deadPlayer(win);
            }

           player.update(map);

            // Berechnet die Bewegung der Gegner in Abhängigkeit der Spielerposition
           for (int i = 0; i < enemyList.Count; i++)
           {
               enemyList.ElementAt(i).update(player.playerPosition , map);
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
                       playerProjektileList = playerProjektileList.ElementAt(i).update(playerProjektileList, i, player.shotSpeed, player.shotRange, map);

                   }
               }


            // Kollisionsabfrage mit Lebensverlust


          

            // mit Treffern

            //============================================================================
            // Untersucht Kollision mit Gegnern in der Gegnerliste. sorgt für kurze Schutzzeit nach Treffern


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

            // Projektil mit Gegnerkontakt, Feind schaden und entfernen von Feinden 


            //============================================================================================
            // Untersucht Kollision zwischen den Projektilen des Spielers und Gegnern. Zieht ggf. Gegnerleben ab oder entfernt diese

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

           //=============================================================================
           // Erstellen von Gegnerprojektilen 
           if (enemyfireRateCounter == enemyFireRate)
           {
               for (int k = 0; k < enemyList.Count; k++)
               {
                   enemyProjektilList = enemyList.ElementAt(k).shoot(enemyProjektilList, player.playerPosition);
               }
               enemyfireRateCounter = 0;

           }
           enemyfireRateCounter++;
            //=================================================================================
            // Projektil Positionsupdate
           for (int i = 0; i < enemyProjektilList.Count; i++)
           {
               enemyProjektilList = enemyProjektilList.ElementAt(i).update(enemyProjektilList, i, map);
           }
           //=================================================================================
           // Kollisionscheck zwischen Spieler und den Gegnerprojektilen 
           for (int i = 0; i < enemyProjektilList.Count; i++)
           {
               if (collision(player.getplayerRect(), enemyProjektilList.ElementAt(i).getProjektileRekt()))
               {
                   player.life--;
                   enemyProjektilList.RemoveAt(i);
                   if (player.life <= 0)
                   {
                       deadPlayer(win);
                   }
               }
           }


               //=====================================================================================
               //Sorgt dafür,dass wenn alle Gegner besiegt sind ein Powerup spawnt und beim Aufnehmen das nächste Level gestartet wird 

               if (enemyList.Count == 0 && LootTaken == false)
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
            // ============================================================
            // Gegnerprojektile

            for( int i = 0 ; i < enemyProjektilList.Count ; i ++){
                enemyProjektilList.ElementAt(i).draw(win);
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
            int mapvoting = Rnd.Next(1, 11);
            map = new Map(mapvoting);

           

            // Enemies für das nächste Level (Erklärung am Ende)
            int enemyvoting = Rnd.Next(1, 9);
            if (bossfight == 10)
            {
                enemyvoting = 9;
                bossfight = 0;
                if (firstBoss == false)
                {
                    enemies = new int[,] { { 8, 425, 425 }, { 8, 400, 200 } };
                }
            }



            if(enemyvoting==1)
            enemies = new int[,] { { 1, 100, 450 }, { 1, 350, 450 }, { 1, 400, 450 }, { 1, 700, 450 }, { 1, 100, 300 }, { 1, 650, 300 }, { 1, 100, 250 }, { 1, 650, 250 }, { 1, 100, 100 }, { 1, 350, 100 }, { 1, 400, 100 }, { 1, 650, 100 } };
            if(enemyvoting==2)
            enemies = new int[,] { { 1, 100, 200 }, { 1, 200, 300 }, { 2, 600, 550 }, { 2, 300, 500 } };
            if(enemyvoting==3)
            enemies = new int[,] { { 2, 100, 100 }, { 2, 650, 100 }, { 2, 100, 450 }, { 2, 650, 450 } };
            if(enemyvoting == 4)
            enemies = new int[,] { { 4, 200, 325 }, { 4, 650, 325 }, { 3, 425, 75 }, { 3, 425, 500 } };
            if(enemyvoting == 5)
            enemies = new int[,] { { 5, 100, 450 }, { 3, 650, 75 }, { 3, 550, 300 }, { 2, 200, 300 } };
            if (enemyvoting == 6)
            enemies = new int[,] { { 7, 650, 300 }, { 6, 100, 200 } };
            if (enemyvoting == 7)
            enemies = new int[,] { { 1, 100, 450 }, { 2, 350, 450 }, { 3, 425, 100 }, { 6, 200, 300 } };
            if (enemyvoting == 8)
                enemies = new int[,] { { 6, 400, 450 }, { 6, 100, 450 } };
            if (enemyvoting == 9 && firstBoss == true)
            {
                enemies = new int[,] { { 8, 425, 425 } };
                firstBoss = false;
            }

            // variable für das n#chste PowerUp
            powerupKind = Rnd.Next(1, 6);
            // Laden der Gegner
            loadContent();
            // erlaubt Loot zu nehmen 
            LootTaken = false;
            bossfight++;

        }
        // Ende der Funktion
        //================================================================================================
        //================================================================================================
        static void deadPlayer(RenderWindow win)
        {
            GameTime time = new GameTime();
            Boolean end1 = true;
            Sprite end = new Sprite(new Texture("pictures/RipBildschirm.jpg"));
            Sprite end2 = new Sprite(new Texture("pictures/RipBildschirm02.jpg"));
            win.Draw(end);
            win.Display();
            time.start();
            while (player.life == 0)
            {
                win.DispatchEvents();
               
                if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                {
                    player.life = 3;
                    initialize();
                    enemies = new int[,] { { 1, 250, 300 } };
                    loadContent();
                    bossfight = 0;
                }
                    time.update();
                    if (time.TotalTime.Milliseconds == 600 && end1 == true)
                    {
                        end1 = false;
                        win.Draw(end);
                        time.stop();
                        time.start();
                        win.Display();
                    }
                    else if (time.TotalTime.Milliseconds == 600 && end1 == false)
                    {
                        end1 = true;
                        win.Draw(end2);
                        time.stop();
                        time.start();
                        win.Display();
                    }
            }
        }
        // Ende der Funktion
        //================================================================================================
        //================================================================================================
    }
}
/******************************************************************
 * Leitfaden zur Erstellung von Gegnerkombinationen 
 * ---------------------------------------------------

 * if(enemyvoting==3)
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


/**********************************************************************
 * Leitfaden zur Gegnererstellung:
 * --------------------------------------
 * Für jeden Gegner eine neue Klasse erstellen.
 * Die Klasse muss folgende Funktionen und Variablen enthalten :
 * 
 *       // Variablen
        Sprite enemySprite = new Sprite();
        Vector2f position;
        public int life = 3;
 * 
 *      // Bei Gegnern mit Schüssen 
        int shotspeed = 1;
        int range = 200;
 
        // Constructor
        public Turret(int x , int y)
        {
            Texture playerTexture = new Texture("pictures/turret.png");
            enemySprite = new Sprite(playerTexture);
            position = new Vector2f(x, y);
            enemySprite.Position = position;
            enemySprite.Scale = new Vector2f(0.5f, 0.5f);
        }

        // draw
        public void draw(RenderWindow win)
        {
            win.Draw(enemySprite);
        }

        public void update(Vector2f destination , Map map)
        {
 *         // Hier kann ein Bewegungsmuster berechnet erstellt werden. Außerdem kommen Kollisionen mit den Wänden hin
 *          
            enemySprite.Position = position;
        }

        // Ende der Funktion
        public List<Projektile> shoot(List<Projektile> list,Vector2f playerPosition)
        {
 *              // Hier können Gegebenenfalls Projektile übergeben werden , Näheres ist den beiden Constructoren in der Projektilklasse zu entnehmen
            return list;
        }



        // Getter Funktionen  wichtig für Kollisionsabfragen 
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
 * 
 * // Alle aufgeführten Funktionen !!!!!!!!!!!!!!!!!!!müssen !!!!!!!!!!!!!!!!! vorhanden sein da es sonst Probleme mit der Gegnerliste gibt
 * 
 * Implementierung:
 * initialisierungszahl in die Funktion
 * loadContent() einfügen 
 * 
 * in einer Gegnerkombination verwenden 
 * 
 * sich über den Feind freuen XD
**********************************************************************/

