using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AmongUs
{
    class Program
    {
        static void Main(string[] args)
        {
            Renderer.Setup();

            MapCreatorTest();
        }
        
        static void MapCreatorTest()
        {
            MapCreator mc = new MapCreator(@"C:\Users\Matthias\Documents\programmieren\map1.txt");
            Hud map = new Hud(mc.GetMap());
            map.panelWidth = 44;

            Renderer.DrawFrame();
        }

        static void HudTest()
        {

            Console.SetWindowSize(Console.WindowWidth, 25);
            Console.BufferHeight = 25;
            Console.CursorVisible = false;

            Hud hud0 = new Hud("HHHHHHHHHHHHHHHHHHHHHHHHabcdefHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH");
            Hud hud1 = new Hud();

            hud0.Layer = 2;
            hud0.position = new Vector(25, 23);

            hud1.position = new Vector(20, 7);
            hud1.Layer = 3;
            hud1.CreateHudParent = () => { return DateTime.Now.ToString(); };

            hud1.disabled = false;

            while (true)
            {
                Renderer.DrawFrame();
            }
        }
    }
}
