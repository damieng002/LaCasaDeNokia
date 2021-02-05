using System.Collections;
using System.Collections.Generic;

public class MapScreen : Screen
{
    private List<Sprite> _mapCharacters = new List<Sprite>();
    private Sprite _background;

    public MapScreen(Sprite background)
    {
        _background = background;
    }
    public override bool[,] BuildFrame()
    {
        bool[,] screen = new bool[84, 48];
        Utils.AddSpriteOnScreen(screen,_background);
        foreach (var character in _mapCharacters)
        {
            Utils.AddSpriteOnScreen(screen,character);
        }
        return screen;
    }
}