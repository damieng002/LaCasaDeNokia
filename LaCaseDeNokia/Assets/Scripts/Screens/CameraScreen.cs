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
    private readonly int _gameOverTime = 12;

    public CameraScreen(int x, int y, int width, Sprite bg, int index, int nbThieves)
    {
        _positionX = x;
        _positionY = y;
        _width = width;
        _height = width / (Display.WIDTH / Display.HEIGHT);
        _background = bg;
        _index = index;
        for (int i = 0; i < nbThieves; i++)
        {
            characters.Add(new Thief(-200,-200));
        }
    }

    private bool ThiefIsHere()
    {
        return characters.Any(character => character is Thief && PositionIsInCamera(character.getX(), character.getY()));
    }

    public override bool[,] BuildFrame()
    {
        bool[,] screen = new bool[Display.WIDTH, Display.HEIGHT];
        // Update thieves positions
        for (int i = 0 ; i < characters.Count; i++)
        {
            Position cameraPos = GameManager.Instance.GetCrtLevel().CamerasPosition[_index];
            int cameraWidth = GameManager.Instance.GetCrtLevel().CamerasWidth[_index];
            Position posWorld = GameManager.Instance.GetThiefWorldPosition(i);
            characters[i].SetPosition(
                (posWorld.X()-cameraPos.X())/(cameraWidth/Display.WIDTH), 
                (posWorld.Y()-cameraPos.Y())/(cameraWidth/Display.WIDTH));
        }
        
        if (GameManager.Instance.GetCameraState(_index))
        {
            if (ThiefIsHere())
            {
                GameManager.Instance.LoadLoose();
            }
            timerOffline = 0;
            Utils.AddSpriteOnScreen(screen,_background);
            foreach (var character in characters)
            {
                Utils.AddSpriteOnScreen(screen, character);
            }
        }
        else
        {
            if (!ThiefIsHere()) timerOffline++;
            if (ThiefIsHere()) timerOffline = 0;
            if (timerOffline > _gameOverTime)
            {
                GameManager.Instance.LoadLoose();
            }
            for (int x = 0; x < Display.WIDTH; x++)
            {
                for (int y = 0; y < Display.HEIGHT; y++)
                {
                    screen[x, y] = r.NextDouble() > 0.5;
                }
            }
            Utils.AddSpriteOnScreen(screen, new OffCam(0,0));
        }
        return screen;
    }

    private bool PositionIsInCamera(int x, int y)
    {
        return (x > 0 && x < Display.WIDTH  && y > 0 && y < Display.HEIGHT);
    }
}
