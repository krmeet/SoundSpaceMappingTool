using System;
using OpenTK;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace SoundSpaceMappingTool
{
    class Program
    {
        static void Main(string[] args)
        {
            VSyncMode vsync = VSyncMode.On;
            if (args.Length != 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    switch (args[i])
                    {
                        case "--disable-vsync":
                            vsync = VSyncMode.Off;
                            break;
                        default:
                            Console.WriteLine("Invalid arguments!");
                            return;
                    }
                }
            }
            try {
                using (MainWindow w = new MainWindow(vsync)) {
                    w.Run();
                }
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}
