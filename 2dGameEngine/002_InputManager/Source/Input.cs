using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Source
{
    internal class Input
    {
        public static Dictionary<string, InputAction> AllInputActions=new Dictionary<string, InputAction>();

        // Define Inpu Actions
        public static InputAction Left = new InputAction("Left", Keyboard.Key.A,Keyboard.Key.Left);
        public static InputAction Right = new InputAction("Right", Keyboard.Key.D,Keyboard.Key.Right);
        public static InputAction Up = new InputAction("Up", Keyboard.Key.W, Keyboard.Key.Up);
        public static InputAction Down = new InputAction("Down", Keyboard.Key.S, Keyboard.Key.Down);

        public static bool ActionPressed(string actionName)
        {
            if(AllInputActions.ContainsKey(actionName))
            {
                return AllInputActions[actionName].isPressing;
            }
            else
                Console.WriteLine($"{actionName} doesn't exists");
            return false;
                
        }

        public static bool ActionJustPressed(string actionName)
        {
            if(AllInputActions.ContainsKey(actionName))
            {
                if (!AllInputActions[actionName].isPressed && AllInputActions[actionName].isPressing)
                {
                    AllInputActions[actionName].isPressed = true;
                    return AllInputActions[actionName].isPressed;
                }
                
            }
            else
                Console.WriteLine($"{actionName} doesn't exists");
            return false;
        }

        public static void GetKeyUp(KeyEventArgs e)
        {
            foreach(InputAction action in AllInputActions.Values)
            {
                if(action.Key==e.Code || (action.AltKey!=Keyboard.Key.Unknown && action.AltKey==e.Code))
                {
                    action.isPressed = false;
                    action.isPressing = false;
                }
            }
        }

        public static void GetKeyDown(KeyEventArgs e)
        {
            foreach(InputAction action in AllInputActions.Values)
            {
                if(action.Key==e.Code || (action.AltKey!=Keyboard.Key.Unknown && action.AltKey==e.Code))
                {
                    action.isPressing = true;
                }
            }
        }
    }
}
