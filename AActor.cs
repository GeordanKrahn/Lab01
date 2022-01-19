using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Created by Geordan Krahn

namespace Project1
{
    /// <summary>
    /// This object is responsible for representing the current actor
    /// It contains a position, facing direction, motion state and sprite.
    /// </summary>
    public class AActor
    {
        // This will be used to draw the idle sprite or animate the sprite sheet at a point.
        private Vector2 position;

        // states to keep track of our character
        private EMovement motionState;
        private EFacingDirection facingDirection;

        // sprite which represents the actor.
        protected Texture2D sprite;

        /// <summary>
        /// Greedy Constructor
        /// </summary>
        /// <param name="spritePosition">position in space for this actor</param>
        /// <param name="idleSprite">the idle sprite of this actor</param>
        /// <param name="initialFacingDirection">the initial facing direction for this actor</param>
        public AActor(Vector2 position, Texture2D sprite, EFacingDirection facingDirection)
        {
            // initialize this player
            this.position = position;
            this.sprite = sprite;
            this.facingDirection = facingDirection;
            motionState = EMovement.Idle;
        }

        /// <summary>
        /// provide a new position for our actor
        /// </summary>
        /// <param name="newPosition">the new position we want our actor to be set at.</param>
        public void SetPosition(Vector2 newPosition)
        {
            position = newPosition;
        }

        /// <summary>
        /// Returns the current position of this actor
        /// </summary>
        /// <returns>Vector2</returns>
        public Vector2 GetPosition()
        {
            return position;
        }

        /// <summary>
        /// Sets the new motionState for this actor.
        /// </summary>
        /// <param name="newMotion">The EMovement state for this actor</param>
        public void SetMotionState(EMovement newMotion)
        {
            motionState = newMotion;
        }

        /// <summary>
        /// Returns the current motionState for this object
        /// </summary>
        /// <returns>EMovement</returns>
        public EMovement GetMotionState()
        {
            return motionState;
        }

        /// <summary>
        /// Sets the facingDirection for this actor
        /// </summary>
        /// <param name="newDirection">The new direction to face</param>
        public void SetFacingDirection(EFacingDirection newDirection)
        {
            facingDirection = newDirection;
        }

        /// <summary>
        /// Returns the facingDirection for this actor
        /// </summary>
        /// <returns>EFacingDirection</returns>
        public EFacingDirection GetFacingDireciton()
        {
            return facingDirection;
        }

        /// <summary>
        /// Returns the sprite which represents this actor
        /// </summary>
        /// <returns>Texture2D</returns>
        public Texture2D GetSprite()
        {
            return sprite;
        }
    }
}
