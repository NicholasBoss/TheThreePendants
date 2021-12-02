using System;

namespace THETHREEPENDANTS
{
    /// <summary>
    /// This is a set of program wide constants to be used in other classes.
    /// </summary>
    public static class Constants
    {
        public const int MAX_X = 800;
        public const int MAX_Y = 600;
        public const int FRAME_RATE = 50;

        public const int DEFAULT_SQUARE_SIZE = 20;
        public const int DEFAULT_FONT_SIZE = 20;
        public const int DEFAULT_TEXT_OFFSET = 4;

        public const int NUM_BUSHES = 20;
        public const string DEFAULT_BILLBOARD_MESSAGE = "Find the three pendants";

        // Images for the game will be initialized here
        public const string IMAGE_CHARACTER = "./Assets/bluebox.png";


        // Sounds for the game will be initialized here
        
        //Speed and position of the actors will be initialized here
        public const int CHARACTER_X = MAX_X / 2;
        public const int CHARACTER_Y = MAX_Y - 125;

        public const int CHARACTER_WIDTH = 33;
        public const int CHARACTER_HEIGHT = 33;

        public const int PADDLE_SPEED = 10;

        public const string MESSAGE_FILE = "messages.txt";
    }

}