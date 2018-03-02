using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal_Transit
{
    class Enemy : Sprite
    {
        public Sprite target;
        private Vector2 lastPositionOfTarget = Vector2.Zero;
        public int movementSpeed = 150;
        private Vector2 targetPosition;

        public Enemy(Sprite targetEntity)
        {
            this.target = targetEntity;
        }

        //public static Archer archer = new Archer(Vector2.Zero, 1, 5, 0.25, 8);
        // This method should be called by the Entity and should be executed every frame
        public override void Update(GameTime gameTime)
        {
            if (target.position != lastPositionOfTarget)
            {
                targetPosition = targetMovedTo(target.position);

            }

            //float angle = Math.Atan2(targetPosition.Y - position.Y, targetPosition.X - position.X);
            Vector2 movement = targetPosition - position;
            if (movement != Vector2.Zero)
            {
                movement.Normalize();
            }
            position = movement * (float)movementSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //position = target.position; follows the hero now
            lastPositionOfTarget = target.position;
        }

        // Should be called by the game every time the target entity's position changes
        // Should return the target position where the entity wants to go and will move in that direction
        public virtual Vector2 targetMovedTo(Vector2 point)
        {
            return target.position; // Default return is the entity's current location
        }
    }
}
