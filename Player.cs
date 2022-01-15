using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project1
{
    class Player
    {
        // This will be used to draw the idle sprite or animate the sprite sheet at a point.
        private Vector2 spritePosition; // - PLAYER

        // Horizontal Speed
        private int horizontalSpeed; // - PLAYER

        private Texture2D idleSprite; // - PLAYER
        private CelAnimationSequence walking; // - PLAYER
        private CelAnimationPlayer playerAnimator; // - PLAYER
        
        // states to keep track of our character
        Movement motionState; // - PLAYER
        FacingDirection direction; // - PLAYER

        // Greedy Constructor
        public Player(Vector2 spritePosition, int horizontalSpeed, Texture2D idleSprite, CelAnimationPlayer playerAnimator, CelAnimationSequence walking, FacingDirection initialFacingDirection)
        {
            // initialize this player
            this.spritePosition = spritePosition;
            this.horizontalSpeed = horizontalSpeed;
            this.idleSprite = idleSprite;
            this.playerAnimator = playerAnimator;
            this.walking = walking;
            direction = initialFacingDirection;

            // Set up the animation player
            playerAnimator = new CelAnimationPlayer();
            playerAnimator.Play(walking);
        }

        private void CaptureInput()
        {
            // Get the current keyboard state
            KeyboardState kbState = Keyboard.GetState();

            // if no keys are being pressed we are idle
            if (kbState.GetPressedKeys().Length == 0)
            {
                motionState = Movement.Idle;
            }
            else if (kbState.IsKeyDown(Keys.Left) || kbState.IsKeyDown(Keys.A))
            {
                motionState = Movement.Walking;
                direction = FacingDirection.Left;
            }
            else if (kbState.IsKeyDown(Keys.Right) || kbState.IsKeyDown(Keys.D))
            {
                motionState = Movement.Walking;
                direction = FacingDirection.Right;
            }
        }

        // This will keep track of and update the states and position of our character and listen for input.
        public void Update(GameTime gameTime, int screenWidth, int screenHeight)
        {
            CaptureInput();

            // if we are out of the play area, reset the position 
            if (spritePosition.X > screenWidth - idleSprite.Width)
            {
                // We have gone too far too the right, reset position to just back inside
                spritePosition.X = screenWidth - idleSprite.Width - horizontalSpeed;
            }
            else if (spritePosition.X < idleSprite.Width)
            {
                spritePosition.X = idleSprite.Width + horizontalSpeed;
            }
            else
            {
                if (motionState == Movement.Walking)
                {
                    if (direction == FacingDirection.Right)
                    {
                        spritePosition.X += horizontalSpeed;
                    }
                    else if (direction == FacingDirection.Left)
                    {
                        spritePosition.X += -horizontalSpeed;
                    }
                }
            }

            playerAnimator.Update(gameTime); // this just queues the next frame of animation
        }

        // This will draw the scene each frame. Draw either the idle state or walking state and animation based on whether we are moving
        public void Draw(SpriteBatch spriteBatch)
        {
            if (motionState == Movement.Idle)
            {
                spriteBatch.Draw(idleSprite, spritePosition, Color.White);
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
