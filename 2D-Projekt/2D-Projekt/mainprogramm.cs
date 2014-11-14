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
        static int FireRateCounter = 0;
        static void initialize()
        {
            player = new Player();
            map = new Map();
            liste = new List<Projektile>();

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
           Console.WriteLine("Player");

            // Erstellen von Kugeln wenn eine Taste gedrückt wird 
           if (FireRateCounter == player.fireRate)
           {
               if (Keyboard.IsKeyPressed(Keyboard.Key.W) || Keyboard.IsKeyPressed(Keyboard.Key.A) || Keyboard.IsKeyPressed(Keyboard.Key.S) || Keyboard.IsKeyPressed(Keyboard.Key.D))
               {
                   liste.Add(schuss = new Projektile(player));
               }
               Console.WriteLine("Liste mit Projektilen abgehakt");
               FireRateCounter = 0;
           }

           FireRateCounter++;

            // Projektilpositionsupdate 
           if (liste.Count > 0)
           {
               for (int i = 0; i <= liste.Count - 1; i++)
               {
                   liste = liste.ElementAt(i).update(liste, i, player.shotSpeed, player.shotRange);
               }
           }
           Console.WriteLine("Projektile ubgedatet");

        }

        // Aktualisieren der Sprites im Fenster

        static void draw(RenderWindow win)
        {
            map.draw(win);
            
            if (liste.Count != 0)
            {
                for (int i = 0; i <= liste.Count - 1; i++)
                {
                    liste.ElementAt(i).draw(win);
                }
            }
            player.draw(win);
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