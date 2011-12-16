// Projectile.cs
//Using declarations
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shooter
{
    class Projectile
    {
        // Image representing the Projectile
        public Texture2D Texture;

        // Position of the Projectile relative to the upper left side of the screen
        public Vector2 Position;

        // State of the Projectile
        public bool Active;

        // The amount of damage the projectile can inflict to an enemy
        public int Damage;

        // Represents the viewable boundary of the game
        Viewport viewport;

        // Get the width of the projectile ship
        public int Width
        {
            get { return Texture.Width; }
        }

        // Get the height of the projectile ship
        public int Height
        {
            get { return Texture.Height; }
        }

        // Determines how fast the projectile moves
        float projectileMoveSpeedX;
        float projectileMoveSpeedY;


        public void Initialize(Viewport viewport, Texture2D texture, Vector2 playerPosition, MouseState mouseState)
        {
            Texture = texture;
            Position = playerPosition;
            this.viewport = viewport;

            Active = true;

            Damage = 2;

            float scale = 0.1f;



            projectileMoveSpeedX = Math.Abs(playerPosition.X - mouseState.X) * scale;
            projectileMoveSpeedY = Math.Abs(playerPosition.Y - mouseState.Y) * scale;

            int direction = playerPosition.Y - mouseState.Y > 0 ? -1 : 1;
            if (direction < 0)
                projectileMoveSpeedY = -projectileMoveSpeedY;

            //float hypot = (float)Math.Sqrt(Math.Pow(playerPosition.Y - mouseState.Y, 2) + Math.Pow(playerPosition.X - mouseState.X, 2));
            
            Position.Y = playerPosition.Y;





        }
        
        public void Update(MouseState mouseState, Vector2 playerPosition)
        {
            // Projectiles always move to the right
            Position.X += projectileMoveSpeedX;
            Position.Y += projectileMoveSpeedY;

            // Deactivate the bullet if it goes out of screen
            if (Position.X + Texture.Width / 2 > viewport.Width)
                Active = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0f,
            new Vector2(Width / 2, Height / 2), 1f, SpriteEffects.None, 0f);
        }
    }
}
