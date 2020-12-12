using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmongUs
{
    static class Renderer
    {
        private static float deltaTime;

        public static float DeltaTime
        {
            get { return deltaTime; }
        }

        public static void Setup()
        {
            Console.WindowHeight = 30;
            Console.BufferHeight = 30;

            Console.CursorVisible = false;
        }

        public static void DrawFrame()
        {
            DoTimeProbe();
            char[] frame = new char[Console.BufferWidth * (Console.BufferHeight - 1)];

            foreach (var item in Hud.huds)
            {
                if (item.disabled) continue;

                bool exit = false;
                for (int y = 0; y + item.position.y + 1 < Console.BufferHeight && !exit; y++)
                {
                    for (int x = 0; x + item.position.x < Console.BufferWidth; x++)
                    {
                        if (x >= item.panelWidth) break;

                        if (x + y * item.panelWidth >= item.Panel.Length)
                        {
                            exit = true;
                            break;
                        }

                        frame[x + item.position.x + Console.BufferWidth * (y + item.position.y)] = item.Panel[x + item.panelWidth * y];
                    }
                }
            }

            Console.SetCursorPosition(0, 0);
            Console.Write(frame);
        }

        private static DateTime lastFrame = DateTime.Now;
        private static void DoTimeProbe()
        {
            TimeSpan span = DateTime.Now - lastFrame;
            deltaTime = (float)span.TotalSeconds;

            lastFrame = DateTime.Now;
        }
    }

}
