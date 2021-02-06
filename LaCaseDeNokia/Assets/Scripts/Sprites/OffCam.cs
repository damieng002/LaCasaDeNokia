using System.Collections;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class OffCam:Sprite
    {
        private static Colors t = Colors.Transparent;
        private static Colors d = Colors.Dark;
        private static Colors l = Colors.Light;

        Colors[,] spriteArray = new Colors[,] {{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,l,l,l,l,l,l,l,d,d,d,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,l,t,t,t,t,t,l,d,d,d,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,l,t,t,t,t,t,l,d,d,d,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,l,l,l,l,l,l,l,d,d,d,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,l,l,l,d,d,d,l,l,l,l,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,l,t,l,d,d,d,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,l,t,l,d,d,d,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,l,t,l,d,d,d,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,l,t,l,l,l,l,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,l,l,l,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,l,l,l,l,l,l,l,l,l,l,l,l,l,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,d,d,d,d,d,d,d,d,d,d,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,l,l,l,d,d,d,l,l,l,l,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,l,t,l,d,d,d,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,l,t,l,d,d,d,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,l,t,l,d,d,d,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,l,t,l,l,l,l,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,d,d,d,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,l,l,l,l,l,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
,{t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t,t}
};

        public OffCam(int x, int y) : base(x, y)
        {
        }

        public override Colors[,] GetSpriteArray(){
            return spriteArray;
        }
    }
    