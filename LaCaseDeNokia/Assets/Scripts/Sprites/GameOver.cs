using System.Collections;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class GameOver:Sprite
    {
        private static Colors t = Colors.Transparent;
        private static Colors d = Colors.Dark;
        private static Colors l = Colors.Light;

        Colors[,] spriteArray = new Colors[,] {{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,d,d,d,d,d,d,l,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,d,d,d,d,d,d,l,d,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,d,l,d,d,l,d,l,d,d,d,d,d,d,d,d,d,d,d,d,d,d,d,d,d}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,d,l,l,l,l,d,l,d,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,d,l,d,d,d,d,l,d,l,l,l,l,l,l,l,l,l,l,d,d,d,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,d,d,d,d,d,d,l,d,d,d,d,d,d,d,d,d,d,d,d,d,d,d,d,d}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,d,l,l,l,l,d,l,d,l,l,l,l,l,l,l,l,d,d,l,l,l,d,d,d}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,d,l,d,l,d,d,l,d,l,l,l,l,l,l,l,l,d,d,l,d,l,d,d,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,d,l,l,l,l,d,l,d,d,d,d,d,d,d,d,d,d,d,d,d,d,d,d,d}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,d,d,d,d,d,d,l,d,l,l,l,l,l,l,l,l,d,d,l,d,l,d,d,d}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,d,l,l,l,l,d,l,d,l,l,l,l,l,l,l,l,l,d,l,l,d,d,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,d,d,d,d,d,d,l,d,d,d,d,d,d,d,d,d,d,d,d,d,d,d,d,d}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,d,l,l,l,l,d,l,d,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,d,d,d,d,l,d,l,d,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,d,d,d,d,l,d,l,d,d,d,d,d,d,d,d,d,d,d,d,d,d,d,d,d}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,d,d,d,d,d,d,l,d,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,d,d,d,d,d,d,l,d,d,l,l,l,l,l,l,l,d,d,d,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,d,d,d,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,l,l,l,l,l,l,l,d,d,d,l,l,l,d,d,d,l,l,l,l,l,l,l,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,l,l,l,l,l,l,l,d,d,d,l,l,l,d,d,d,l,l,l,l,l,l,l,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,l,l,d,d,d,l,l,d,d,d,l,l,l,d,d,d,l,l,l,l,l,l,l,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,l,l,d,d,d,l,l,d,d,d,l,l,l,d,d,d,l,l,l,l,l,l,l,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,l,l,d,d,d,d,d,d,d,d,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,l,l,d,d,d,d,d,d,d,d,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,l,l,d,d,d,d,d,d,d,d,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,d,d,d,d,d,d,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,d,d,d,d,d,d,d,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,d,d,d,d,d,d,d,d,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,l,l,l,l,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l,l,d,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,l,l,l,l,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,d,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,l,l,l,l,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,d,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,l,l,l,l,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l,l,d,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,d,d,d,d,d,d,d,d,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,d,d,d,d,d,d,d,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,d,d,d,d,d,d,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,d,d,d,l,l,d,d,d,l,l,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,d,d,d,l,l,l,l,l,l,l,l,l,l,l,d,d,d,l,l,d,d,d,l,l,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,d,d,d,l,l,l,l,l,l,l,l,l,l,l,d,d,d,l,l,d,d,d,l,l,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,d,d,d,l,l,l,l,l,l,l,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,d,d,d,l,l,l,l,l,l,l,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,d,d,d,l,l,l,l,l,l,l,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,d,d,d,l,l,l,l,l,l,l,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,l,l,d,d,d,l,l,d,d,d,l,l,l,d,d,d,l,l,d,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,l,l,d,d,d,l,l,d,d,d,l,l,l,d,d,d,l,l,d,d,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,l,l,d,d,d,l,l,d,d,d,l,l,l,d,d,d,l,l,d,d,d,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,l,l,l,l,l,l,l,d,d,d,l,l,l,d,d,d,l,l,d,d,d,l,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,l,l,l,l,l,l,l,d,d,d,l,l,l,d,d,d,d,d,d,d,d,l,l,d,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,l,l,l,l,l,l,l,d,d,d,l,l,l,l,d,d,d,d,d,d,l,l,l,l,d,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,d,d,d,l,l,l,l,l,l,l,d,d,d,l,l,l,l,l,d,d,d,d,l,l,l,l,l,l,d,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
,{l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l}
};

        public GameOver(int x, int y) : base(x, y)
        {
        }

        public override Colors[,] GetSpriteArray(){
            return spriteArray;
        }
    }
    