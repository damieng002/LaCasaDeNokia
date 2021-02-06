using System.Collections;
using System.Collections.Generic;

public class Position
{
    private int _x;
    private int _y;
    public Position(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public void UpdatePosition(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public int X()
    {
        return _x;}

    public int Y()
    {
        return _y;
    }

    public Position Copy()
    {
        return new Position(_x, _y);
    }

}
