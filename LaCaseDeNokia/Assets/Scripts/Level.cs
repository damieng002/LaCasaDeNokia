using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class Level
{
    private int _nbOfThieves = 1;
    private int _nbOfCameras = 1;
    private int _nbOfRats = 1;
    private int _mapWidth;
    private int _mapHeight;
    private Position[] _waypoints;
    private Sprite _bgMap;
    private Sprite[] _bgCameras;
    private Position[] _camerasPosition;
    private int[] _camerasWidth;

    public Level(int nbOfThieves, int nbOfCameras, int nbOfRats, int mapWidth, int mapHeight, Position[] waypoints, Sprite bgMap, Sprite[] bgCameras, Position[] camerasPosition, int[] camerasWidth)
    {
        _nbOfThieves = nbOfThieves;
        _nbOfCameras = nbOfCameras;
        _nbOfRats = nbOfRats;
        _mapWidth = mapWidth;
        _mapHeight = mapHeight;
        _waypoints = waypoints;
        _bgMap = bgMap;
        _bgCameras = bgCameras;
        _camerasPosition = camerasPosition;
        _camerasWidth = camerasWidth;
    }

    public int NbOfThieves => _nbOfThieves;
    public int NbOfCameras => _nbOfCameras;
    public int NbOfRats => _nbOfRats;

    public int MapWidth => _mapWidth;
    public int MapHeight => _mapHeight;
    public Position[] Waypoints => _waypoints;
    public Sprite BgMap => _bgMap;
    public Sprite[] BgCameras => _bgCameras;

    public Position[] CamerasPosition => _camerasPosition;
    public int[] CamerasWidth => _camerasWidth;
}
