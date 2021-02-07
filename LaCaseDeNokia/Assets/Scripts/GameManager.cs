using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class GameManager
{
    enum State
    {
        MENU,
        EXPLICATION,
        SHOW_LEVEL_NUM,
        LEVEL,
        GAMEOVER,
        WIN
    }
    
    private Position[] _thievesPositions;
    private bool[] _thievesDirection;
    private bool[] _thievesEnded;
    private int[] _thievesWaypoint;
    private Position[] _ratsPositions;
    private bool[] _camerasStates;
    private Display _displayRef;
    private State _state = State.MENU;
    private List<Level> levels = new List<Level>();
    private Level _crtLevel;
    private int _crtLevelIndex;
    private int _framesSinceLastThief = 0;
    private int _nbThievesOut = 0;
    private int _nbFrameSinceScreenLoaded = 0;
    private GameManager()
    {
        Level level1 = new Level(
            1, 
            1, 
            1,
            840, 
            480, 
            new Position[]{new Position(710, 280), new Position(170, 280)}, 
            new MapLevel1(0, 0), 
            new Sprite[] {new Cam1Level1(0,0)}, 
            new Position[] {new Position(380, 240)}, 
            new int[]{200},
            10,
            10);
        Level level2 = new Level(
            3, 
            1, 
            1,
            840, 
            480, 
            new Position[]{new Position(710, 280), new Position(170, 280)}, 
            new MapLevel1(0, 0), 
            new Sprite[] {new Cam1Level1(0,0)}, 
            new Position[] {new Position(380, 240)}, 
            new int[]{200},
            25,
            10);
        levels.Add(level1);
        levels.Add(level2);
    }

    public void LoadMenu()
    {
        _nbFrameSinceScreenLoaded = 0;
        _state = State.MENU;
        List<Screen> screens = new List<Screen>();
        screens.Add(new MenuScreen());
        _displayRef.SetScreens(screens);
    }

    public void LoadNewShowLevel(int index)
    {
        _nbFrameSinceScreenLoaded = 0;
        _crtLevelIndex = index;
        _state = State.SHOW_LEVEL_NUM;
        List<Screen> screens = new List<Screen>();
        screens.Add(new LevelNameScreen(index+1));
        _displayRef.SetScreens(screens);
        _displayRef.SetScreenToShow(0);
    }

    public void LoadNewLevel()
    {
        _nbFrameSinceScreenLoaded = 0;
        _crtLevel = levels[_crtLevelIndex];
        _state = State.LEVEL;
        _thievesPositions = new Position[_crtLevel.NbOfThieves];
        _thievesDirection = new bool[_crtLevel.NbOfThieves];
        _thievesEnded = new bool[_crtLevel.NbOfThieves];
        _thievesWaypoint = new int[_crtLevel.NbOfThieves];
        _ratsPositions = new Position[_crtLevel.NbOfRats];
        _camerasStates = Enumerable.Repeat(true, _crtLevel.NbOfCameras).ToArray();
        List<Screen> screens = new List<Screen>();
        screens.Add(new MapScreen(_crtLevel.BgMap,_crtLevel.NbOfThieves));
        for (int i = 0; i < _crtLevel.NbOfCameras; i++)
        {
            screens.Add(new CameraScreen(_crtLevel.CamerasPosition[i].X(),_crtLevel.CamerasPosition[i].Y(),_crtLevel.CamerasWidth[i],_crtLevel.BgCameras[i], i, _crtLevel.NbOfThieves));
        }
        
        _displayRef.SetScreens(screens);
        _framesSinceLastThief = 0;
        _nbThievesOut = 0;
    }

    public void LoadLoose()
    {
        _nbFrameSinceScreenLoaded = 0;
        _displayRef.PlaySound("police");
        _state = State.GAMEOVER;
        List<Screen> screens = new List<Screen>();
        screens.Add(new GameOverScreen());
        _displayRef.SetScreens(screens);
    }
    
    public void LoadWin()
    {
        _nbFrameSinceScreenLoaded = 0;
        _state = State.WIN;
        List<Screen> screens = new List<Screen>();
        screens.Add(new GameOverScreen());
        _displayRef.SetScreens(screens);
    }

    public void KeyPressed(char key)
    {
        if (_state == State.MENU && key == '0'){LoadNewShowLevel(0);}
        if (_state == State.GAMEOVER && key == '0' && _nbFrameSinceScreenLoaded>4){LoadMenu();}
        if (_state == State.LEVEL)
        {
            if (key == '*') _displayRef.SetScreenToShow(0);
            else
            {
                int cameraNo = int.Parse(key.ToString());
                if (cameraNo == 0)
                {
                    if (_displayRef.ScreenToShow > 0)
                    {
                        _camerasStates[_displayRef.ScreenToShow - 1]^=true;
                        _displayRef.PlaySound("bip");
                    }
                }
                else if (cameraNo <= _crtLevel.NbOfCameras)
                {
                    _displayRef.SetScreenToShow(cameraNo);
                }
            }
        }
    }

    public Position GetThiefWorldPosition(int index)
    {
        if (_thievesPositions[index]==null) return new Position(-200, -200);
        return _thievesPositions[index];
    }
    
    public Position GetRatWorldPosition(int index)
    {
        return _ratsPositions[index];
    }
    
    public bool GetCameraState(int index)
    {
        return _camerasStates[index];
    }

    public Level GetCrtLevel()
    {
        return _crtLevel;
    }
    
    public void SetDisplayRef(Display displayRef)
    {
        _displayRef = displayRef;
    }

    public void NextFrame()
    {
        _nbFrameSinceScreenLoaded++;
        if (_state == State.SHOW_LEVEL_NUM)
        {
            if(_nbFrameSinceScreenLoaded>4) LoadNewLevel();
        }
        if (_state == State.LEVEL)
        {
            _framesSinceLastThief++;
            if (_thievesEnded.All(x => x))
            {
                if (_crtLevelIndex <= levels.Count - 1) LoadNewShowLevel(_crtLevelIndex + 1);
                else LoadWin();
            }
            for (int i = 0; i < _nbThievesOut; i++)
            {
                if (_thievesEnded[i]) continue;
                int distance = (int)(Utils.Distance(_thievesPositions[i], _crtLevel.Waypoints[_thievesWaypoint[i]]));
                if (distance <= _crtLevel.ThievesSpeed)
                {
                    if (!_thievesDirection[i]) // begin
                    {
                        _thievesPositions[i] = _crtLevel.Waypoints[_thievesWaypoint[i]];
                        if (_crtLevel.Waypoints.Length > _thievesWaypoint[i] + 1)
                        {
                            _thievesWaypoint[i]++;
                        }
                        else
                        {
                            _thievesWaypoint[i]--;
                            _thievesDirection[i] = true;
                        }
                    }
                    else // went back from bank
                    {
                        _thievesPositions[i] = _crtLevel.Waypoints[_thievesWaypoint[i]];
                        if (_thievesWaypoint[i]>0)
                        {
                            _thievesWaypoint[i]--;
                        }
                        else
                        {
                            _thievesEnded[i] = true;
                        }
                    }
                }
                else
                {
                    Vector2 v = new Vector2(_crtLevel.Waypoints[_thievesWaypoint[i]].X() - _thievesPositions[i].X(),
                        _crtLevel.Waypoints[_thievesWaypoint[i]].Y() - _thievesPositions[i].Y());
                    v = System.Numerics.Vector2.Normalize(v);
                    _thievesPositions[i].UpdatePosition((int)(_thievesPositions[i].X()+v.X*_crtLevel.ThievesSpeed),(int)(_thievesPositions[i].Y()+v.Y*_crtLevel.ThievesSpeed));
                }
            }
            if (_nbThievesOut == 0 || (_nbThievesOut < _crtLevel.NbOfThieves &&
                                       _framesSinceLastThief >= _crtLevel.FramesBetweenThieves))
            {
                _framesSinceLastThief = 0;
                int newId = _nbThievesOut++;
                _thievesDirection[newId] = false;
                _thievesWaypoint[newId] = 1;
                _thievesPositions[newId] = _crtLevel.Waypoints[0].Copy();
            }
        }
    }

    private static GameManager _instance = null;
    public static GameManager Instance
    {
        get { return _instance ?? (_instance = new GameManager()); }
    }
}
