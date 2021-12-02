using System.Collections.Generic;
using THETHREEPENDANTS.Casting;
using THETHREEPENDANTS.Services;

namespace THETHREEPENDANTS.Casting
{
    ///<summary>
    /// This class will handle all needed action with implementing the character of the game
    ///<summary>
    public class Character : Actor
    {
        private string _charimg = Constants.IMAGE_CHARACTER;
        private int _charwidth = Constants.CHARACTER_WIDTH;
        private int _charheight = Constants.CHARACTER_HEIGHT;
        private int _charX = Constants.CHARACTER_X;
        private int _charY = Constants.CHARACTER_Y;
        public Character()
        {
            SetImage(_charimg);
            // SetText("#");
            int x = Constants.MAX_X / 2;
            int y = Constants.MAX_Y / 2;
            Point position = new Point(x, y);
            SetPosition(position);

            SetVelocity(new Point(1, 0));
        }
    }
}