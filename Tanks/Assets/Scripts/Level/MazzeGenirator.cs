using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGineratorCell
{
    public int X;
    public int Y;    

    public bool Visited;
}

public class MazzeGenirator
{

    public int Witsth;
    public int Height;
   

    public MazeGineratorCell[,] GinerateMaze(int t,int r)
    {
        Witsth = t;
        Height = r;
    MazeGineratorCell[,] maze = new MazeGineratorCell[Witsth, Height];


       for (int x = 0; x < maze.GetLength(0); x ++)
            {
            for (int y = 0; y < maze.GetLength(1); y++)
            {               
                    maze[x, y] = new MazeGineratorCell { X = x, Y = y };
                
            }
            }        
        return maze;
    }  
}
