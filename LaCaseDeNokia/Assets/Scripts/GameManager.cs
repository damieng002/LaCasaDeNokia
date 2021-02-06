using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using DefaultNamespace;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class GameManager
{
    enum State
    {
        MENU,
        LEVEL,
        GAMEOVER
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
    private int _framesSinceLastThief = 0;
    private int _nbThievesOut = 0;
    private GameManager()
    {
        Position[] waypoints = {new Position(710, 280), new Position(170, 280)};
        Position[] cameraPosition = {new Position(380, 240)};
        Level level = new Level(
            1, 
            1, 
            1,
            840, 
            480, 
            waypoints, 
            new MapLevel1(0, 0), 
            new Sprite[] {new Cam1Level1(0,0)}, 
            cameraPosition, 
            new int[]{200},
            10,
            10);
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
        _displayRef.PlaySound("police");
        _state = State.GAMEOVER;
        List<Screen> screens = new List<Screen>();
        screens.Add(new GameOverScreen());
        _displayRef.SetScreens(screens);
    }

    public void KeyPressed(char key)
    {
        if (_state == State.MENU && key == '0'){LoadNewLevel(0);}
        if (_state == State.GAMEOVER && key == '0'){LoadMenu();}
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
        if (_state == State.LEVEL)
        {
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
