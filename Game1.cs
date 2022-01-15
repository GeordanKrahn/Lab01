using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D backgroundImage;
        const int CEL_WIDTH = 172; // The dimentions of our cell
        // const int CEL_HEIGHT = 171; this is determined by the animation classes
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
            Texture2D idleSprite = Content.Load<Texture2D>("megaman-idle");
            Texture2D spriteSheet = Content.Load<Texture2D>("mega-man-sprite-sheet");
            CelAnimationSequence sequence = new CelAnimationSequence(spriteSheet, CEL_WIDTH, CEL_TIME);
            player1 = new Player(new Vector2(SCREEN_WIDTH / 2, SCREEN_HEIGHT / 2), 2, idleSprite, new CelAnimationPlayer(), sequence, FacingDirection.Right);
            graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
            graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundImage = Content.Load<Texture2D>("background"); // set up the background image
        }

        protected override void Update(GameTime gameTime)
        {
            player1.Update(gameTime, SCREEN_WIDTH, SCREEN_HEIGHT);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundImage, Vector2.Zero, Color.White); // draw background
            player1.Draw(spriteBatch); // draw our character
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
