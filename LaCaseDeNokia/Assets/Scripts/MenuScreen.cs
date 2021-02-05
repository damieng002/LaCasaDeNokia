using System.Collections;
using System.Collections.Generic;

public class MenuScreen : Screen
{
    private Sprite menuSprite = new MenuSprite(0,0);
    public override bool[,] BuildFrame()
    {
        bool[,] frame = new bool[84, 48];
        Utils.AddSpriteOnScreen(frame,menuSprite);
        return frame;
    }
}
