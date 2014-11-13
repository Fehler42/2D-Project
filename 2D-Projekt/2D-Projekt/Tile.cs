using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Projekt
{
    class Tile
    {
        bool walkable;
        Sprite TileSprite;
        Vector2f position;
        FloatRect TileRect; 

        public Tile(bool _walkable, string texturepath, Vector2f _position)
        {
            walkable = _walkable ;
            TileSprite = new Sprite(new Texture(texturepath));
            TileSprite.Position = _position;

            position = _position;
            TileRect =  new FloatRect(position.X,position.Y, TileSprite.Texture.Size.X, TileSprite.Texture.Size.Y);
        }

        public void draw(RenderWindow win)
        {
            win.Draw(TileSprite);
        }


    }
}
