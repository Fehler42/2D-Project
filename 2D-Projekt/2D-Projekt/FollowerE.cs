using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Projekt
{
    class FollowerE
    {
        // Variablen
        Sprite enemySprite = new Sprite();
        Vector2f position;
        public int life = 3;


        // Constructor
        public FollowerE(int x , int y)
        {
            Texture playerTexture = new Texture("pictures/follower.png");
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

        // calculates next step to player (ignores walls)
        public void update(Vector2f destination)
        {
            float n =(float) Math.Sqrt((destination.X- position.X) *(destination.X- position.X) + (destination.Y- position.Y) *(destination.Y- position.Y));

            position = new Vector2f (position.X + (destination.X- position.X)/n , position.Y + (destination.Y- position.Y)/n );
            enemySprite.Position = position;
        }
        // Getter Funktionen 
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
    }
}
