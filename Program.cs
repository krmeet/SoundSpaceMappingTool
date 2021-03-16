using System;
using OpenTK;

namespace SoundSpaceMappingTool
{
	class Program
	{
		static void Main(string[] args)
		{
			VSyncMode vsync = VSyncMode.Off;
			if (args.Length != 0)
			{
				for (int i = 0; i < args.Length; i++)
				{
					switch (args[i])
					{
						case "--vsync":
							vsync = VSyncMode.On;
							break;
						default:
							Console.WriteLine("Invalid arguments!");
							break;
					}
				}
			}
			try
			{
				new MainWindow(800, 600, "Sound Space Mapping Tool", vsync);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}
