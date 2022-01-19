using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Created by Geordan Krahn

namespace Project1
{
    /// <summary>
    /// This class is responsible to updating the states and position of the actor, 
    /// as well as drawing and animating the actor.
    /// Its methods take actors as arguments and makes decisions based on the states of the actor.
    /// </summary>
    public static class ActorUtility
    {
        /// <summary>
        /// use this in the Update() in the game class
        /// This will keep track of and update the states and position of our character and listen for input
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="screenWidth"></param>
        /// <param name="gameTime"></param>
        public static void UpdateActors(AActor actor, int screenWidth, GameTime gameTime)
        {
            // TODO, what the hell will this do?
        }

        /// <summary>
        /// use this in the Update() in the game class
        /// This will keep track of and update the states and position of our character and listen for input
        /// </summary>
        /// <param name="player"></param>
        /// <param name="screenWidth"></param>
        /// <param name="gameTime"></param>
        public static void UpdatePlayer(APlayer player, int screenWidth, GameTime gameTime)
        {
            player.CaptureInput();
            int horizontalPosition = (int)player.GetPosition().X;
            int spriteWidth = player.GetSprite().Width;
            // if we are out of the play area, reset the position 
            if (horizontalPosition > screenWidth - spriteWidth)
            {
                // We have gone too far, reset position to just back inside
                player.SetPosition(new Vector2(screenWidth - spriteWidth - player.GetHorizontalSpeed(), player.GetPosition().Y));
            }
            else if (horizontalPosition < 0)
            {
                player.SetPosition(new Vector2(player.GetHorizontalSpeed(), player.GetPosition().Y));
            }
            else
            {
                EMovement motionState = player.GetMotionState();
                if (motionState == EMovement.Walking)
                {
                    EFacingDirection direction = player.GetFacingDireciton();
                    if (direction == EFacingDirection.Right)
                    {
                        player.SetPosition(new Vector2(horizontalPosition + player.GetHorizontalSpeed(), player.GetPosition().Y));
                    }
                    else if (direction == EFacingDirection.Left)
                    {
                        player.SetPosition(new Vector2(horizontalPosition - player.GetHorizontalSpeed(), player.GetPosition().Y));
                    }
                }
            }
            player.UpdateWalkingPlayer(gameTime);
        }

        /// <summary>
        /// use this in the Draw() in the game class on the player you need to animate or draw
        /// Draw either the idle state or walking state and animation based on whether we are moving
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="spriteBatch"></param>
        public static void DrawActor(AActor actor, SpriteBatch spriteBatch)
        {
            // TODO - What the hell will this do?
        }

        /// <summary>
        /// use this in the Draw() in the game class on the player you need to animate or draw
        /// Draw either the idle state or walking state and animation based on whether we are moving
        /// </summary>
        /// <param name="player"></param>
        /// <param name="spriteBatch"></param>
        public static void DrawPlayer(APlayer player, SpriteBatch spriteBatch)
        {
            EMovement motionState = player.GetMotionState();
            EFacingDirection direction = player.GetFacingDireciton();
            Vector2 spritePosition = player.GetPosition();
            if (motionState == EMovement.Idle)
            {
                if (direction == EFacingDirection.Right)
                {
                    spriteBatch.Draw(player.GetSprite(), spritePosition, Color.White);
                }
                else if (direction == EFacingDirection.Left)
                {
                    spriteBatch.Draw(player.GetSprite(), spritePosition, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
                }
            }
            else if (motionState == EMovement.Walking)
            {
                if (direction == EFacingDirection.Right)
                {
                    player.DrawWalkingAnimationFrame(spriteBatch, spritePosition, SpriteEffects.None);
                }
                else if (direction == EFacingDirection.Left)
                {
                    player.DrawWalkingAnimationFrame(spriteBatch, spritePosition, SpriteEffects.FlipHorizontally);
                }
            }
        }
    }
}
