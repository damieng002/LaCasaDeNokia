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
        for (int i = 0 ; i < _mapCharacters.Count; i++)
        {
            int width = GameManager.Instance.GetCrtLevel().MapWidth;
            int height = GameManager.Instance.GetCrtLevel().MapHeight;
            Position posWorld = GameManager.Instance.GetThiefWorldPosition(i);
            _mapCharacters[i].SetPosition(posWorld.X() * (width / 84), posWorld.Y() * (height / 48));
            Utils.AddSpriteOnScreen(screen, _mapCharacters[i]);
        }
        return screen;
    }
}