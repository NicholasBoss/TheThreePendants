# TheThreePendants

In this game you will gather three pendants to unlock the chest using the WASD keys to move.

# Development Environment

VS Code


C#

# Future Work
* Adding Title and end screens
* Settings Menu


# Classes needed:
Actor - this will be handling all actions that the actors can do
Character - This will handle all information for the player character
Pendant - This class will contain all information pertaining to the pendants
Bushes - This class will contain all the trees, bushes and other hiding places for the pendants
Point - This will represent an X,Y pair. Can be used for both velocity and a point.
Program - The base program class will initialize the cast, the script and the game
Director - This will make sure the game runs
Constants - This will set all constant values that the program needs
Action - This will handle all actions that the scripts will take
Map/board - This will draw out the board/map
CheckCollisionsAction - THis will check to see if there are any collisions between the character and the objects
HandleOffScreenAction - This will handle all collision checks with the border of the screen
ControlActorsAction - This will handle all movement given by the user
DrawActorsAction - This will draw all actors on the screen
MoveActorsAction - This will handle all actor movement
AudioService - Will handle all sound input into the game
InputService - Will handle all user input into the game
OutputService - Handles all interaction with the drawing library
PhysicsService - Handles all the physics related parts of the game such as determining collisions
