using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Source
{
    internal class InputAction
    {
        public string Name { get; set; }
        public Keyboard.Key Key { get; set; }
        public Keyboard.Key AltKey { get; set; }
        public bool isPressing = false;
        public bool isPressed = false;

        public InputAction(string name,Keyboard.Key key)
        {
            this.Name = name;
            this.Key = key;

            Input.AllInputActions.Add(this.Name, this);
        }

        public InputAction(string name,Keyboard.Key key,Keyboard.Key altKey)
        {
            this.Name = name;
            this.Key = key;
            this.AltKey = altKey;

            Input.AllInputActions.Add(this.Name, this);
        }
    }
}
