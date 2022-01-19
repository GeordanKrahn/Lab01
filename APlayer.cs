using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    /// <summary>
    /// This player also has an input component, cel animation sequence for walking, and the cel animation player for walking
    /// </summary>
    public class APlayer : AActor
    {
        private CelAnimationSequence walking; // used by the player
        private CelAnimationPlayer walkingPlayer; // used by the player
        private int horizontalSpeed;

        /// <summary>
        /// Greedy Constructor chained to the base constructor.
        /// </summary>
        /// <param name="spritePosition">position in space for this actor</param>
        /// <param name="idleSprite">the idle sprite of this actor</param>
        /// <param name="walkingSpriteSheet">the walking animation sprite sheet for this actor</param>
        /// <param name="walkingSpriteSheetCelDimentions">The "Cel" dimentions of the spritesheet for the animation. 
        /// It is very important to note that this applies to each FRAME of the sprite sheet, and NOT the physical dimentions </param>
        /// <param name="celTime">The time in seconds for each frame of the animation</param>
        /// <param name="horizontalSpeed">the horizontal speed for this actor</param>
        /// <param name="initialFacingDirection">the initial facing direction for this actor</param>
        public APlayer(Vector2 spritePosition, Texture2D idleSprite, Texture2D walkingSpriteSheet, Rectangle walkingSpriteSheetCelDimentions, float celTime, int horizontalSpeed, EFacingDirection initialFacingDirection)
             : base(spritePosition, idleSprite, initialFacingDirection)
        {
            this.horizontalSpeed = horizontalSpeed;   
            // determine dimentions of the spritesheet
            int CelWidth = walkingSpriteSheet.Width / walkingSpriteSheetCelDimentions.Width;
            int CelHeight = walkingSpriteSheet.Height / walkingSpriteSheetCelDimentions.Height;

            // set up the walking animation sequence
            walking = new CelAnimationSequence(walkingSpriteSheet, CelWidth, CelHeight, celTime);
        }

        /// <summary>
        /// Sets the new horizontalSpeed for this actor
        /// </summary>
        /// <param name="newSpeed">the new horizontal speed</param>
        public void SetHorizontalSpeed(int newSpeed)
        {
            horizontalSpeed = newSpeed;
        }

        /// <summary>
        /// Returns the current horizontalSpeed for this actor
        /// </summary>
        /// <returns>int</returns>
        public int GetHorizontalSpeed()
        {
            return horizontalSpeed;
        }

        /// <summary>
        /// Starts the walking animation player for this player
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
        /// <param name="gameTime">The current GameTime object</param>
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

        /// <summary>
        /// Listens for input for this player
        /// </summary>
        public void CaptureInput()
        {
            InputListener.CaptureInput(this);
        }
    }
}
