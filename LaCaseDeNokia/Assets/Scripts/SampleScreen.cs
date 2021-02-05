using System;
using System.Collections;
using System.Collections.Generic;

public class SampleScreen : Screen
{
    private Random r = new Random();
    public override bool[,] BuildFrame()
    {
        bool[,] frame = new bool[84, 48];
        for (int x = 0; x < 84; x++)
        {
            for (int y = 0; y < 48; y++)
            {
                frame[x, y] = false;//r.NextDouble() > 0.5;
            }
        }
        Utils.AddSpriteOnScreen(frame,new SampleSprite(0,0));

        return frame;
    }
}
