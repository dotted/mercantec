/// <summery>
/// Import .net classes
/// </summery>

using System;
using System.Drawing;
using System.Windows.Forms;

namespace _2._4
{
    /// <summary>
    /// Create new class FetchImage and extend from Form class
    /// </summary>
    public class FetchImage : Form
    {

        /// <summary>
        /// The Fetch Image program      Bishop and Horspool June 2002
        /// =======================
        ///
        /// Displays a picture
        /// Illustrates simple drawing of images 
        /// </summary>

        /// Create object reference, without creating the object
        Image pic;

        /// <summary>
        /// Override OnPaint method from Form with our own.
        /// This is called when a paint event is called.
        /// </summary>
        /// <param name="e">Event data is in here</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            /// Set window width to 500 and height to 400 for current instance
            this.Width = 500;
            this.Height = 400;
            /// Draw image at native size at coords specified by the last two params
            e.Graphics.DrawImage(pic, 30, 30);
        }
        /// <summary>
        /// constructor, called when class is instantiated
        /// </summary>
        public FetchImage()
        {
            /// Assign an instance of Bitmap to pic
            pic = new Bitmap("photo.jpg");
        }
        /// <summary>
        /// Main function, this code is run first
        /// </summary>
        static void Main()
        {
            ///Begins running a standard application message loop on the current thread.
            Application.Run(new FetchImage());
        }
    }
}
