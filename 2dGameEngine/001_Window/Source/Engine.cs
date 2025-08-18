using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;

namespace GameEngine.Source
{
    internal class Engine
    {

        public uint width = 500;
        public uint height = 500;
        public string title = "";
        public Color windowColor = Color.White;

        RenderWindow app;

        public Engine(uint WIDTH, uint HEIGHT, string TITLE, Color COLOR)
        {
            this.width = WIDTH;
            this.height = HEIGHT;
            this.title = TITLE;
            this.windowColor = COLOR;

            app = new RenderWindow(
                new VideoMode(width, height),
                title,
                style: Styles.Resize | Styles.Close);

            app.Closed += App_Closed;
            app.Resized += App_Resized;

            GameLoop();

        }

        private void App_Resized(object? sender, SizeEventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            FloatRect visibleArea = new FloatRect(0, 0, width, height);
            window.SetView(new View(visibleArea));
            Log.Info("* app resized *");
        }

        private void App_Closed(object? sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            Log.Info("* app closed *");
            window.Close();
        }

        void GameLoop()
        {
            while(app.IsOpen)
            {
                app.DispatchEvents();
                app.Clear(windowColor);

                app.Display();
            }
        }
    }
}
