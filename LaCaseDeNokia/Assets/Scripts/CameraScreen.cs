using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Compilation;
using UnityEngine;

public class CameraScreen: Screen
{
    private List<Character> characters = new List<Character>();
    private Sprite _bgMap;
    private bool _state = true;
    private readonly int _positionX;
    private readonly int _positionY;
    private readonly int _width;
    private readonly int _height;

    protected CameraScreen(int x, int y, int width, Sprite bg)
    {
        _positionX = x;
        _positionY = y;
        _width = width;
        _height = width / (84 / 48);
        _bgMap = bg;
    }

    private bool ChangeState()
    {
        _state = !_state;
        return _state;
    }
    
    private bool ThiefIsHere()
    {
        return characters.Any(character => character is Thief && PositionIsInCamera(character.getX(), character.getX()));
    }

    public override bool[,] BuildFrame()
    {
        throw new System.NotImplementedException();
    }

    private bool PositionIsInCamera(int x, int y)
    {
        return (x > _positionX && x < _positionX + _width && y > _positionY && y < _positionY + _height);
    }
}
