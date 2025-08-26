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

        public static List<GameObject> GameObjects = new List<GameObject>();
        public static List<GameObject> GameObjectsToAdd = new List<GameObject>();
        public static List<GameObject> GameObjectsToRemove = new List<GameObject>();

        // Camera's
        public static View Camera;
        public static List<Camera> AllCameras = new List<Camera>();

        public Engine(uint width, uint height, string title, Color color)
        {
            this.WIDTH = width;
            this.HEIGHT = height;
            this.TITLE = title;
            this.COLOR = color;

            APP = new RenderWindow(
                new VideoMode(this.WIDTH, this.HEIGHT),
                this.TITLE,
                style: Styles.Close | Styles.Resize);

            APP.SetFramerateLimit(114);

            APP.Closed += APP_Closed;
            APP.Resized += APP_Resized;
            APP.KeyReleased += APP_KeyReleased;
            APP.KeyPressed += APP_KeyPressed;

            // Initialize cameras
            Camera = APP.GetView();
            APP.SetView(Camera);

            // GameLoop
            GameLoop();


        }

        void GameLoop()
        {
            OnLoad();
            LoadGameObjects();

            while(APP.IsOpen)
            {
                APP.DispatchEvents();
                APP.Clear(COLOR);

                OnUpate();
                UpdateGameObjects();

                APP.Display();
            }
        }

        private void APP_KeyPressed(object? sender, KeyEventArgs e)
        {
            Input.GetKeyDown(e);
        }

        private void APP_KeyReleased(object? sender, KeyEventArgs e)
        {
            Input.GetKeyUp(e);
        }

        private void APP_Resized(object? sender, SizeEventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            FloatRect visibleArea = new FloatRect(0, 0, e.Width, e.Height);
            window.SetView(new View(visibleArea));
        }

        private void APP_Closed(object? sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }
        public static void RegisterGameObject(GameObject gameObject)
        {
            GameObjectsToAdd.Add(gameObject);
        }

        public static void UnregisterGameObject(GameObject gameObject)
        {
            GameObjectsToRemove.Remove(gameObject);
        }

        public void LoadGameObjects()
        {
            foreach (GameObject gameObject in GameObjects)
            {
                gameObject.OnLoad();
            }
        }

        public void UpdateGameObjects()
        {
            Time.UpdateTime();

            if (GameObjects == null)
                return;
            for (int i = 0; i < GameObjects.Count; i++)
            {
                GameObjects[i].OnUpdate();
                GameObjects[i].UpdateChildren();
            }

            if (GameObjectsToAdd.Count > 0)
            {
                for (int i = 0; i < GameObjectsToAdd.Count; i++)
                {
                    GameObjectsToAdd[i].OnLoad();
                    GameObjects.Add(GameObjectsToAdd[i]);
                }
                GameObjectsToAdd.Clear();
            }

            if (GameObjectsToRemove.Count > 0)
            {
                for (int i = 0; i < GameObjectsToRemove.Count; i++)
                {
                    GameObjectsToRemove[i].OnDestroy();
                    GameObjects.Remove(GameObjectsToRemove[i]);
                }
                GameObjectsToRemove.Clear();
            }
        }

        public virtual void OnUpate()
        {
            LevelManager.UpdateLevel();
        }
        public abstract void OnLoad();
    }
}
