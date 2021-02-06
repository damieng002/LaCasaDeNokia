using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

public abstract class Sprite
{
    protected Sprite(int x, int y)
    {
        _x = x;
        _y = y;
    }
    public enum Colors
    {
        Light,
        Dark,
        Transparent
    }
    
    private int _x;
    private int _y;

    public void SetPosition(int x, int y)
    {
        _x = x;
        _y = y;
    }
    public int getX() { return _x; }
    public int getY() { return _y; }

    public abstract Colors[,] GetSpriteArray();
}
