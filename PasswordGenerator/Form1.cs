using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordGenerator
{
    public partial class Form1 : Form
    {
        int currentPasswordLength = 0;
        Random character = new Random();

        private void PasswordGenerator(int passwordLength)
        {
            string allCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123465789abcdefghijklmnopqrstuvwxyz!@#$%^&*";
            string randomPassword = "";

            for(int i = 0; i < passwordLength; i++)
            {
                int randomNumber = character.Next(0, allCharacters.Length);
                randomPassword += allCharacters[randomNumber];
            }
            passwordLabel.Text = randomPassword;
        }

        public Form1()
        {
            InitializeComponent();
            passwordLengthSlider.Minimum = 5;
            passwordLengthSlider.Maximum = 20;
            PasswordGenerator(5);
        }

        private void copyPasswordButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(passwordLabel.Text);
        }

        private void passwordLengthSlider_Scroll(object sender, EventArgs e)
        {
            PasswordLengthLabel.Text = "Password Length: " + passwordLengthSlider.Value.ToString();
            currentPasswordLength = passwordLengthSlider.Value;
            PasswordGenerator(currentPasswordLength);
        }
    }
}
