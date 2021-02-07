namespace DefaultNamespace
{
    public class WinScreen: Screen
    {
        private Sprite winSprite = new WinSprite(0,0);
        private Sprite thief1 = new Thief(10, Display.HEIGHT - 9);
        private Sprite thief2 = new Thief(40, Display.HEIGHT - 9);
        private Sprite thief3 = new Thief(65, Display.HEIGHT - 9);
        public override bool[,] BuildFrame()
        {
            bool[,] frame = new bool[Display.WIDTH, Display.HEIGHT];
            Utils.AddSpriteOnScreen(frame,winSprite);
            Utils.AddSpriteOnScreen(frame,thief1);
            Utils.AddSpriteOnScreen(frame,thief2);
            Utils.AddSpriteOnScreen(frame,thief3);
            return frame;
        }
    }
}