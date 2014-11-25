using SFML.Graphics;
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
        int ueberStandCounter = 0;

        // Wichtige public Variablen für den  Player . In Kommentaren befinden sich passable Standartwerte

        public int speed = 3 ;//3
        public int fireRate = 20; // 20
        public int shotSpeed = 3; // 3
        public int shotRange = 150;// 150


        // Variablen für Lebensanzeige
        public int life = 3;
        Sprite heart = new Sprite(new Texture("pictures/heart.png"));
        public int protectedTime = 20;

        // Ende der Variablen
        //================================================================================================
        //================================================================================================

        // Constructor
        public Player()
        {
            Texture playerTexture = new Texture("pictures/player.png");
            playerSprite = new Sprite(playerTexture);
            playerPosition = new Vector2f(375, 275);
            playerSprite.Position = playerPosition;
            playerSprite.Scale = new Vector2f(0.8f, 0.8f);

        }

        // Ende der Funktion
        //================================================================================================
        //================================================================================================


        // Zeichnen des Sprites
        public void draw(RenderWindow win)
        {
            win.Draw(playerSprite);
            drawHearts(win);
        }

        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        //Zeichnen von lifes Herzen 
        public void drawHearts(RenderWindow win)
        {
            heart.Position = new Vector2f(0, 0);
            for (int i = 0; i < this.life; i++)
            {
                win.Draw(heart);
                heart.Position = new Vector2f(heart.Position.X + (int)(heart.Texture.Size.X * heart.Scale.X), heart.Position.Y);
            }
        }

        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        // Bewegen der Figur
        public void update(Map map)
        {

            // Variablen zum Abfragen ob eine Kollision mit der Wand stattfindet 

            bool upwalkable = map.isWalkable((int)(this.getPosition().X) / 50,(int)(this.getPosition().Y - speed) / 50) && 
                              map.isWalkable((int)(this.getPosition().X + this.getWidth()) / 50, (int)(this.getPosition().Y - speed) / 50);

            bool downwalkable = map.isWalkable((int)(this.getPosition().X ) / 50,(int)(this.getPosition().Y + (int) this.getHeight() + speed) / 50) &&
                                map.isWalkable((int)(this.getPosition().X + this.getWidth()) / 50, (int)(this.getPosition().Y + (int)this.getHeight() + speed) / 50);

            bool rightwalkable = map.isWalkable((int)(this.getPosition().X +(int) this.getWidth() +speed) / 50,(int)(this.getPosition().Y) / 50) &&
                                 map.isWalkable((int)(this.getPosition().X +(int) this.getWidth() +speed) / 50,(int)(this.getPosition().Y + this.getHeight()) / 50);

            bool leftwalkable = map.isWalkable((int)(this.getPosition().X - speed) / 50,(int)(this.getPosition().Y) / 50) &&
                                map.isWalkable((int)(this.getPosition().X -speed) / 50,(int)(this.getPosition().Y + this.getHeight()) / 50);

            bool leftwalkable2 =  map.isWalkable((int)(this.getPosition().X - speed) / 50, (int)(this.getPosition().Y + 20) / 50);

            bool rightwalkable2 =  map.isWalkable((int)(this.getPosition().X + (int)this.getWidth() + speed) / 50, (int)(this.getPosition().Y + 20) / 50);

            bool upwalkable2 = map.isWalkable((int)(this.getPosition().X) / 50, (int)(this.getPosition().Y - speed +20) / 50) &&
                              map.isWalkable((int)(this.getPosition().X + this.getWidth()) / 50, (int)(this.getPosition().Y - speed+20) / 50);



            // Aktualisierung der Bewegung

            if (Keyboard.IsKeyPressed(Keyboard.Key.Up) && upwalkable)
            {
                playerPosition = new Vector2f(playerPosition.X, playerPosition.Y - speed);

            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up) && !upwalkable && upwalkable2)
            {
                playerPosition = new Vector2f(playerPosition.X, playerPosition.Y - speed);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down) && downwalkable)
            {
                playerPosition = new Vector2f (playerPosition.X, playerPosition.Y + speed);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right) && rightwalkable)
            {
                playerPosition = new Vector2f(playerPosition.X + speed, playerPosition.Y);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right) && !rightwalkable  && rightwalkable2)
            {
                playerPosition = new Vector2f(playerPosition.X + speed, playerPosition.Y);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left) && leftwalkable)
            {
                playerPosition = new Vector2f(playerPosition.X - speed, playerPosition.Y);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left) && !leftwalkable && leftwalkable2)
            {
                playerPosition = new Vector2f(playerPosition.X - speed, playerPosition.Y);
            }

            // Aktualisierung der Spriteposition

            playerSprite.Position = playerPosition;

        }

        // Ende der Funktion
        //================================================================================================
        //================================================================================================


        // getter Methoden 
        public Vector2f getPosition()
        {
            return playerPosition;
        }

        public float getHeight()
        {
            return playerSprite.Texture.Size.Y * playerSprite.Scale.Y;
        }

        public float getWidth()
        {
            return playerSprite.Texture.Size.X * playerSprite.Scale.X;
        }

        public FloatRect getplayerRect(){
            return new FloatRect(playerPosition.X, playerPosition.Y, this.getWidth(), this.getHeight());
        }
        // Ende der Getterfunktionen
        //================================================================================================
        //================================================================================================




    }
}
