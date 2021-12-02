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
        private int pendant_counter = 0;
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
            List<Actor> pendants = cast["pendants"];

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

            foreach (Actor actor in pendants)
            {
                Bush pendant1 = (Bush)pendants[0];
                Bush pendant2 = (Bush)pendants[1];
                Bush pendant3 = (Bush)pendants[2];
                
                if(_physicsService.IsCollision(character,pendant1))
                {

                    string pendantText = pendant1.GetDescription();
                    billboard.SetText(pendantText);
                    pendant1.SetImage(Constants.IMAGE_PENDANT);
                    pendant1.IsFound();
                    
                }
                if(_physicsService.IsCollision(character,pendant2))
                {

                    string pendantText1 = pendant2.GetDescription();
                    billboard.SetText(pendantText1);
                    pendant2.SetImage(Constants.IMAGE_PENDANT1);
                    pendant2.IsFound();
                    
                }
                if(_physicsService.IsCollision(character,pendant3))
                {

                    string pendantText2 = pendant3.GetDescription();
                    billboard.SetText(pendantText2);
                    pendant3.SetImage(Constants.IMAGE_PENDANT2);
                    pendant3.IsFound();
                    
                }
            }
            
            foreach(Actor actor in pendants)
            {
                Actor pendant1 = pendants[0];
                Actor pendant2 = pendants[1];
                Actor pendant3 = pendants[2];
                if(pendant1.GetImage() == Constants.IMAGE_PENDANT && pendant2.GetImage() == Constants.IMAGE_PENDANT1 && pendant3.GetImage() == Constants.IMAGE_PENDANT2)
                {
                    billboard.SetText("You have found all three pendants. You Win!");
                }
            }

        }
    }
}