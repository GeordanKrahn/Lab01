using Microsoft.Xna.Framework.Input;

// Created by Geordan Krahn

namespace Project1
{
    /// <summary>
    /// The input listener updates the appropriate actor
    /// </summary>
    public static class InputListener
    {
        /// <summary>
        /// This method captures input from a player
        /// </summary>
        /// <param name="player">the Player object</param>
        public static void CaptureInput(APlayer player)
        {
            // store the current state just in case nothing happens.
            EMovement motion = player.GetMotionState();
            EFacingDirection direction = player.GetFacingDireciton();

            // Get the current keyboard state
            KeyboardState kbState = Keyboard.GetState();

            // if no keys are being pressed we are idle
            if (kbState.GetPressedKeys().Length == 0)
            {
                motion = EMovement.Idle;
            }
            else if (kbState.IsKeyDown(Keys.Left) || kbState.IsKeyDown(Keys.A))
            {
                motion = EMovement.Walking;
                direction = EFacingDirection.Left;
            }
            else if (kbState.IsKeyDown(Keys.Right) || kbState.IsKeyDown(Keys.D))
            {
                motion = EMovement.Walking;
                direction = EFacingDirection.Right;
            }
            // set the updated states
            player.SetMotionState(motion);
            player.SetFacingDirection(direction);
        }

        /// <summary>
        /// This method deduces which type the actor is and calls the correct overload.
        /// This is meant more for preventing errors.
        /// </summary>
        /// <param name="actor">The actor object</param>
        public static void CaptureInput(AActor actor)
        {
            System.Type actorType = actor.GetType();
            if(actorType == typeof(APlayer))
            {
                CaptureInput((APlayer)actor);
            }
        }
    }
}
