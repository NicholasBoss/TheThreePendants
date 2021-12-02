using System.Collections.Generic;
using THETHREEPENDANTS.Casting;
using THETHREEPENDANTS.Services;

namespace THETHREEPENDANTS.Scripting
{
    ///<summary>
    /// This class will control how each actor will act when collided with.
    ///<summary>
    public class HandleCollisionsAction : Action
    {
        PhysicsService _physicsService;
        AudioService _audioService;

        public HandleCollisionsAction(PhysicsService physicsService, AudioService audioService)
        {
            _physicsService = physicsService;
            _audioService = audioService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Actor billboard = cast["environment"][0];
            Actor character = cast["character"][0];
            
            List<Actor> bushes = cast["bushes"];

            billboard.SetText(Constants.DEFAULT_BILLBOARD_MESSAGE);

            foreach(Actor actor in bushes)
            {
                Bush bush = (Bush)actor;
                if(_physicsService.IsCollision(character, bush))
                {
                    string bushText = bush.GetDescription();
                    billboard.SetText(bushText);
                }
            }

        }
    }
}