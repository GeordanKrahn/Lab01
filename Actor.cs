﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Created by Geordan Krahn

/*
 * This object is responsible for representing the current actor
 * It contains a position, a speed, direction, actor type, and motion state
 * This player also has an input component, an idle sprite, cel animation sequence for walking, and the cel animation player for walking
 * 
 * Perhaps this should be a base class to the player, enemy and ally types...
 * 
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
        /// <param name="actorType">The type of actor this is</param>
        /// <param name="spritePosition">position in space for this actor</param>
        /// <param name="idleSprite">the idle sprite of this actor</param>
        /// <param name="walkingSpriteSheet">the walking animation sprite sheet for this actor</param>
        /// <param name="walkingSpriteSheetCelDimentions">The dimentions of the spritesheet for the animation as Vector2</param>
        /// <param name="celTime">The time in seconds for each frame of the animation</param>
        /// <param name="horizontalSpeed">the horizontal speed for this actor</param>
        /// <param name="initialFacingDirection">the initial facing direction for this actor</param>
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
