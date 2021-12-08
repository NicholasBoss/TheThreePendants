using System;

namespace THETHREEPENDANTS.Casting
{
    public class Tries : Actor
    {
        public static int tries = 15;
        public Tries()
        {
            SetText($" Tries left: {tries}");

            Point position = new Point(Constants.MAX_X-160,0);
            SetPosition(position);
        }
    }
}