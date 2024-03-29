using System;
using System.Collections.Generic;
using System.IO;
using THETHREEPENDANTS.Casting;

namespace THETHREEPENDANTS
{
    /// <summary>
    /// This class is used to generate new artifacts, pulling their
    /// messages from the message file.
    /// </summary>
    public class BushesGenerator
    {
        private List<string> _messages;
        private Random _randomGenerator = new Random();

        public BushesGenerator()
        {
            LoadMessages();
        }

        /// <summary>
        /// Loads messages from a file.
        /// </summary>
        private void LoadMessages()
        {
            // There are other ways to do this, including not putting it into an
            // actual List<string>, but this seemed most consistent with what we have
            // done to this point.
            string[] allLines = File.ReadAllLines(Constants.MESSAGE_FILE);

            _messages = new List<string>();
            foreach (string line in allLines)
            {
                _messages.Add(line);
            }
        }

        /// <summary>
        /// Generates a new artifact at a random location.
        /// </summary>
        /// <returns></returns>
        public Bush Generate()
        {
            Bush bush = new Bush();
            int diff = Constants.MAX_X - Constants.MAX_Y;
            int x = _randomGenerator.Next(20, Constants.MAX_X-diff);
            int y = _randomGenerator.Next(20, Constants.MAX_X-diff);
            bush.SetPosition(new Point(x, y));

            bush.SetImage(Constants.IMAGE_BUSH);

            string message = GetRandomMessage();
            bush.SetDescription(message);

            return bush;
        }

        /// <summary>
        /// Gets a random message from the messages file.
        /// </summary>
        /// <returns></returns>
        public string GetRandomMessage()
        {
            string message = _messages[_randomGenerator.Next(0, _messages.Count)];
            return message;
        }
    }
}