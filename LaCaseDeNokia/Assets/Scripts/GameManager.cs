using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;

public class GameManager
{
    enum State
    {
        MENU,
        LEVEL
    }
    
    private int _nbOfThieves = 1;
    private int _nbOfCameras = 1;
    private Position[] _thievesPositions;
    private int _mapWidth;
    private int _mapHeight;
    private Position[] _waypoints;
    private Sprite _bgMap;
    private Sprite[] _bgCameras;
    private Display _displayRef;
    private State _state = State.MENU;

    private GameManager()
    {
        
    }

    public void LoadMenu()
    {
        _state = State.MENU;
        List<Screen> screens = new List<Screen>();
        screens.Add(new MenuScreen());
        _displayRef.SetScreens(screens);
    }

    public void LoadNewLevel(int nbOfThieves, int nbOfCameras, int mapWidth, int mapHeight, Position[] waypoints, Sprite bgMap, Sprite[] bgCameras)
    {
        _state = State.LEVEL;
        _nbOfThieves = nbOfThieves;
        _nbOfCameras = nbOfCameras;
        _waypoints = waypoints;
        _thievesPositions = new Position[nbOfThieves];
        _mapHeight = mapHeight;
        _mapWidth = mapWidth;
        _bgMap = bgMap;
        _bgCameras = bgCameras;
        List<Screen> screens = new List<Screen>();
        screens.Add(new MapScreen(bgMap));
    }

    public void KeyPressed(char key)
    {
        if (_state == State.MENU && key == '0')
        {
            LoadNewLevel(0, 0, 10, 10, new Position[0], new SampleSprite(0, 0), new Sprite[0]);
        }
    }
    
    public void SetDisplayRef(Display displayRef)
    {
        _displayRef = displayRef;
    }

    private static GameManager _instance = null;
    public static GameManager Instance
    {
        get { return _instance ?? (_instance = new GameManager()); }
    }
}
