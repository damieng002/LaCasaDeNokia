using System.Collections;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class ThiefIcon:Sprite
    {
        private static Colors t = Colors.Transparent;
        private static Colors d = Colors.Dark;
        private static Colors l = Colors.Light;

        Colors[,] spriteArray = new Colors[,] {{d,d,d}
,{d,d,t}
};

        public ThiefIcon(int x, int y) : base(x, y)
        {
        }

        public override Colors[,] GetSpriteArray(){
            return spriteArray;
        }
    }
    