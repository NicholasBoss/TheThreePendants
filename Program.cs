﻿using System;
using THETHREEPENDANTS.Services;
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

            // Bricks
            cast["bricks"] = new List<Actor>();

            // TODO: Add your bricks here

            // int spacing = Constants.BRICK_WIDTH + Constants.BRICK_SPACE;
            // int vert_spacing = Constants.BRICK_HEIGHT + Constants.BRICK_SPACE;

            // for (int x = 0; x < Constants.MAX_X - Constants.BRICK_WIDTH; x+= spacing)
            {
                // for (int y = 0; y < 150; y+= vert_spacing)
                {
                    // Pendant brick = new Pendant();
                    // brick.SetPosition(new Point(x,y));
                    // cast["bricks"].Add(brick);
                }
                
            }

            // The Ball (or balls if desired)
            cast["balls"] = new List<Actor>();

            // TODO: Add your ball here
            Bushes ball = new Bushes();
            // ball.SetPosition(new Point(Constants.BALL_X,Constants.BALL_Y));
            // cast["balls"].Add(ball);

            // The paddle
            cast["paddle"] = new List<Actor>();

            // TODO: Add your paddle here
            Character paddle = new Character();
            cast["paddle"].Add(paddle);

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

            // TODO: Add additional actions here to handle the input, move the actors, handle collisions, etc.
            MoveActorsAction moveActorsAction = new MoveActorsAction();
            script["update"].Add(moveActorsAction);
            HandleOffScreenAction handleOffScreenAction = new HandleOffScreenAction(audioService);
            script["update"].Add(handleOffScreenAction);
            ControlActorsAction controlActorsAction = new ControlActorsAction(inputService);
            script["update"].Add(controlActorsAction);
            HandleCollisionsAction handleCollisionsAction = new HandleCollisionsAction(physicsService, audioService);
            script["update"].Add(handleCollisionsAction);

            // Start up the game
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Batter", Constants.FRAME_RATE);
            audioService.StartAudio();
            // audioService.PlaySound(Constants.SOUND_START);

            Director theDirector = new Director(cast, script);
            theDirector.Direct();

            audioService.StopAudio();
        }
    }
}
