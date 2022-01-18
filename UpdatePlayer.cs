using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    public static class UpdatePlayer
    {
        // use this in the Update() in the game class
        // This will keep track of and update the states and position of our character and listen for input
        public static void Update(Player player, int screenWidth)
        {
            player.CaptureInput();
            int horizontalPosition = (int)player.GetPosition().X;
            int spriteWidth = player.GetIdleSprite().Width;
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
                Movement motionState = player.GetMotionState();
                if (motionState == Movement.Walking)
                {
                    FacingDirection direction = player.GetFacingDireciton();
                    if (direction == FacingDirection.Right)
                    {
                        player.SetPosition(new Vector2(horizontalPosition + player.GetHorizontalSpeed(), player.GetPosition().Y));
                    }
                    else if (direction == FacingDirection.Left)
                    {
                        player.SetPosition(new Vector2(horizontalPosition - player.GetHorizontalSpeed(), player.GetPosition().Y));
                    }
                }
            }
        }

        // use this in the Draw() in the game class on the player you need to animate or draw
        // Draw either the idle state or walking state and animation based on whether we are moving
        public static void Draw(Player player, SpriteBatch spriteBatch, CelAnimationPlayer playerAnimator)
        {
            Movement motionState = player.GetMotionState();
            FacingDirection direction = player.GetFacingDireciton();
            Vector2 spritePosition = player.GetPosition();
            if (motionState == Movement.Idle)
            {
                if (direction == FacingDirection.Right)
                {
                    spriteBatch.Draw(player.GetIdleSprite(), spritePosition, Color.White);
                }
                else if (direction == FacingDirection.Left)
                {
                    spriteBatch.Draw(player.GetIdleSprite(), spritePosition, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
                }
            }
            else if (motionState == Movement.Walking)
            {
                if (direction == FacingDirection.Right)
                {
                    playerAnimator.Draw(spriteBatch, spritePosition, SpriteEffects.None);
                }
                else if (direction == FacingDirection.Left)
                {
                    playerAnimator.Draw(spriteBatch, spritePosition, SpriteEffects.FlipHorizontally);
                }
            }
        }
    }
}
