namespace DefaultNamespace
{
    public class GameOverScreen: Screen
    {
        private Sprite gameOverSprite = new GameOver(0,0);
        private Sprite policeman0 = new PoliceStandUp(25, Display.HEIGHT - 11);
        private Sprite policeman1 = new PoliceStandUp(39, Display.HEIGHT - 11);
        private Sprite rat = new Rat(63, Display.HEIGHT -9);
        public override bool[,] BuildFrame()
        {
            bool[,] frame = new bool[Display.WIDTH, Display.HEIGHT];
            Utils.AddSpriteOnScreen(frame,gameOverSprite);
            Utils.AddSpriteOnScreen(frame,policeman0);
            Utils.AddSpriteOnScreen(frame,policeman1);
            Utils.AddSpriteOnScreen(frame,rat,true);
            return frame;
        }
    }
}