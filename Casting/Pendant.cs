namespace THETHREEPENDANTS.Casting
{
    ///<summary>
    /// This class will define the attributes of each of the pendants
    ///<summary>
    public class Pendant : Actor
    {
        private bool _pendantFound = false;
        private string _description;
        public Pendant()
        {
            SetText("$$$");
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