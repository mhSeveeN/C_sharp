using System;
using System.Drawing;
using System.Windows.Forms;

namespace Swieta002;

public partial class Form1 : Form
{
    private PictureBox pictureBox;
    public Form1()
    {
        this.Text = "Okno główne aplikacji";
        this.Size = new Size(400,300);

        pictureBox = new PictureBox();
        pictureBox.Size = new Size(200,150);
        pictureBox.Location = new Point(100, 70);
        pictureBox.BorderStyle = BorderStyle.FixedSingle;
        pictureBox.BackColor = Color.LightGray;
        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox.Click += PictureBox_Click;
        pictureBox.Image = Image.FromFile("D:/Programs/PierwszyProjektC#/C_sharp/WinForms/Swieta002/ojaaacieee1.jpg"); 
        this.Controls.Add(pictureBox);
    }
    private void PictureBox_Click(object sender, EventArgs e)
    {
        Form2 form2 = new Form2();
        form2.ShowDialog();
    }
}
