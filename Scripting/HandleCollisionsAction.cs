using System.Collections.Generic;
using THETHREEPENDANTS.Casting;
using THETHREEPENDANTS.Services;
using System.Linq;

namespace THETHREEPENDANTS.Scripting
{
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
            Actor ball = cast["balls"][0];
            List<Actor> Bricks = cast["bricks"];

            List<Actor> paddles = cast["paddle"];
            List<Actor> bricks = cast["bricks"];

            List<Actor> bricksToRemove = new List<Actor>();

            foreach(Actor actor in paddles)
            {
                Character paddle = (Character)actor;
                if(_physicsService.IsCollision(ball,paddle))
                {
                    _audioService.PlaySound(Constants.SOUND_BOUNCE);
                    ball.ChangeVelocityY();
                }
            }

            foreach(Actor actor in bricks)
            {
                Pendant brick = (Pendant)actor;
                if(_physicsService.IsCollision(ball,brick))
                {
                    _audioService.PlaySound(Constants.SOUND_BOUNCE);
                    ball.ChangeSpeed();

                    bricksToRemove.Add(brick);

                }
            }

            foreach(Actor brick in bricksToRemove)
            {
                cast["bricks"].Remove(brick);
            }
            static bool IsEmpty<Actor>(List<Actor> Bricks)
            {
                if (Bricks == null) {
                    return true;
                }
        
                return !Bricks.Any();
            }
            if (IsEmpty(Bricks))
            {
                Raylib_cs.Raylib.CloseWindow();
            }
        }
    }
}