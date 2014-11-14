using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Projekt
{
    class Projektile
    {
        private float Range = 50;
        private float speed = 5;
        private Vector2f direction;
        private Sprite projektSprite;
        public int RangeCounter = 51;
        Vector2f position;
       // FloatRect projectileRekt;



        public Projektile(/*List<Projektile> list, */Vector2f Startposition)
        {

            //if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            //{
            //   ProjektileInilization(new Vector2f(0, -1), Startposition);
            //}
            //if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            //{
            //    ProjektileInilization(new Vector2f(-1, 0), Startposition);
            //}
            //if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            //{
            //    ProjektileInilization(new Vector2f(0, 1), Startposition);
            //}
            //if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            //{
                ProjektileInilization(new Vector2f(1, 0), Startposition);
            //}
            RangeCounter = 0;
        }

        public void ProjektileInilization(Vector2f _direction, Vector2f startPosition )
        {
            Texture projectTexture = new Texture("pictures/bull.png");
            projektSprite = new Sprite(projectTexture);
            position = startPosition;
            direction = _direction;
            projektSprite.Position = position;
            projektSprite.Scale = new Vector2f(1, 1);
        }
        public void draw(RenderWindow win)
        {
            win.Draw(projektSprite);
    
        }
        public void update()
        {
            position = new Vector2f(position.X + (direction.X * speed), position.Y +( direction.Y * speed));
            projektSprite.Position = position;
            Console.WriteLine(" Ich bin upd to date");
        }
        public Sprite getSprite()
        {
            return projektSprite;
        }

        public float getRange()
        {
            return Range;
        }
   



    }
}
