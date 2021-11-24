using System.Collections.Generic;
using THETHREEPENDANTS.Casting;
using THETHREEPENDANTS.Services;

namespace THETHREEPENDANTS
{
    public class ControlActorsAction : Action
    {
        InputService _inputService;

        public ControlActorsAction(InputService inputService)
        {
            _inputService = inputService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Point direction = _inputService.GetDirection();
            
            Actor paddle = cast["paddle"][0];

            Point velocity = direction.Scale(Constants.PADDLE_SPEED);
            paddle.SetVelocity(velocity);
        }
    }
}