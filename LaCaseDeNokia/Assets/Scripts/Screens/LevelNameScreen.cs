using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNameScreen : Screen
{
    Sprite textLevel = new Text(7, 4, "LEVEL", true, false);
    private Sprite thief1 = new Thief(10, Display.HEIGHT - 18);
    private Sprite thief2 = new Thief(59, Display.HEIGHT - 18);
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
        Utils.AddSpriteOnScreen(screen, thief1, false,2);
        Utils.AddSpriteOnScreen(screen, thief2, true,2);
        return screen;
    }
}
