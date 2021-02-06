using System.Collections;
using System.Collections.Generic;

public class MenuScreen : Screen
{
    private Sprite menuSprite = new MenuSprite(0,0);
    private Sprite thief = new ThiefIcon(70, 39);
    private bool thiefDirectionRight = false;
    public override bool[,] BuildFrame()
    {
        if (thiefDirectionRight)thief.SetPosition(thief.getX()+1,thief.getY());
        else thief.SetPosition(thief.getX()-1,thief.getY());
        if (!thiefDirectionRight && thief.getX() < 16) thiefDirectionRight = true;
        if (thiefDirectionRight && thief.getX() > 70) thiefDirectionRight = false;
        bool[,] frame = new bool[Display.WIDTH, Display.HEIGHT];
        Utils.AddSpriteOnScreen(frame,menuSprite);
        Utils.AddSpriteOnScreen(frame,thief,!thiefDirectionRight);
        return frame;
    }
}
