using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lab01
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        // This will be used to draw the idle sprite or animate the sprite sheet at a point.
        Vector2 spritePosition;

        // These images will fill the scene.
        Texture2D backgroundImage;
        Texture2D idleSprite; // for our character.
        CelAnimationSequence walking;
        CelAnimationPlayer playerAnimator;

        // for the boundaries
        float screenHeight;
        float screenWidth;
        float floorHeight; // our character needs to "walk" on this

        // states to keep track of our character
        MovementState currentState;
        FacingDirection direction;

        // State for whether we are moving or not.
        enum MovementState
        {
            Idle = 0,
            Walking = 1
        }

        // Need a facing direction. If facing right, keep sprite orientation
        // If facing left flip the image - -1 scale should work.
        enum FacingDirection
        {
            Right = 0,
            Left = 1
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Texture2D spriteSheet = 
        }

        protected override void Update(GameTime gameTime)
        {
            // This will keep track of and update the states and position of our character and listen for input.
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // This will draw the scene each frame. Draw either the idle state or walking state and animation based on whether we are moving
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }
    }
}
