using Microsoft.Xna.Framework.Input;

// I created this class to exlicitly listen for input.
// Should work to control any player object.
namespace Project1
{
    public static class InputListener
    {
        public static void CaptureInput(Player player)
        {
            // Get the current keyboard state
            KeyboardState kbState = Keyboard.GetState();

            // store the current state just in case nothing happens.
            Movement motion = player.GetMotionState();
            FacingDirection direction = player.GetFacingDireciton();

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

            // set the updated states
            player.SetMotionState(motion);
            player.SetFacingDirection(direction);
        }
    }
}
