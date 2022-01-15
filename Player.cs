using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Project1
{
    class Player
    {
        // This will be used to draw the idle sprite or animate the sprite sheet at a point.
        private Vector2 spritePosition;

        // Horizontal Speed
        private int horizontalSpeed;

        // states to keep track of our character
        private Movement motionState;
        private FacingDirection direction;

        // Greedy Constructor
        public Player(Vector2 spritePosition, int horizontalSpeed, FacingDirection initialFacingDirection)
        {
            // initialize this player
            this.spritePosition = spritePosition;
            this.horizontalSpeed = horizontalSpeed;
            direction = initialFacingDirection;
            motionState = Movement.Idle;
        }

        // accessors
        public void UpdatePosition(Vector2 newPosition)
        {
            spritePosition = newPosition;
        }

        public Vector2 Position()
        {
            return spritePosition;
        }

        public void UpdateHorizontalSpeed(int newSpeed)
        {
            horizontalSpeed = newSpeed;
        }
        public int HorizontalSpeed()
        {
            return horizontalSpeed;
        }

        public void UpdateMotionState(Movement newMotion)
        {
            motionState = newMotion;
        }
        public Movement Motion()
        {
            return motionState;
        }

        public void UpdateDirection(FacingDirection newDirection)
        {
            direction = newDirection;
        }
        public FacingDirection Direction()
        {
            return direction;
        }

        public void CaptureInput()
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
    }
}
