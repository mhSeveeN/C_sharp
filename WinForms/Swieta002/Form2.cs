using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace Swieta002
{
    public class Form2 : Form
    {
        private Button submitButton;
        private ComboBox giftComboBox;
        private TextBox imieTextBox;
        private TextBox nazwiskoTextBox;
        private TextBox wiekTextBox;
        private TextBox adresTextBox;
        private TextBox kodPocztowyTextBox;
        private TextBox miastoTextBox;
        private CheckBox grzecznyCheckBox;

        public Form2()
        {
            this.Text = "Dane dziecka";
            this.Size = new Size(600, 600);
            int y = 20;
            imieTextBox = new TextBox();
            AddLabelAndTextBox("Imię:", ref y, imieTextBox);
            nazwiskoTextBox = new TextBox();
            AddLabelAndTextBox("Nazwisko:", ref y, nazwiskoTextBox);
            wiekTextBox = new TextBox();
            AddLabelAndTextBox("Wiek:", ref y, wiekTextBox);
            adresTextBox = new TextBox();
            AddLabelAndTextBox("Adres:", ref y, adresTextBox);
            kodPocztowyTextBox = new TextBox();
            AddLabelAndTextBox("Kod pocztowy", ref y, kodPocztowyTextBox);
            miastoTextBox = new TextBox();
            AddLabelAndTextBox("Miasto:", ref y, miastoTextBox);
            Label giftLabel = new Label();
            giftLabel.Text = "Wybierz prezent:";
            giftLabel.Location = new Point(20, y);
            giftLabel.AutoSize = true;
            this.giftComboBox = new ComboBox();
            giftComboBox.Location = new Point(150, y - 3);
            giftComboBox.Width = 250;
            giftComboBox.Items.Add("Lalka");
            giftComboBox.Items.Add("Samochodzik");
            giftComboBox.Items.Add("Książka");
            giftComboBox.Items.Add("Kurs C# dla początkujących");
            giftComboBox.Items.Add("Kompjuta");
            giftComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(giftLabel);
            this.Controls.Add(giftComboBox);
            y += 35;
            Button ColorButton = new Button();
            ColorButton.Text = "Wybierz kolor";
            ColorButton.Size = new Size(150, 30);
            ColorButton.Location = new Point(20, y);
            ColorButton.Click += (s, e) => {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK) {
                    this.BackColor = colorDialog.Color;
                }
            };
            this.Controls.Add(ColorButton);
            y += 50;
            grzecznyCheckBox = new CheckBox();
            grzecznyCheckBox.Text = "Czy byłeś grzeczny?";
            grzecznyCheckBox.Location = new Point(20, y);
            this.Controls.Add(grzecznyCheckBox);

            y += 50;
            submitButton = new Button();
            submitButton.Text = "Zatwierdź";
            submitButton.Size = new Size(150, 100);
            submitButton.Location = new Point(140, y);
            submitButton.BackColor = Color.LightGray;
            submitButton.UseVisualStyleBackColor = false;
            submitButton.MouseEnter += submitButton_MouseEnter;
            submitButton.MouseLeave += submitButton_MouseLeave;
            submitButton.Click += SubmitButton_Click;
            this.Controls.Add(submitButton);
        }
        private void AddLabelAndTextBox(string text, ref int y, TextBox textBox)
        {
            Label label = new Label();
            label.Text = text;
            label.Location = new Point(20, y);
            label.AutoSize = true;
            textBox.Location = new Point(150, y - 3);
            textBox.Width = 250;
            this.Controls.Add(label);
            this.Controls.Add(textBox);
            y += 35;
        }
        private void submitButton_MouseEnter(object sender, EventArgs e)
        {
            submitButton.BackColor = Color.Green;
        }
        private void submitButton_MouseLeave(object sender, EventArgs e)
        {
            submitButton.BackColor = Color.LightGray;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            using var connection = new SqliteConnection("Data Source=dzieci.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Dzieci (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Imie TEXT,
                    Nazwisko TEXT,
                    Wiek TEXT,
                    Adres TEXT,
                    KodPocztowy TEXT,
                    Miasto TEXT,
                    Prezent TEXT,
                    Grzeczny INTEGER
                );
            ";
            command.ExecuteNonQuery();
            command.CommandText = @"
                INSERT INTO Dzieci (Imie, Nazwisko, Wiek, Adres, KodPocztowy, Miasto, Prezent, Grzeczny)
                VALUES ($imie, $nazwisko, $wiek, $adres, $kod, $miasto, $prezent, $grzeczny);
            ";
            command.Parameters.AddWithValue("$imie", imieTextBox.Text);
            command.Parameters.AddWithValue("$nazwisko", nazwiskoTextBox.Text);
            command.Parameters.AddWithValue("$wiek", wiekTextBox.Text);
            command.Parameters.AddWithValue("$adres", adresTextBox.Text);
            command.Parameters.AddWithValue("$kod", kodPocztowyTextBox.Text);
            command.Parameters.AddWithValue("$miasto", miastoTextBox.Text);
            command.Parameters.AddWithValue("$prezent", giftComboBox.SelectedItem?.ToString() ?? "");
            command.Parameters.AddWithValue("$grzeczny", grzecznyCheckBox.Checked ? 1 : 0);
            command.ExecuteNonQuery();
            MessageBox.Show("Dane zapisane!");
        }
    }       
}
