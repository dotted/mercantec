using System;
using System.Drawing;
using System.Windows.Forms;

public class FetchImage : Form
{

    /// <summary>
    /// The Fetch Image program      Bishop and Horspool June 2002
    /// =======================
    ///
    /// Displays a picture
    /// Illustrates simple drawing of images 
    /// </summary>

    Image pic;

    protected override void OnPaint(PaintEventArgs e)
    {
        this.Width = 500;
        this.Height = 400;
        e.Graphics.DrawImage(pic, 30, 30);
    }

    public FetchImage()
    {
        pic = new Bitmap("photo.jpg");
    }

    static void Main()
    {
        Application.Run(new FetchImage());
    }
}