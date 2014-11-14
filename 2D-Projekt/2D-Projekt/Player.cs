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
        FloatRect playerRect;
        float speed = 3;
        public int fireRate = 20;
        public int shotSpeed = 3;
        public int shotRange = 150;


        // Variablen für Lebensanzeige
        public int life = 3;
        Sprite heart = new Sprite(new Texture("pictures/heart.png"));
        public int protectedTime = 20;
        
        // Constructor
        public Player()
        {
            Texture playerTexture = new Texture("pictures/player.png");
            playerSprite = new Sprite(playerTexture);
            playerPosition = new Vector2f(400, 400);
            playerSprite.Position = playerPosition;
            playerSprite.Scale = new Vector2f(0.5f, 0.5f);

        }

        // Zeichnen des Sprites
        public void draw(RenderWindow win)
        {
            win.Draw(playerSprite);
            drawHearts(win);
        }
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
        // Bewegen der Figur
        public void update(Map map)
        {
            // Vorbereitung Kollisionsabfrage
            playerRect = new FloatRect(playerPosition.X,playerPosition.Y, playerSprite.Texture.Size.X, playerSprite.Texture.Size.Y);

            // Variablen zum Abfragen ob eine Kollision mit der Wand stattfindet 

            bool upwalkable = map.isWalkable((int)(this.getPosition().X) / 50,(int)(this.getPosition().Y - speed) / 50) && 
                              map.isWalkable((int)(this.getPosition().X + this.getWidth()) / 50, (int)(this.getPosition().Y - speed) / 50);

            bool downwalkable = map.isWalkable((int)(this.getPosition().X ) / 50,(int)(this.getPosition().Y + (int) this.getHeight() + speed) / 50) &&
                                map.isWalkable((int)(this.getPosition().X + this.getWidth()) / 50, (int)(this.getPosition().Y + (int)this.getHeight() + speed) / 50);

            bool rightwalkable = map.isWalkable((int)(this.getPosition().X +(int) this.getWidth() +speed) / 50,(int)(this.getPosition().Y) / 50) &&
                                 map.isWalkable((int)(this.getPosition().X +(int) this.getWidth() +speed) / 50,(int)(this.getPosition().Y + this.getHeight()) / 50);

            bool leftwalkable = map.isWalkable((int)(this.getPosition().X - speed) / 50,(int)(this.getPosition().Y) / 50) &&
                                map.isWalkable((int)(this.getPosition().X -speed) / 50,(int)(this.getPosition().Y + this.getHeight()) / 50);


            // Aktualisierung der Bewegung

            if (Keyboard.IsKeyPressed(Keyboard.Key.Up) && upwalkable)
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
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left) && leftwalkable)
            {
                playerPosition = new Vector2f(playerPosition.X - speed, playerPosition.Y);
            }

            // Projektile mit wasd abfeuern 
            playerSprite.Position = playerPosition;

        }


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



    }
}




//  float gravity = 0.1f;
//  bool gravityTester = false;
//  int jumpCount = 0;
// bool imSprungTest = false;

//// Bewegung nach rechts
//if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
//{
//    playerPosition = new Vector2f(playerPosition.X + 0.1f, playerPosition.Y);
//}
//// Bewegung nach links
//if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
//{
//    playerPosition = new Vector2f(playerPosition.X - 0.1f, playerPosition.Y);
//}
////if (Keyboard.IsKeyPressed(Keyboard.Key.LShift))
////{
////    gravity = gravity * -1;
////}
//// Springen 
//if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
//{
//    //Absprung
//    if (imSprungTest == false && jumpCount < 800)
//    {
//        playerPosition = new Vector2f(playerPosition.X, playerPosition.Y -  0.01f);
//        jumpCount++;
//    }
//    else //Fall
//    {
//        imSprungTest = true;

//    }


//}//Frühzeiter Abbruch des Sprungs
//if(imSprungTest == false && Keyboard.IsKeyPressed(Keyboard.Key.Space) == false)
//{
//    imSprungTest = true;
//}


//if (imSprungTest == true && jumpCount > 0)
//{
//    playerPosition = new Vector2f(playerPosition.X, playerPosition.Y + 0.01f);
//    jumpCount--;
//}
//else
//{

//    if (playerPosition.Y < 550)
//    {
//        playerPosition.Y = playerPosition.Y + 0.1f;
//        jumpCount --;
//    }

//    imSprungTest = false;

//}

//Schwerkraft  
//else
//{
//    if (playerPosition.Y < 550)
//    {
//        playerPosition.Y = playerPosition.Y + 0.1f;
//        jumpCount--;
//    }
//}