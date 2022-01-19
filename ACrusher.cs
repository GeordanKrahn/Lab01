using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace Project1
{
    public class ACrusher : AActor
    {
        private CelAnimationSequence crushing;
        private CelAnimationPlayer crusher;

        public ACrusher(Vector2 spritePosition, Texture2D sprite, Texture2D crushingSpriteSheet, Rectangle crushingSpriteSheetCelDimentions, float celTime, EFacingDirection initialFacingDirection)
            : base(spritePosition, sprite, initialFacingDirection)
        {
            // determine dimentions of the spritesheet
            int CelWidth = crushingSpriteSheet.Width / crushingSpriteSheetCelDimentions.Width;
            int CelHeight = crushingSpriteSheet.Height / crushingSpriteSheetCelDimentions.Height;

            // set up the walking animation sequence
            crushing = new CelAnimationSequence(crushingSpriteSheet, CelWidth, CelHeight, celTime);
        }

        /// <summary>
        /// Starts the walking animation player for this player
        /// </summary>
        public void StartAnimationPlayer()
        {
            // Set up the animation player
            crusher = new CelAnimationPlayer();
            crusher.Play(crushing);
        }

        /// <summary>
        /// call in Update after everything else
        /// </summary>
        /// <param name="gameTime">The current GameTime object</param>
        public void UpdateAnimationPlayer(GameTime gameTime)
        {
            crusher.Update(gameTime); // this just queues the next frame of animation
        }

        /// <summary>
        /// call in Draw
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="spritePosition"></param>
        /// <param name="effects"></param>
        public void DrawAnimationFrame(SpriteBatch spriteBatch, Vector2 spritePosition, SpriteEffects effects)
        {
            crusher.Draw(spriteBatch, spritePosition, effects);
        }
    }
}
