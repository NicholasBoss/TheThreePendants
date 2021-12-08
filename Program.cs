﻿using THETHREEPENDANTS.Services;
using THETHREEPENDANTS.Casting;
using THETHREEPENDANTS.Scripting;
using System.Collections.Generic;

namespace THETHREEPENDANTS
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the cast
            Dictionary<string, List<Actor>> cast = new Dictionary<string, List<Actor>>();

            //Environment Objects
            cast["environment"] = new List<Actor>();

            Billboard billboard = new Billboard();
            cast["environment"].Add(billboard);

            Tries tries = new Tries();
            cast["environment"].Add(tries);

            // Stationary Objects
            cast["bushes"] = new List<Actor>();

            cast["pendants"] = new List<Actor>();
            cast["chest"] = new List<Actor>();

            BushesGenerator generator = new BushesGenerator();

            Bush pendant1 = generator.Generate();
            pendant1.SetDescription("You have found the first pendant");
            cast["pendants"].Add(pendant1);
            Bush pendant2 = generator.Generate();
            pendant2.SetDescription("You have found the second pendant");
            cast["pendants"].Add(pendant2);
            Bush pendant3 = generator.Generate();
            pendant3.SetDescription("You have found the third pendant");
            cast["pendants"].Add(pendant3);

            for (int i = 0; i < Constants.NUM_BUSHES; i++)
            {
                Bush bush = generator.Generate();
                cast["bushes"].Add(bush);
            }
            
            Chest chest = new Chest();
            cast["chest"].Add(chest);

            // The player
            cast["character"] = new List<Actor>();

            Character character = new Character();
            cast["character"].Add(character);

            // Create the script
            Dictionary<string, List<Action>> script = new Dictionary<string, List<Action>>();

            OutputService outputService = new OutputService();
            InputService inputService = new InputService();
            PhysicsService physicsService = new PhysicsService();
            AudioService audioService = new AudioService();

            script["output"] = new List<Action>();
            script["input"] = new List<Action>();
            script["update"] = new List<Action>();

            DrawActorsAction drawActorsAction = new DrawActorsAction(outputService);
            script["output"].Add(drawActorsAction);

            // The actions here are to handle the input, move the actors, handle collisions, etc.
            MoveActorsAction moveActorsAction = new MoveActorsAction();
            script["update"].Add(moveActorsAction);

            ControlActorsAction controlActorsAction = new ControlActorsAction(inputService);
            script["update"].Add(controlActorsAction);

            HandleCollisionsAction handleCollisionsAction = new HandleCollisionsAction(physicsService, audioService);
            script["update"].Add(handleCollisionsAction);

            // Start up the game
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "The Three Pendants", Constants.FRAME_RATE);
            audioService.StartAudio();
            audioService.PlaySound(Constants.SOUND_START);

            Director theDirector = new Director(cast, script);
            theDirector.Direct();

            audioService.StopAudio();
        }
    }
}
