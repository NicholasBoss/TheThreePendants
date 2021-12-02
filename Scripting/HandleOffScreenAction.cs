using System;
using System.Collections.Generic;
using THETHREEPENDANTS.Casting;
using THETHREEPENDANTS.Services;

namespace THETHREEPENDANTS.Scripting
{
    ///<summary>
    /// This class will control how each actor will act when it interacts with the edge of the screen
    ///<summary>
    public class HandleOffScreenAction : Action
    {
        AudioService _audioService;
        public HandleOffScreenAction(AudioService audioService)
        {
            _audioService = audioService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            List<Actor> balls = cast["bushes"];

            //if ball position is off the screen, change its velocity.
            foreach (Actor ball in balls)
            {
                if(ball.GetRightEdge() >= Constants.MAX_X || ball.GetLeftEdge() <= 0)
                {
                    // _audioService.PlaySound(Constants.SOUND_BOUNCE);
                    ball.ChangeVelocityX();
                }
                if(ball.GetTopEdge() <= 0)
                {
                    // _audioService.PlaySound(Constants.SOUND_BOUNCE);
                    ball.ChangeVelocityY();
                }
                if(ball.GetBottomEdge() >= Constants.MAX_Y)
                {
                    // _audioService.PlaySound(Constants.SOUND_BOUNCE);
                    ball.ChangeVelocityY();
                }
                
                
            }
        }
    }
}