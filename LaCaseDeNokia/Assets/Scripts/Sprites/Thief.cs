using System.Collections;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class Thief:Sprite
    {
        private static Colors t = Colors.Transparent;
        private static Colors d = Colors.Dark;
        private static Colors l = Colors.Light;

        private List<Colors[,]> spriteList = new List<Colors[,]>();
        private int crtFrame = 0;
        
        public Thief(int x, int y) : base(x, y)
        {
            spriteList.Add(new Colors[,] {{t,t,d,d,d,t,t,t,t}
,{t,d,d,d,d,d,t,t,t}
,{d,d,l,l,l,d,d,d,d}
,{d,d,l,d,l,d,d,t,t}
,{d,d,l,l,l,d,d,t,t}
,{d,d,l,d,l,d,d,d,t}
,{t,d,l,l,d,d,t,t,d}
});
spriteList.Add(new Colors[,] {{t,t,d,d,d,t,t,t,t}
,{t,d,d,d,d,d,t,t,d}
,{d,d,l,l,l,d,d,d,t}
,{d,d,l,d,l,d,d,t,t}
,{d,d,l,l,l,d,d,t,t}
,{d,d,l,d,l,d,d,d,d}
,{t,d,l,l,d,d,t,t,t}
});
spriteList.Add(new Colors[,] {{t,t,d,d,d,t,t,t,t}
,{t,d,d,d,d,d,t,t,t}
,{d,d,l,l,l,d,d,d,d}
,{d,d,l,d,l,d,d,t,t}
,{d,d,l,l,l,d,d,t,d}
,{d,d,l,d,l,d,d,d,t}
,{t,d,l,l,d,d,t,t,t}
});
        }

        public override Colors[,] GetSpriteArray(){
            crtFrame = (crtFrame + 1) % spriteList.Count;
            return spriteList[crtFrame];
        }
    }
    