﻿using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Projekt
{
    class Player
    {
        // Klassenvariablen
        Sprite playerSprite;
        public Vector2f playerPosition;
        int jumpCount = 0;
        bool imSprungTest = false;
        
        // Constructor
        public Player()
        {
            Texture playerTexture = new Texture("pictures/player.png");
            playerSprite = new Sprite(playerTexture);
            playerPosition = new Vector2f(0, 550);
            playerSprite.Position = playerPosition;

        }

        // Zeichnen des Sprites
        public void draw(RenderWindow win)
        {
            win.Draw(playerSprite);
        }

        // Bewegen der Figur
        public void move()
        {
            // Bewegung nach rechts
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                playerPosition = new Vector2f(playerPosition.X + 0.1f, playerPosition.Y);
            }
            // Bewegung nach links
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                playerPosition = new Vector2f(playerPosition.X - 0.1f, playerPosition.Y);
            }
            // Springen 
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                //Absprung
                if (imSprungTest == false && jumpCount < 800)
                {
                    playerPosition = new Vector2f(playerPosition.X, playerPosition.Y - 0.1f);
                    jumpCount++;
                }
                else
                {
                    imSprungTest = true;
                }
                // Fall
                if (imSprungTest == true && jumpCount > 0)
                {
                    playerPosition = new Vector2f(playerPosition.X, playerPosition.Y + 0.1f);
                    jumpCount--;
                }
                else
                {
                    imSprungTest = false;
                }
            }
            //Schwerkraft  
            else
            {
                if (playerPosition.Y < 550)
                {
                    playerPosition.Y = playerPosition.Y + 0.1f;
                    jumpCount = 0;
                }
            }



            




            playerSprite.Position = playerPosition;
        }






    }
}
