using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


/* Disclaimer
 *
 * The Megaman trademark is the property of Cap-Com
 * I do not own these images. 
 * They have been used here for educational purposes only
 * 
 * The background was aquired from the Unity Asset Store
 * The original creator is Ansimuz
 * 
 */

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D backgroundImage;
        const int CEL_WIDTH = 172; // The dimentions of our cell
        const int CEL_HEIGHT = 172; // this is determined by the animation classes 
        private CelAnimationSequence walking; // - PLAYER
        private CelAnimationPlayer playerAnimator; // - PLAYER

        const float CEL_TIME = 1 / 8.0f;
        const int SCREEN_HEIGHT = 224; // for the boundaries
        const int SCREEN_WIDTH = 384; // for the boundaries
        Player player1; // our player to control. 

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // get the idle sprite for the player
            Texture2D idleSprite = Content.Load<Texture2D>("megaman-idle");
            player1 = new Player(new Vector2(0,0),idleSprite, 2, FacingDirection.Right);
            graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
            graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundImage = Content.Load<Texture2D>("background"); // set up the background image
            
            Texture2D spriteSheet = Content.Load<Texture2D>("mega-man-sprite-sheet");
            walking = new CelAnimationSequence(spriteSheet, CEL_WIDTH, CEL_HEIGHT, CEL_TIME);
            // Set up the animation player
            playerAnimator = new CelAnimationPlayer();
            playerAnimator.Play(walking);
        }

        protected override void Update(GameTime gameTime)
        {
            UpdatePlayer.Update(player1, SCREEN_WIDTH);
            playerAnimator.Update(gameTime); // this just queues the next frame of animation
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundImage, Vector2.Zero, Color.White); // draw background
            UpdatePlayer.Draw(player1, spriteBatch, playerAnimator); // draw our character
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
