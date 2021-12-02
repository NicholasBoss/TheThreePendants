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
        private int pendant_counter = 0;
        AudioService _audioService;
        public HandleOffScreenAction(AudioService audioService)
        {
            _audioService = audioService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            
        }
    }
}