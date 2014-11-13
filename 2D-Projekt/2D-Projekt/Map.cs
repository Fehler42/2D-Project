using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Projekt
{
    class Map
    {
        Tile[,] mapTiles;
        int[,] tileKind;

        public bool isWalkable(int i, int j)
        {
            if (tileKind[i, j] == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Map()
        {
            tileKind = new int[,] {{1,1,1,1,1,1,1,1,1,1,1,1},
                             {1,0,0,0,0,0,0,0,0,0,0,1},
                             {1,0,0,0,0,0,0,0,0,0,0,1},
                             {1,0,0,0,0,0,0,0,0,0,0,1},
                             {1,0,0,0,0,0,0,0,0,0,0,1},
                             {1,0,0,0,0,0,0,0,0,0,0,1},
                             {1,0,0,0,0,0,0,0,0,0,0,1},
                             {1,0,0,0,0,0,0,0,0,0,0,1},
                             {1,0,0,0,0,0,0,0,0,0,0,1},
                             {1,0,0,0,0,0,0,0,0,0,0,1},
                             {1,0,0,0,0,0,0,0,0,0,0,1},
                             {1,0,0,0,0,0,0,0,0,0,0,1},
                             {1,0,0,0,0,0,0,0,0,0,0,1},
                             {1,0,0,0,0,0,0,0,0,0,0,1},
                             {1,0,0,0,0,0,0,0,0,0,0,1},
                             {1,1,1,1,1,1,1,1,1,1,1,1}};
            mapTiles = new Tile[tileKind.GetLength(0), tileKind.GetLength(1)];
            for (int i = 0; i < mapTiles.GetLength(0); i++)
            {
                for (int j = 0; j < mapTiles.GetLength(1); j++)
                {
                    if (tileKind[i, j] == 0)
                    {
                        mapTiles[i, j] = new Tile(true, "pictures/free.png", new Vector2f((float)(50 * i), (float)(50 * j)));
                    }
                    else
                    {
                        mapTiles[i, j] = new Tile(true, "pictures/ground.png", new Vector2f((float)(50 * i), (float)(50 * j)));
                    }
                }
            }
        }

        public void draw(RenderWindow win)
        {
            for (int i = 0; i < tileKind.GetLength(0); i++)
            {
                for (int j = 0; j < tileKind.GetLength(1); j++)
                {
                    mapTiles[i, j].draw(win);
                }
            }

        }
    }
}
