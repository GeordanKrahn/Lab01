using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Created by Geordan Krahn
// This class is responsible to updating the states and position of the actor, as well as drawing and animating the actor.
// Its methods take actors as arguments and makes decisions based on the states of the actor.

namespace Project1
{
    /// <summary>
    /// This class is responsible to updating the states and position of the actor, 
    /// as well as drawing and animating the actor.
    /// Its methods take actors as arguments and makes decisions based on the states of the actor.
    /// </summary>
    public static class UpdateActor
    {
        /// <summary>
        /// use this in the Update() in the game class
        /// This will keep track of and update the states and position of our character and listen for input
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="screenWidth"></param>
        /// <param name="gameTime"></param>
        public static void Update(Actor actor, int screenWidth, GameTime gameTime)
        {
            actor.CaptureInput();
            int horizontalPosition = (int)actor.GetPosition().X;
            int spriteWidth = actor.GetIdleSprite().Width;
            // if we are out of the play area, reset the position 
            if (horizontalPosition > screenWidth - spriteWidth)
            {
                // We have gone too far, reset position to just back inside
                actor.SetPosition(new Vector2(screenWidth - spriteWidth - actor.GetHorizontalSpeed(), actor.GetPosition().Y));
            }
            else if (horizontalPosition < 0)
            {
                actor.SetPosition(new Vector2(actor.GetHorizontalSpeed(), actor.GetPosition().Y));
            }
            else
            {
                Movement motionState = actor.GetMotionState();
                if (motionState == Movement.Walking)
                {
                    FacingDirection direction = actor.GetFacingDireciton();
                    if (direction == FacingDirection.Right)
                    {
                        actor.SetPosition(new Vector2(horizontalPosition + actor.GetHorizontalSpeed(), actor.GetPosition().Y));
                    }
                    else if (direction == FacingDirection.Left)
                    {
                        actor.SetPosition(new Vector2(horizontalPosition - actor.GetHorizontalSpeed(), actor.GetPosition().Y));
                    }
                }
            }
            actor.UpdateWalkingPlayer(gameTime);
        }

        /// <summary>
        /// use this in the Draw() in the game class on the player you need to animate or draw
        /// Draw either the idle state or walking state and animation based on whether we are moving
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="spriteBatch"></param>
        public static void Draw(Actor actor, SpriteBatch spriteBatch)
        {
            Movement motionState = actor.GetMotionState();
            FacingDirection direction = actor.GetFacingDireciton();
            Vector2 spritePosition = actor.GetPosition();
            if (motionState == Movement.Idle)
            {
                if (direction == FacingDirection.Right)
                {
                    spriteBatch.Draw(actor.GetIdleSprite(), spritePosition, Color.White);
                }
                else if (direction == FacingDirection.Left)
                {
                    spriteBatch.Draw(actor.GetIdleSprite(), spritePosition, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
                }
            }
            else if (motionState == Movement.Walking)
            {
                if (direction == FacingDirection.Right)
                {
                    actor.DrawWalkingAnimationFrame(spriteBatch, spritePosition, SpriteEffects.None);
                }
                else if (direction == FacingDirection.Left)
                {
                    actor.DrawWalkingAnimationFrame(spriteBatch, spritePosition, SpriteEffects.FlipHorizontally);
                }
            }
        }
    }
}
