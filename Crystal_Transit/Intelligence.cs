
/*
This is the superclass of all AIs.
Every sprite/entity should have an intelligence, even the player can have one that gets
input from the keyboard or controller.
Some code could be added into the functions of this class to affect every entity's intelligence.
*/

using System; // Import all modules here

public class Intelligence {
    public Vector2 location; // The position of the entity who owns this intelligence object
    public float speed; // The current speed of the entity who owns this intelligence object
    
    public Intelligence(Vector2 location, float speed = 0) { // Constructor/Initializer
        this.location = location
        this.speed = speed
    }
        
    // This method should be called by the Entity and should be executed every frame
    public virtual void update() {}
    
    // Should be called by the game every time the player's position changes
    // Should return the target position where the entity wants to go and will move in that direction
    public virtual Vector2 playerMovedTo(Vector2 point) {
        return location // Default return is the entity's current location
    }
}


