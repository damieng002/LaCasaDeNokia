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
                tmp[x, y] = input[input.GetLength(0) - x, y];
            }
        }

        return tmp;
    }
}
