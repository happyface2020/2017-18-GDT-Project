/*
This is the AI that should be used on all ranged characters.
It will approach the player if the player is close enough and will stop approaching when
within a certain range.
If the player gets to close it will back up.
*/

using System // Import modules

class RangedIntelligence: Intelligence {
    
    // MARK: Properties
    
    private enum TravellingDirection { towards, away } // A type declaration
    
    public const float maximumDistance // Maximum distance that this AI wants to be from the player
    public const float minimumDistance // Minumum distance that this AI wants to be from the player
    
    public const float tolerance // This constant prevents little jumps during a change of position
    
    public const float sightDistance // Maximum distance that this intelligence can see 
    
    // The following values are what "triggers" this intelligence to start moving or stop moving to
    // prevent small jumps in a change of position
    private float triggerMax {
    	get { return maximumDistance + tolerance }
    }
    private float triggerMin { 
    	get { return minimumDistance - tolerance }
    }
    private float triggerSight {
    	get { return sightDistance + tolerance }
    }
    
    // MARK: Initializers
    
    public RangedIntelligence(Vector2 location, float minimumDistance, float maximumDistance, float tolerance, float sightDistance) {
        this.minimumDistance = minimumDistance
        this.maximumDistance = maximumDistance
        
        this.tolerance = tolerance
        this.sightDistance = sightDistance
        
        base(location: location) // I'm pretty sure that in C# argument names can be used when calling functions for better readabilty
    }
    
    // MARK: Methods
    
    public override Vector2 playerMovedTo(Vector2 point) {
        const Vector2 defaultPoint = base.playerMovedTo(point) // Get the default value from superclass
        const float distance = Vector2.distance(value1: point, value2: location) // Find distance between player and entity
        
        if distance >= triggerSight { return defaultPoint } // If player is out of sight return default postion
        
        if (distance > triggerMax) || (distance > maximumDistance && speed > 0) { // Should approach the player
            return getDestinationRelativeTo(point, distanceFromPoint: maximumDistance, travellingDirection: .towards)
        } else if (distance < triggerMin) || (distance < minimumDistance && speed > 0) { // Should move away from the player
            return getDestinationRelativeTo(point, distanceFromPoint: minimumDistance, travellingDirection: .away)
        } else { // Should return default position (basically not move)
            return defaultPoint
        }
    }
    
    private Vector2 getDestinationRelativeTo(Vector2 point, float distanceFromPoint, TravellingDirection travellingDirection) {
        const float xDifference = point.x - location.x // Get the x distance
        const float yDifference = point.y - location.y // Get the y distance
        
        // Find the desired angle in radians to travel, adding pi if wanting to go away from the target instead of towards
        const double angle = Math.Atan2(yDifference, xDifference) + (travellingDirection == .away ? Float(Math.PI) : 0)
        
        // Get the desired x and y coordinates for the desired position based on the AI's constraints
        const double newX = point.x + distanceFromPoint * Math.Cos(angle)
        const double newY = point.y + distanceFromPoint * Math.Sin(angle)
        
        const Vector2 newDestination = Vector2(x: newX, y: newY)
        return newDestination
    }
}