﻿using SFML.Graphics;
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


        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        // Constructor
        public FollowerE(int x , int y)
        {
            Texture enemyTexture = new Texture("pictures/follower.png");
            enemySprite = new Sprite(enemyTexture);
            position = new Vector2f(x, y);
            enemySprite.Position = position;
            enemySprite.Scale = new Vector2f(0.5f, 0.5f);
        }

        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        // draw
        public void draw(RenderWindow win)
        {
            win.Draw(enemySprite);
        }

        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        // Berechnet den direkten Weg zum Player ( Wände werden ignoriert)
        public void update(Vector2f destination , Map map)
        {
            //Skalar das den Vektor auf die Länge 1 kürzen kann
            float n =(float) Math.Sqrt((destination.X- position.X) *(destination.X- position.X) + (destination.Y- position.Y) *(destination.Y- position.Y));
            // Versetzt den Sprite 
            position = new Vector2f (position.X + (destination.X- position.X)/n , position.Y + (destination.Y- position.Y)/n );
            //  Spritepositionsupdate
            enemySprite.Position = position;
        }

        // Ende der Funktion
        //================================================================================================
        //================================================================================================
        public List<Projektile> shoot(List<Projektile> list , Vector2f t)
        {
            return list;
        }
        // Ende der Funktion
        //================================================================================================
        //================================================================================================

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

        // Ende der Getterfunktionen
        //================================================================================================
        //================================================================================================
    }
}
