using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/*
 * This object is reponsible for representing the player we control
 * It contains a position, a speed, direction, and motion state
 * This player also has an input component
 */

namespace Project1
{
    public class Player
    {
        // This will be used to draw the idle sprite or animate the sprite sheet at a point.
        private Vector2 spritePosition;

        // Horizontal Speed
        private int horizontalSpeed;

        // states to keep track of our character
        private Movement motionState;
        private FacingDirection direction;

        // sprite which represents the player. Its just logical to have this here
        private Texture2D idleSprite;
        // private Texture2D walkingSpriteSheet; this will only be used by the CelAnimationSequence
        private CelAnimationSequence walking; // used by the player
        private CelAnimationPlayer walkingPlayer; // used by the player

        // Greedy Constructor
        public Player(Vector2 spritePosition, Texture2D idleSprite, Texture2D walkingSpriteSheet, Vector2 walkingSpriteSheetCelDimentions, float celTime, int horizontalSpeed, FacingDirection initialFacingDirection)
        {
            // initialize this player
            this.spritePosition = spritePosition;
            this.horizontalSpeed = horizontalSpeed;
            this.idleSprite = idleSprite;
            // this.walkingSpriteSheet = walkingSpriteSheet; this will only be used by the CelAnimationSequence

            // determine dimentions of the spritesheet
            int CelWidth = walkingSpriteSheet.Width / (int)walkingSpriteSheetCelDimentions.X;
            int CelHeight = walkingSpriteSheet.Height / (int)walkingSpriteSheetCelDimentions.Y;

            // set up the walking animation sequence
            walking = new CelAnimationSequence(walkingSpriteSheet, CelWidth, CelHeight, celTime);
            
            direction = initialFacingDirection;
            motionState = Movement.Idle;
        }

        // accessors
        public void SetPosition(Vector2 newPosition)
        {
            spritePosition = newPosition;
        }

        public Vector2 GetPosition()
        {
            return spritePosition;
        }

        public void SetHorizontalSpeed(int newSpeed)
        {
            horizontalSpeed = newSpeed;
        }
        public int GetHorizontalSpeed()
        {
            return horizontalSpeed;
        }

        public void SetMotionState(Movement newMotion)
        {
            motionState = newMotion;
        }
        public Movement GetMotionState()
        {
            return motionState;
        }

        public void SetFacingDirection(FacingDirection newDirection)
        {
            direction = newDirection;
        }
        public FacingDirection GetFacingDireciton()
        {
            return direction;
        }

        public Texture2D GetIdleSprite()
        {
            return idleSprite;
        }

        // This object will update itself
        public void CaptureInput()
        {
            InputListener.CaptureInput(this);
        }

        public void StartWalkingAnimationPlayer()
        {
            // Set up the animation player
            walkingPlayer = new CelAnimationPlayer();
            walkingPlayer.Play(walking);
        }

        // call in Update after everything else
        public void UpdateWalkingPlayer(GameTime gameTime)
        {
            walkingPlayer.Update(gameTime); // this just queues the next frame of animation
        }

        // call in Draw
        public void DrawWalkingAnimationFrame(SpriteBatch spriteBatch, Vector2 spritePosition, SpriteEffects effects)
        {
            walkingPlayer.Draw(spriteBatch, spritePosition, effects);
        }
    }
}
