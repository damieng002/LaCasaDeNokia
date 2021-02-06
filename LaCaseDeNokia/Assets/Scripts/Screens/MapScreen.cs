using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScreen : Screen
{
    private List<Sprite> _mapCharacters = new List<Sprite>();
    private Sprite _background;

    public MapScreen(Sprite background, int nbThieves)
    {
        _background = background;
        for (int i = 0; i < nbThieves; i++)
        {
            _mapCharacters.Add(new ThiefIcon(-200,-200));
        }
    }
    public override bool[,] BuildFrame()
    {
        bool[,] screen = new bool[Display.WIDTH, Display.HEIGHT];
        Utils.AddSpriteOnScreen(screen,_background);
        for (int i = 0 ; i < _mapCharacters.Count; i++)
        {
            int width = GameManager.Instance.GetCrtLevel().MapWidth;
            int height = GameManager.Instance.GetCrtLevel().MapHeight;
            Position posWorld = GameManager.Instance.GetThiefWorldPosition(i);
            _mapCharacters[i].SetPosition(posWorld.X() / (width / Display.WIDTH), posWorld.Y() / (height / Display.HEIGHT));
            Utils.AddSpriteOnScreen(screen, _mapCharacters[i]);
        }
        return screen;
    }
}