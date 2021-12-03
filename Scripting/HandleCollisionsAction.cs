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
            Actor chest = cast["chest"][0];
            
            List<Actor> bushes = cast["bushes"];
            List<Actor> pendants = cast["pendants"];
            List<Actor> bushesToRemove = new List<Actor>();

            billboard.SetText(Constants.DEFAULT_BILLBOARD_MESSAGE);

            // This checks to see if the player collides with a bush
            foreach(Actor actor in bushes)
            {
                Bush bush = (Bush)actor;
                if(_physicsService.IsCollision(character, bush))
                {
                    // _audioService.PlaySound(Constants.SOUND_LEAF);
                    string bushText = bush.GetDescription();
                    billboard.SetText(bushText);
                    bushesToRemove.Add(bush);
                }
            }

            // This will be a lose condition if I can get it to work
            // if(bushes.Count == Constants.NUM_BUSHES-15)
            // {
            //     _audioService.PlaySound(Constants.SOUND_LOSE);
            //     billboard.SetText("Sorry, you lose. Press 'ESC' to leave the game.\n Better luck next time");
            //     System.Threading.Thread.Sleep(2000);
            //     Raylib_cs.Raylib.CloseWindow();
            // }

            foreach(Actor bush in bushesToRemove)
            {
                cast["bushes"].Remove(bush);
            }

            // This checks to see if the player collides with a pendant hiding spot
            foreach (Actor actor in pendants)
            {
                Bush pendant1 = (Bush)pendants[0];
                Bush pendant2 = (Bush)pendants[1];
                Bush pendant3 = (Bush)pendants[2];
                
                if(_physicsService.IsCollision(character,pendant1))
                {
                    // _audioService.PlaySound(Constants.SOUND_PENDANT1);
                    string pendantText = pendant1.GetDescription();
                    billboard.SetText(pendantText);
                    pendant1.SetImage(Constants.IMAGE_PENDANT);
                    pendant1.IsFound();
                    
                }
                if(_physicsService.IsCollision(character,pendant2))
                {
                    // _audioService.PlaySound(Constants.SOUND_PENDANT2);
                    string pendantText1 = pendant2.GetDescription();
                    billboard.SetText(pendantText1);
                    pendant2.SetImage(Constants.IMAGE_PENDANT1);
                    pendant2.IsFound();
                    
                }
                if(_physicsService.IsCollision(character,pendant3))
                {
                    // _audioService.PlaySound(Constants.SOUND_PENDANT3);
                    string pendantText2 = pendant3.GetDescription();
                    billboard.SetText(pendantText2);
                    pendant3.SetImage(Constants.IMAGE_PENDANT2);
                    pendant3.IsFound();
                    
                }

                
            }
            
            // This loop is to check for images to handle the win condition
            foreach(Actor actor in pendants)
            {
                Actor pendant1 = pendants[0];
                Actor pendant2 = pendants[1];
                Actor pendant3 = pendants[2];

                if(pendant1.GetImage() == Constants.IMAGE_PENDANT && pendant2.GetImage() == Constants.IMAGE_PENDANT1 && pendant3.GetImage() == Constants.IMAGE_PENDANT2)
                {
                    billboard.SetText("You have found all three pendants. Open the chest to Win! \n Press 'ESC' to leave the game");
                    chest.SetImage(Constants.IMAGE_CHEST);
                    chest.SetHeight(33);
                    chest.SetWidth(33);
                }
            }
            if(_physicsService.IsCollision(character,chest))
            {
                // _audioService.PlaySound(Constants.SOUND_WIN);
            }

        }
    }
}