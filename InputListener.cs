using Microsoft.Xna.Framework.Input;

// I created this class to exlicitly listen for input.
// Should work to control any player object.
// I may work on creating an AI driver which can return "input" to this class.
namespace Project1
{
    public static class InputListener
    {
        public static void CaptureInput(Actor actor)
        {
            // store the current state just in case nothing happens.
            Movement motion = actor.GetMotionState();
            FacingDirection direction = actor.GetFacingDireciton();

            // Is this a player, enemy or ally?
            switch (actor.actorType)
            {
                case ActorType.Player:
                    // Get the current keyboard state
                    KeyboardState kbState = Keyboard.GetState();

                    // if no keys are being pressed we are idle
                    if (kbState.GetPressedKeys().Length == 0)
                    {
                        motion = Movement.Idle;
                    }
                    else if (kbState.IsKeyDown(Keys.Left) || kbState.IsKeyDown(Keys.A))
                    {
                        motion = Movement.Walking;
                        direction = FacingDirection.Left;
                    }
                    else if (kbState.IsKeyDown(Keys.Right) || kbState.IsKeyDown(Keys.D))
                    {
                        motion = Movement.Walking;
                        direction = FacingDirection.Right;
                    }
                    break;
                case ActorType.Enemy:
                    ;
                    break;
                case ActorType.Ally:
                    ;
                    break;
            }

            // set the updated states
            actor.SetMotionState(motion);
            actor.SetFacingDirection(direction);
        }
    }
}
