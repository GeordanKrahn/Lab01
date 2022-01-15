using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D backgroundImage;
        const int CEL_WIDTH = 172; // The dimentions of our cell
        // const int CEL_HEIGHT = 171; this is determined by the animation classes 
        private Texture2D idleSprite; // - PLAYER
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
            
            player1 = new Player(new Vector2(0,0), 2, FacingDirection.Right);
            graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
            graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundImage = Content.Load<Texture2D>("background"); // set up the background image
            idleSprite = Content.Load<Texture2D>("megaman-idle");
            Texture2D spriteSheet = Content.Load<Texture2D>("mega-man-sprite-sheet");
            walking = new CelAnimationSequence(spriteSheet, CEL_WIDTH, CEL_TIME);
            // Set up the animation player
            playerAnimator = new CelAnimationPlayer();
            playerAnimator.Play(walking);
        }

        protected override void Update(GameTime gameTime)
        {
            UpdatePlayer();
            playerAnimator.Update(gameTime); // this just queues the next frame of animation
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundImage, Vector2.Zero, Color.White); // draw background
            DrawPlayer(); // draw our character
            spriteBatch.End();
            base.Draw(gameTime);
        }

        // This will keep track of and update the states and position of our character and listen for input.
        public void UpdatePlayer()
        {
            player1.CaptureInput();
            int horizontalPosition = (int)player1.Position().X;
            int spriteWidth = idleSprite.Width;
            // if we are out of the play area, reset the position 
            if ( horizontalPosition > SCREEN_WIDTH - spriteWidth)
            {
                // We have gone too far too the right, reset position to just back inside
                player1.UpdatePosition(new Vector2(SCREEN_WIDTH - spriteWidth - player1.HorizontalSpeed(), player1.Position().Y));
            }
            else if (horizontalPosition < spriteWidth)
            {
                player1.UpdatePosition(new Vector2(spriteWidth + player1.HorizontalSpeed(), player1.Position().Y));
            }
            else
            {
                Movement motionState = player1.Motion();
                if (motionState == Movement.Walking)
                {
                    FacingDirection direction = player1.Direction();
                    if (direction == FacingDirection.Right)
                    {
                        player1.UpdatePosition(new Vector2(horizontalPosition + player1.HorizontalSpeed(), player1.Position().Y));
                    }
                    else if (direction == FacingDirection.Left)
                    {
                        player1.UpdatePosition(new Vector2(horizontalPosition - player1.HorizontalSpeed(), player1.Position().Y));
                    }
                }
            }
        }

        // This will draw the scene each frame. Draw either the idle state or walking state and animation based on whether we are moving
        public void DrawPlayer()
        {
            Movement motionState = player1.Motion();
            FacingDirection direction = player1.Direction();
            Vector2 spritePosition = player1.Position();
            if (motionState == Movement.Idle)
            {
                if (direction == FacingDirection.Right)
                {
                    spriteBatch.Draw(idleSprite, spritePosition, Color.White);
                }
                else if (direction == FacingDirection.Left)
                {
                    spriteBatch.Draw(idleSprite, spritePosition, null, Color.White,0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
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
