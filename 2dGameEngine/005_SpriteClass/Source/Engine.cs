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
        public static List<GameObject> GameObjectToAdd = new List<GameObject>();
        public static List<GameObject> GameObjectToRemove = new List<GameObject>();

        public Engine(uint width,uint height,string title,Color color)
        {
            this.WIDTH = width;
            this.HEIGHT = height;
            this.TITLE = title;
            this.COLOR = color;

            APP = new RenderWindow(
                new VideoMode(this.WIDTH, this.HEIGHT),
                this.TITLE,
                style: Styles.Resize | Styles.Close);

            APP.Closed += APP_Closed;
            APP.Resized += APP_Resized;
            APP.KeyPressed += APP_KeyPressed;
            APP.KeyReleased += APP_KeyReleased;

            APP.SetFramerateLimit(114);

            GameLoop();


        }

        private void APP_KeyReleased(object? sender, KeyEventArgs e)
        {
            Input.GetKeyUp(e);
        }

        private void APP_KeyPressed(object? sender, KeyEventArgs e)
        {
            Input.GetKeyDown(e);
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

        void GameLoop()
        {
            OnLoad();
            LoadGameObjects();

            while(APP.IsOpen)
            {
                APP.DispatchEvents();
                APP.Clear(COLOR);

                UpdateGameObjects();
                OnUpdate();

                APP.Display();
            }

        }

        public static void RegisterGameObject(GameObject gameObject)
        {
            GameObjectToAdd.Add(gameObject);
        }

        public static void UnregisterGameObject(GameObject gameObject)
        {
            GameObjectToRemove.Add(gameObject);
        }

        public void LoadGameObjects()
        {
            foreach(GameObject gameObject in GameObjects)
            {
                gameObject.OnLoad();
            }
        }

        public void  UpdateGameObjects()
        {
            if (GameObjects == null)
                return;
            for(int i=0;i<GameObjects.Count;i++)
            {
                GameObjects[i].OnUpdate();
                GameObjects[i].UpdateChildren();
            }

            if(GameObjectToAdd.Count>0)
            {
                for (int i=0;i<GameObjectToAdd.Count;i++)
                {
                    GameObjectToAdd[i].OnLoad();
                    GameObjects.Add(GameObjectToAdd[i]);
                }
                GameObjectToAdd.Clear();
            }

            if(GameObjectToRemove.Count>0)
            {
                for(int i=0;i<GameObjectToRemove.Count;i++)
                {
                    GameObjectToRemove[i].OnDestroy();
                    GameObjects.Remove(GameObjectToRemove[i]);
                }
                GameObjectToRemove.Clear();
            }
        }

        public abstract void OnLoad();
        public virtual void OnUpdate()
        {

        }
       

    }
}
