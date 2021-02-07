using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNameScreen : Screen
{
    Sprite textLevel = new Text(7, 4, "LEVEL", true, false);
    private Sprite textNum;

    public LevelNameScreen(int levelNum)
    {
        String levelToString = levelNum.ToString();
        textNum = new Text((Display.WIDTH-21*levelToString.Length)/2, 22, levelToString, true, false);
    }
    public override bool[,] BuildFrame()
    {
        bool[,] screen = new bool[Display.WIDTH, Display.HEIGHT];
        Utils.AddSpriteOnScreen(screen, textLevel, false, 2);
        Utils.AddSpriteOnScreen(screen, textNum, false, 3);
        return screen;
    }
}
