using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.Window;

namespace GameEngine.Source
{
    abstract class Engine
    {
        public uint WIDTH;
        public uint HEIGHT;
        public string TITLE;
        public Color COLOR;

        public static RenderWindow APP;

        public Engine(uint width,uint height,string title,Color color)
        {
            this.WIDTH = width;
            this.HEIGHT = height;
            this.TITLE = title;
            this.COLOR = color;

            APP = new RenderWindow(
                new VideoMode(this.WIDTH, this.HEIGHT),
                this.TITLE,
                style: Styles.Close | Styles.Resize
                );

            APP.Closed += APP_Closed;
            APP.Resized += APP_Resized;

            APP.SetFramerateLimit(114);

            GameLoop();
        }

        private void APP_Resized(object? sender, SizeEventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            FloatRect visibleArea = new FloatRect(0, 0, e.Width, e.Height);
            window.SetView(new View(visibleArea));
            Log.Info($"{e.Width}x{e.Height}");
        }

        private void APP_Closed(object? sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
            Log.Info($"Window Closed");
        }

        void GameLoop()
        {
            while(APP.IsOpen)
            {
                APP.DispatchEvents();
                APP.Clear(this.COLOR);

                APP.Display();
            }
        }
    }
}
