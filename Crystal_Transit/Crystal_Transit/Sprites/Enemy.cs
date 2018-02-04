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
                targetMovedTo(target.position);
            }
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
