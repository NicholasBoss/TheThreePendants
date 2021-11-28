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
            SetHeight(_charheight);
            SetWidth(_charwidth);
            SetImage(_charimg);
            SetPosition(new Point(_charX,_charY));
        }
    }
}