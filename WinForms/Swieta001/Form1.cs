using System;
using System.Drawing;
using System.Windows.Forms;


namespace Swieta001;

public partial class Form1 : Form
{
    private Button button1;
    public Form1()
    {
        this.Text = "Przykład WinForms";
        this.Size = new Size(300,200);

        button1 = new Button();
        button1.Text = "PRZYCISK RADOŚCI";
        button1.Size = new Size(150, 40);
        button1.Location = new Point(70, 60);
        button1.BackColor = Color.LightGray;
        button1.UseVisualStyleBackColor = false;

        button1.MouseEnter += Button1_MouseEnter;
        button1.MouseLeave += Button1_MouseLeave;

        this.Controls.Add(button1);
    }
    private void Button1_MouseEnter(object sender, EventArgs e)
    {
        button1.BackColor = Color.Yellow;
    }
    private void Button1_MouseLeave(object sender, EventArgs e)
    {
        button1.BackColor = Color.LightGray;
    }
}
