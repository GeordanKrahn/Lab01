using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


/* Disclaimer
 *
 * The Megaman trademark is the property of Cap-Com
 * I do not own these images. 
 * They have been used here for educational purposes only
 * 
 * The background png was acquired from the Unity Asset Store
 * The original creator is Ansimuz
 * 
 */

namespace Project1
{
    public class Demo : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D backgroundImage;

        const float CEL_TIME = 1 / 8.0f;
        readonly Vector2 SpriteSheetCelDimentions = new Vector2(5, 2);
        const int SCREEN_HEIGHT = 224; // for the boundaries
        const int SCREEN_WIDTH = 384; // for the boundaries
        Actor player; // our player to control. 

        public Demo()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
            graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // get the idle sprite and spritesheets for the player
            Texture2D idleSprite = Content.Load<Texture2D>("megaman-idle");
            Texture2D spriteSheet = Content.Load<Texture2D>("mega-man-sprite-sheet");

            // create the player
            player = new Actor(ActorType.Player, new Vector2(0, 0), idleSprite, spriteSheet, SpriteSheetCelDimentions, CEL_TIME, 2, FacingDirection.Right);
            player.StartWalkingAnimationPlayer(); // start the animation player in player

            // Set the background
            spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundImage = Content.Load<Texture2D>("background"); // set up the background image
        }

        protected override void Update(GameTime gameTime)
        {
            UpdateActor.Update(player, SCREEN_WIDTH, gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundImage, Vector2.Zero, Color.White); // draw background
            UpdateActor.Draw(player, spriteBatch); // draw our character
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
