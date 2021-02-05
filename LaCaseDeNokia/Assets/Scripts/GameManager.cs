using System.Collections;
using System.Collections.Generic;

public class GameManager
{
    enum State
    {
        MENU,
        LEVEL
    }
    
    private Position[] _thievesPositions;
    private Position[] _ratsPositions;
    private Display _displayRef;
    private State _state = State.MENU;
    private List<Level> levels = new List<Level>();
    private Level _crtLevel;
    
    private GameManager()
    {
        Position[] waypoints = {new Position(710, 280), new Position(170, 280)};
        Position[] cameraPosition = {new Position(220, 380)};
        Level level = new Level(
            1, 
            1, 
            1,
            840, 
            480, 
            waypoints, 
            new MapLevel1(0, 0), 
            new Sprite[0], 
            cameraPosition, 
            new int[]{15});
        levels.Add(level);
    }

    public void LoadMenu()
    {
        _state = State.MENU;
        List<Screen> screens = new List<Screen>();
        screens.Add(new MenuScreen());
        _displayRef.SetScreens(screens);
    }

    public void LoadNewLevel(int index)
    {
        _crtLevel = levels[index];
        _state = State.LEVEL;
        _thievesPositions = new Position[_crtLevel.NbOfThieves];
        _thievesPositions = new Position[_crtLevel.NbOfRats];
        List<Screen> screens = new List<Screen>();
        screens.Add(new MapScreen(_crtLevel.BgMap));
        _displayRef.SetScreens(screens);
    }

    public void KeyPressed(char key)
    {
        if (_state == State.MENU && key == '0')
        {
            LoadNewLevel(0);
        }
    }

    public Position GetThiefWorldPosition(int index)
    {
        return _thievesPositions[index];
    }
    
    public Position GetRatWorldPosition(int index)
    {
        return _ratsPositions[index];
    }

    public Level GetCrtLevel()
    {
        return _crtLevel;
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
