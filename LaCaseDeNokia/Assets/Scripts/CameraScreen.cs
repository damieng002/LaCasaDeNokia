using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class CameraScreen: Screen
{
    private int _index;
    private List<Sprite> characters = new List<Sprite>();
    private Sprite _background;
    private bool _state = true;
    private readonly int _positionX;
    private readonly int _positionY;
    private readonly int _width;
    private readonly int _height;
    private Random r = new Random();
    private int timerOffline = 0;
    private readonly int _gameOverTime = 10;

    public CameraScreen(int x, int y, int width, Sprite bg, int index, int nbThieves)
    {
        _positionX = x;
        _positionY = y;
        _width = width;
        _height = width / (84 / 48);
        _background = bg;
        _index = index;
        for (int i = 0; i < nbThieves; i++)
        {
            characters.Add(new Thief(-200,-200));
        }
    }

    private bool ThiefIsHere()
    {
        return characters.Any(character => character is Thief && PositionIsInCamera(character.getX(), character.getX()));
    }

    public override bool[,] BuildFrame()
    {
        bool[,] screen = new bool[84, 48];
        if (GameManager.Instance.GetCameraState(_index))
        {
            timerOffline = 0;
            Utils.AddSpriteOnScreen(screen,_background);
            for (int i = 0 ; i < characters.Count; i++)
            {
                Position cameraPos = GameManager.Instance.GetCrtLevel().CamerasPosition[_index];
                int cameraWidth = GameManager.Instance.GetCrtLevel().CamerasWidth[_index];
                Position posWorld = GameManager.Instance.GetThiefWorldPosition(i);
                Debug.Log((posWorld.X()-cameraPos.X())/(cameraWidth/84)+" , "+(posWorld.Y()-cameraPos.Y())/(cameraWidth/84));
                characters[i].SetPosition(
                    (posWorld.X()-cameraPos.X())/(cameraWidth/84), 
                    (posWorld.Y()-cameraPos.Y())/(cameraWidth/84));
                Utils.AddSpriteOnScreen(screen, characters[i]);
            }
        }
        else
        {
            timerOffline++;
            if (timerOffline > _gameOverTime)
            {
                //GameManager.Instance.Loose();
            }
            for (int x = 0; x < 84; x++)
            {
                for (int y = 0; y < 48; y++)
                {
                    screen[x, y] = r.NextDouble() > 0.5;
                }
            }
            //Utils.AddSpriteOnScreen(screen, characters[i]);
        }
        return screen;
    }

    private bool PositionIsInCamera(int x, int y)
    {
        return (x > _positionX && x < _positionX + _width && y > _positionY && y < _positionY + _height);
    }
}
