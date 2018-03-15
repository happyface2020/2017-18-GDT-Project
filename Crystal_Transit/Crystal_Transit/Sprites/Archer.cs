using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal_Transit
{
    class Archer : Enemy //(ranged)
    {
        private enum TravellingDirection { towards, away } // A type declaration

        public float maximumDistance; // Maximum distance that this AI wants to be from the player
        public float minimumDistance; // Minumum distance that this AI wants to be from the player

        public float tolerance; // This constant prevents little jumps during a change of position

        public float sightDistance; // Maximum distance that this intelligence can see 

        public Vector2 movement;

        // The following values are what "triggers" this intelligence to start moving or stop moving to
        // prevent small jumps in a change of position
        private float triggerMax
        {
            get { return maximumDistance + tolerance; }
        }
        private float triggerMin
        {
            get { return minimumDistance - tolerance; }
        }
        private float triggerSight
        {
            get { return sightDistance + tolerance; }
        }

        public Archer(Sprite targetEntity, float minimumDistance, float maximumDistance, float tolerance, float sightDistance)
            :base(targetEntity)
        {
            this.minimumDistance = minimumDistance;
            this.maximumDistance = maximumDistance;

            this.tolerance = tolerance;
            this.sightDistance = sightDistance;

            //base(targetEntity: targetEntity); // I'm pretty sure that in C# argument names can be used when calling functions for better readabilty
        }

        public override void Update(GameTime gameTime)
        {
            if (target.position != this.lastPositionOfTarget)
            {
                targetPosition = targetMovedTo(target.position);
            }

            //float angle = Math.Atan2(targetPosition.Y - position.Y, targetPosition.X - position.X);
            movement = targetPosition - position;
            if (movement != Vector2.Zero)
            {
                movement.Normalize();
            }
            position += movement * (float)movementSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            lastPositionOfTarget = targetPosition;
        }

        public override Vector2 targetMovedTo(Vector2 point)
        {
            Vector2 defaultPoint = base.targetMovedTo(point); // Get the default value from superclass
            float distance = Vector2.Distance(point, position); // Find distance between player and entity

            if (distance >= triggerSight) { return defaultPoint; } // If player is out of sight return default postion

            if ((distance > triggerMax) || ((distance > maximumDistance) && (movementSpeed > 0)))
            { // Should approach the player
                return getDestinationRelativeTo(point, distanceFromPoint: maximumDistance, travellingDirection: TravellingDirection.towards);
            }
            else if ((distance < triggerMin) || ((distance < minimumDistance) && (movementSpeed > 0)))
            { // Should move away from the player
                return getDestinationRelativeTo(point, distanceFromPoint: minimumDistance, travellingDirection: TravellingDirection.away);
            }
            else
            { // Should return default position (basically not move)
                return defaultPoint;
            }
        }

        private Vector2 getDestinationRelativeTo(Vector2 point, float distanceFromPoint, TravellingDirection travellingDirection)
        {
            float xDifference = point.X - position.X; // Get the x distance
            float yDifference = point.Y - position.Y; // Get the y distance

            // Find the desired angle in radians to travel, adding pi if wanting to go away from the target instead of towards
            float angle = (float)Math.Atan2(yDifference, xDifference) + (travellingDirection == TravellingDirection.away ? (float)(Math.PI) : 0);

            // Get the desired x and y coordinates for the desired position based on the AI's constraints
            float newX = (float)(point.X + distanceFromPoint * Math.Cos(angle));
            float newY = (float)(point.Y + distanceFromPoint * Math.Sin(angle));

            Vector2 newDestination = new Vector2(x: newX, y: newY);
            return newDestination;
        }
    }
}
