namespace DefaultNamespace
{
    public class GameOverScreen: Screen
    {
        private Sprite gameOverSprite = new GameOver(0,0);
        public override bool[,] BuildFrame()
        {
            bool[,] frame = new bool[84, 48];
            Utils.AddSpriteOnScreen(frame,gameOverSprite);
            return frame;
        }
    }
}