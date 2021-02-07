using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static Sprite.Colors[,] FlipX(Sprite.Colors[,] input)
    {
        Sprite.Colors[,] tmp = new Sprite.Colors[input.GetLength(0), input.GetLength(1)];
        for (int x = 0; x < input.GetLength(0); x++)
        {
            for (int y = 0; y < input.GetLength(1); y++)
            {
                tmp[x, y] = input[input.GetLength(0) - x-1, y];
            }
        }

        return tmp;
    }
    
    public static Sprite.Colors[,] Scale(Sprite.Colors[,] input, int factor)
    {
        Sprite.Colors[,] tmp = new Sprite.Colors[input.GetLength(0)*factor, input.GetLength(1)*factor];
        for (int x = 0; x < input.GetLength(0); x++)
        {
            for (int y = 0; y < input.GetLength(1); y++)
            {
                for (int xscale = 0; xscale < factor; xscale++)
                {
                    for (int yscale = 0; yscale < factor; yscale++)
                    {
                        tmp[x*factor+xscale, y*factor+yscale] = input[x, y];
                    }    
                }
                
            }
        }

        return tmp;
    }

    public static void AddSpriteOnScreen(bool[,] input, Sprite sprite,bool flipX=false, int scale=1)
    {
        Sprite.Colors[,] spriteArray = sprite.GetSpriteArray();
        if (flipX) spriteArray = Utils.FlipX(spriteArray);
        if (scale > 1) spriteArray = Utils.Scale(spriteArray, scale);
        for(int x=0; x<spriteArray.GetLength(0);x++)
        {
            for(int y=0; y<spriteArray.GetLength(1);y++)
            {
                if (spriteArray[x,y]!=Sprite.Colors.Transparent 
                    && x + sprite.getX() >= 0 
                    && x + sprite.getX() < input.GetLength(0)
                    && y + sprite.getY() >= 0 
                    && y + sprite.getY() < input.GetLength(1))
                {
                    input[x + sprite.getX(), y + sprite.getY()] = spriteArray[x, y] == Sprite.Colors.Dark;
                }
            }
        }
    }

    public static double Distance(Position a, Position b)
    {
        return Math.Sqrt(Math.Pow((b.X() - a.X()), 2) + Math.Pow((b.Y() - a.Y()), 2));
    }
}

