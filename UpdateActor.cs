using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    public static class UpdateActor
    {
        // use this in the Update() in the game class
        // This will keep track of and update the states and position of our character and listen for input
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

        // use this in the Draw() in the game class on the player you need to animate or draw
        // Draw either the idle state or walking state and animation based on whether we are moving
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
