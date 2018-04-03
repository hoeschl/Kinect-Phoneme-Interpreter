namespace KSL.Gestures.Core
{
    using System;
	using System.IO;
	using System.Text;

    public class GesturesEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the type of the gesture.
        /// </summary>
        public string GestureName { get; set; }

        /// <summary>
        /// Gets or sets the tracking ID.
        /// </summary>
        public int TrackignId { get; set; }

        public GesturesEventArgs(string name, int trackingId)
        {
            this.TrackignId = trackingId;
            this.GestureName = name;
			
string path = @"C:\Users\User\Documents\CompTest\kinect-sign-language-master\KSL.Gestures\output.txt";

Console.WriteLine(name);

//This text is added every second, which creates multiple of the same gesture.
		if (File.Exists(path))
        {
			string appendText = name;
			File.AppendAllText(path, appendText, Encoding.UTF8);
        } 
			
			
			
			
        }
		

    }
}
