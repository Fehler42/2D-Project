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

        // Felder für die Felderstellung 
        Tile[,] mapTiles;
        int[,] tileKind;


        // Prüffunktion für die Betretbarkeit eines Feldes
        public bool isWalkable(int i, int j)
        {
                if (tileKind[i, j] == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }

        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        // Erstellen von Maps  (Maperstellung wird unter der Klasse erklärt
        public Map(int mapkind)
        {
            if (mapkind == 1)
            {
                //                        1,2,3,4,5,6,7,8,9,10,11,12
                tileKind = new int[,]   {{1,1,1,1,1,1,1,1,1,1,1,1},//1
                                         {1,0,0,0,0,0,0,0,0,0,0,1}, //2
                                         {1,0,0,0,0,0,0,0,0,0,0,1},//3
                                         {1,0,0,0,0,0,0,0,0,0,0,1},//4
                                         {1,0,0,0,0,0,0,0,0,0,0,1},//5
                                         {1,0,0,0,0,0,0,0,0,0,0,1},//6
                                         {1,0,0,0,0,0,0,0,0,0,0,1},//7
                                         {1,0,0,0,0,0,0,0,0,0,0,1},//8
                                         {1,0,0,0,0,0,0,0,0,0,0,1},//9
                                         {1,0,0,0,0,0,0,0,0,0,0,1},//10
                                         {1,0,0,0,0,0,0,0,0,0,0,1},//11
                                         {1,0,0,0,0,0,0,0,0,0,0,1},//12
                                         {1,0,0,0,0,0,0,0,0,0,0,1},//13
                                         {1,0,0,0,0,0,0,0,0,0,0,1},//14
                                         {1,0,0,0,0,0,0,0,0,0,0,1},//15
                                         {1,1,1,1,1,1,1,1,1,1,1,1}};//16
            }

            if (mapkind == 2)
            {
                //                        1,2,3,4,5,6,7,8,9,10,11,12
                tileKind = new int[,]   {{1,1,1,1,1,1,1,1,1,1,1,1},//1
                                         {1,0,0,0,0,0,0,0,0,0,0,1}, //2
                                         {1,0,0,0,0,1,1,0,0,0,0,1},//3
                                         {1,0,1,1,0,1,1,0,0,0,0,1},//4
                                         {1,0,0,0,0,1,1,0,0,0,0,1},//5
                                         {1,0,0,0,0,1,1,0,1,1,0,1},//6
                                         {1,0,0,0,0,1,1,0,0,0,0,1},//7
                                         {1,0,0,0,0,0,0,0,0,0,0,1},//8
                                         {1,0,0,0,0,0,0,0,0,0,0,1},//9
                                         {1,0,0,0,0,1,1,0,0,0,0,1},//10
                                         {1,0,0,0,0,1,1,0,1,1,0,1},//11
                                         {1,0,0,0,0,1,1,0,0,0,0,1},//12
                                         {1,0,1,1,0,1,1,0,0,0,0,1},//13
                                         {1,0,0,0,0,1,1,0,0,0,0,1},//14
                                         {1,0,0,0,0,0,0,0,0,0,0,1},//15
                                         {1,1,1,1,1,1,1,1,1,1,1,1}};//16
            }

            if (mapkind == 3)
            {
                //                        1,2,3,4,5,6,7,8,9,10,11,12
                tileKind = new int[,]   {{1,1,1,1,1,1,1,1,1,1,1,1},//1
                                         {1,0,0,0,0,0,0,0,0,0,0,1}, //2
                                         {1,0,1,1,0,1,1,0,1,1,0,1},//3
                                         {1,0,1,1,0,1,1,0,1,1,0,1},//4
                                         {1,0,0,0,0,0,0,0,0,0,0,1},//5
                                         {1,0,1,1,0,1,1,0,1,1,0,1},//6
                                         {1,0,1,1,0,1,1,0,1,1,0,1},//7
                                         {1,0,0,0,0,0,0,0,0,0,0,1},//8
                                         {1,0,0,0,0,0,0,0,0,0,0,1},//9
                                         {1,0,1,1,0,1,1,0,1,1,0,1},//10
                                         {1,0,1,1,0,1,1,0,1,1,0,1},//11
                                         {1,0,0,0,0,0,0,0,0,0,0,1},//12
                                         {1,0,1,1,0,1,1,0,1,1,0,1},//13
                                         {1,0,1,1,0,1,1,0,1,1,0,1},//14
                                         {1,0,0,0,0,0,0,0,0,0,0,1},//15
                                         {1,1,1,1,1,1,1,1,1,1,1,1}};//16
            }
            //erstellt eine Tilemap,die die gleiche Größe hat wie obige Felder
            mapTiles = new Tile[tileKind.GetLength(0), tileKind.GetLength(1)];
            // weist den Tiles Sprites zu 
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

        // Ende der Funktion
        //================================================================================================
        //================================================================================================

        // Zeichnet alle Tiles der Map
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

        // Ende der Funktion
        //================================================================================================
        //================================================================================================
    }
}

/*******************************************************************************
 * Leitfaden zur Maperstellung
 * ---------------------------
 * 
 * 
            if (mapkind == 3)
            {
                //                        1,2,3,4,5,6,7,8,9,10,11,12
                tileKind = new int[,]   {{1,1,1,1,1,1,1,1,1,1,1,1},//1
                                         {1,0,0,0,0,0,0,0,0,0,0,1}, //2
                                         {1,0,1,1,0,1,1,0,1,1,0,1},//3
                                         {1,0,1,1,0,1,1,0,1,1,0,1},//4
                                         {1,0,0,0,0,0,0,0,0,0,0,1},//5
                                         {1,0,1,1,0,1,1,0,1,1,0,1},//6
                                         {1,0,1,1,0,1,1,0,1,1,0,1},//7
                                         {1,0,0,0,0,X,X,0,0,0,0,1},//8
                                         {1,0,0,0,0,X,X,0,0,0,0,1},//9
                                         {1,0,1,1,0,1,1,0,1,1,0,1},//10
                                         {1,0,1,1,0,1,1,0,1,1,0,1},//11
                                         {1,0,0,0,0,0,0,0,0,0,0,1},//12
                                         {1,0,1,1,0,1,1,0,1,1,0,1},//13
                                         {1,0,1,1,0,1,1,0,1,1,0,1},//14
                                         {1,0,0,0,0,0,0,0,0,0,0,1},//15
                                         {1,1,1,1,1,1,1,1,1,1,1,1}};//16
            }

 * Regeln zur Maperstellung :
 * 
 * mapkind -> Nummer die der Map zum Aufruf zugewiesen wird 
 * die Kommentierten Zahlen  sind für die bessere Übersicht 
 * die Felder [6,8] [7,8] [6,9] [7,9] sollen bei jeder Map frei bleiben um Fortschritt zu gewährleisten mit X gekennzeichnet 
 * der äußere Rand soll mit einsen belegt bleiben um ausbrechen des Spielers zu verhindern 
 *  ------------------------------------------------------------------------------------------
 *  
 * Implementierung:
 * mapKind um einen erhöhen im Verhältnis zum Vorgänger 
 * im mainProgramm in der loadNextLevel() Funktion
 * int mapvoting = Rnd.Next(1, X);  den Wert X auf einen höher als das höchste Mapkind setzen 
********************************************************************************/