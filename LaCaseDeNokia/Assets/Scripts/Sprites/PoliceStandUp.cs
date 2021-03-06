using System.Collections;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class PoliceStandUp:Sprite
    {
        private static Colors t = Colors.Transparent;
        private static Colors d = Colors.Dark;
        private static Colors l = Colors.Light;

        private List<Colors[,]> spriteList = new List<Colors[,]>();
        private int crtFrame = 0;
        
        public PoliceStandUp(int x, int y) : base(x, y)
        {
            spriteList.Add(new Colors[,] {{t,t,t,d,t,t,t,t,t,t,t}
,{t,t,t,d,t,d,t,t,t,t,t}
,{d,d,t,d,t,t,d,t,t,t,t}
,{d,d,d,d,d,d,d,d,t,t,t}
,{d,l,d,d,l,l,l,d,d,t,t}
,{l,d,l,d,l,d,l,d,d,d,d}
,{d,l,d,d,l,l,l,d,d,t,t}
,{d,d,d,d,l,d,l,d,d,t,t}
,{d,d,d,d,l,l,l,d,d,d,d}
,{d,d,d,d,d,d,d,d,t,t,t}
,{d,d,t,t,d,d,d,t,t,t,t}
,{t,t,t,t,d,d,t,t,t,t,t}
});
spriteList.Add(new Colors[,] {{t,t,t,d,t,t,d,t,t,t,t}
,{t,t,t,d,t,t,d,t,t,t,t}
,{d,d,t,d,t,t,t,d,t,t,t}
,{d,d,d,d,d,d,d,d,t,t,t}
,{d,l,d,d,l,l,l,d,d,t,t}
,{l,d,l,d,l,d,l,d,d,d,d}
,{d,l,d,d,l,l,l,d,d,t,t}
,{d,d,d,d,l,d,l,d,d,t,t}
,{d,d,d,d,l,l,l,d,d,d,d}
,{d,d,d,d,d,d,d,d,t,t,t}
,{d,d,t,t,d,d,d,t,t,t,t}
,{t,t,t,t,d,d,t,t,t,t,t}
});
spriteList.Add(new Colors[,] {{t,t,t,d,t,t,t,d,t,t,t}
,{t,t,t,d,t,t,t,d,t,t,t}
,{d,d,t,d,t,t,t,d,t,t,t}
,{d,d,d,d,d,d,d,d,t,t,t}
,{d,l,d,d,l,l,l,d,d,t,t}
,{l,d,l,d,l,d,l,d,d,d,d}
,{d,l,d,d,l,l,l,d,d,t,t}
,{d,d,d,d,l,d,l,d,d,t,t}
,{d,d,d,d,l,l,l,d,d,d,d}
,{d,d,d,d,d,d,d,d,t,t,t}
,{d,d,t,t,d,d,d,t,t,t,t}
,{t,t,t,t,d,d,t,t,t,t,t}
});
        }

        public override Colors[,] GetSpriteArray(){
            crtFrame = (crtFrame + 1) % spriteList.Count;
            return spriteList[crtFrame];
        }
    }
    