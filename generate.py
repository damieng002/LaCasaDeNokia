from PIL import Image
import sys, getopt

if len(sys.argv)<3:
    print("ERROR: must take at least 2 args, 1 input .png file and the output class name")
    exit(1)
input_files = sys.argv[1:-1]
output_name = sys.argv[-1]

if(len(input_files)==1):
    pixels_content = ""
    im = Image.open(input_files[0])
    h = im.height
    w = im.width
    px = im.load()
    pixels_content+="{"
    for x in range(0,w):
        pixels_content+="{"
        for y in range(0,h):
            if px[x,y][3]<128:
                pixels_content+="t"
            elif sum(px[x,y][0:3])/3<128:
                pixels_content+="d"
            else:
                pixels_content+="l"
            if y<h-1:
                pixels_content+=","
        pixels_content+="}\n"
        if x<w-1:
            pixels_content+=","
    pixels_content+="}"
    output_content = """using System.Collections;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class """+output_name+""":Sprite
    {
        private static Colors t = Colors.Transparent;
        private static Colors d = Colors.Dark;
        private static Colors l = Colors.Light;

        Colors[,] spriteArray = new Colors[,] """+pixels_content+""";

        public """+output_name+"""(int x, int y) : base(x, y)
        {
        }

        public override Colors[,] GetSpriteArray(){
            return spriteArray;
        }
    }
    """

    f = open(output_name+".cs", "w")
    f.write(output_content)
    f.close()

else:
    pixels_contents = []
    for input_file in input_files:
        pixels_content_tmp = ""
        im = Image.open(input_file)
        h = im.height
        w = im.width
        px = im.load()
        pixels_content_tmp+="{"
        for x in range(0,w):
            pixels_content_tmp+="{"
            for y in range(0,h):
                if px[x,y][3]<128:
                    pixels_content_tmp+="t"
                elif sum(px[x,y][0:3])/3<128:
                    pixels_content_tmp+="d"
                else:
                    pixels_content_tmp+="l"
                if y<h-1:
                    pixels_content_tmp+=","
            pixels_content_tmp+="}\n"
            if x<w-1:
                pixels_content_tmp+=","
        pixels_content_tmp+="}"
        pixels_contents.append(pixels_content_tmp)
    output_content = """using System.Collections;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class """+output_name+""":Sprite
    {
        private static Colors t = Colors.Transparent;
        private static Colors d = Colors.Dark;
        private static Colors l = Colors.Light;

        private List<Colors[,]> spriteList = new List<Colors[,]>();
        private int crtFrame = 0;
        
        public """+output_name+"""(int x, int y) : base(x, y)
        {
            """+"\n".join(['spriteList.Add(new Colors[,] '+x+');' for x in pixels_contents])+"""
        }

        public override Colors[,] GetSpriteArray(){
            crtFrame = (crtFrame + 1) % spriteList.Count;
            return spriteList[crtFrame];
        }
    }
    """

    f = open(output_name+".cs", "w")
    f.write(output_content)
    f.close()