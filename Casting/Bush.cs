namespace THETHREEPENDANTS.Casting
{
    ///<summary>
    /// This class will handle all actions with the generation of hiding spots for the pendants
    ///<summary>
    public class Bush : Actor
    {
        private string _description;

        public Bush()
        {
            SetText("?");
            SetHeight(Constants.BUSH_HEIGHT);
            SetWidth(Constants.BUSH_WIDTH);
        }

        public string GetDescription()
        {
            return _description;
        }

        public void SetDescription(string description)
        {
            _description = description;
        }
        
        
    }
}