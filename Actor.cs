using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/*
 * This object is reponsible for representing the player we control
 * It contains a position, a speed, direction, and motion state
 * This player also has an input component
 */

namespace Project1
{
    public class Actor
    {
        // This will be used to draw the idle sprite or animate the sprite sheet at a point.
        private Vector2 spritePosition;

        // Horizontal Speed
        private int horizontalSpeed;

        // is this a player?
        public ActorType actorType { get; set; }

        // states to keep track of our character
        private Movement motionState;
        private FacingDirection direction;

        // sprite which represents the player. Its just logical to have this here
        private Texture2D idleSprite;

        // private Texture2D walkingSpriteSheet; // this will only be used by the CelAnimationSequence
        
        private CelAnimationSequence walking; // used by the player
        private CelAnimationPlayer walkingPlayer; // used by the player

        /// <summary>
        /// Greedy Constructor
        /// </summary>
        /// <param name="actorType"></param>
        /// <param name="spritePosition"></param>
        /// <param name="idleSprite"></param>
        /// <param name="walkingSpriteSheet"></param>
        /// <param name="walkingSpriteSheetCelDimentions"></param>
        /// <param name="celTime"></param>
        /// <param name="horizontalSpeed"></param>
        /// <param name="initialFacingDirection"></param>
        public Actor(ActorType actorType, Vector2 spritePosition, Texture2D idleSprite, Texture2D walkingSpriteSheet, Vector2 walkingSpriteSheetCelDimentions, float celTime, int horizontalSpeed, FacingDirection initialFacingDirection)
        {
            // initialize this player
            this.spritePosition = spritePosition;
            this.horizontalSpeed = horizontalSpeed;
            this.idleSprite = idleSprite;
            this.actorType = actorType;
            
            // this.walkingSpriteSheet = walkingSpriteSheet; // this will only be used by the CelAnimationSequence

            // determine dimentions of the spritesheet
            int CelWidth = walkingSpriteSheet.Width / (int)walkingSpriteSheetCelDimentions.X;
            int CelHeight = walkingSpriteSheet.Height / (int)walkingSpriteSheetCelDimentions.Y;

            // set up the walking animation sequence
            walking = new CelAnimationSequence(walkingSpriteSheet, CelWidth, CelHeight, celTime);
            
            direction = initialFacingDirection;
            motionState = Movement.Idle;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newPosition"></param>
        public void SetPosition(Vector2 newPosition)
        {
            spritePosition = newPosition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vector2 GetPosition()
        {
            return spritePosition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newSpeed"></param>
        public void SetHorizontalSpeed(int newSpeed)
        {
            horizontalSpeed = newSpeed;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetHorizontalSpeed()
        {
            return horizontalSpeed;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newMotion"></param>
        public void SetMotionState(Movement newMotion)
        {
            motionState = newMotion;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Movement GetMotionState()
        {
            return motionState;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newDirection"></param>
        public void SetFacingDirection(FacingDirection newDirection)
        {
            direction = newDirection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public FacingDirection GetFacingDireciton()
        {
            return direction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Texture2D GetIdleSprite()
        {
            return idleSprite;
        }

        /// <summary>
        /// This object will update itself
        /// </summary>
        public void CaptureInput()
        {
            InputListener.CaptureInput(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartWalkingAnimationPlayer()
        {
            // Set up the animation player
            walkingPlayer = new CelAnimationPlayer();
            walkingPlayer.Play(walking);
        }

        /// <summary>
        /// call in Update after everything else
        /// </summary>
        /// <param name="gameTime"></param>
        public void UpdateWalkingPlayer(GameTime gameTime)
        {
            walkingPlayer.Update(gameTime); // this just queues the next frame of animation
        }

        /// <summary>
        /// call in Draw
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="spritePosition"></param>
        /// <param name="effects"></param>
        public void DrawWalkingAnimationFrame(SpriteBatch spriteBatch, Vector2 spritePosition, SpriteEffects effects)
        {
            walkingPlayer.Draw(spriteBatch, spritePosition, effects);
        }
    }
}
