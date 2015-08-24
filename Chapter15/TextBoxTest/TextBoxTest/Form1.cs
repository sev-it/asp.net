using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextBoxTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.buttonOK.Enabled = false;
            // Значения свойств Tag
            this.textBoxName.Tag = false;
            this.textBoxAddress.Tag = false;
            this.textBoxOccupation.Tag = false;
            this.textBoxAge.Tag = false;
            // Подписка на событие
            this.textBoxName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxEmpty_Validating);
            this.textBoxAddress.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxEmpty_Validating);
            this.textBoxOccupation.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxOccupation_Validating);
            this.textBoxAge.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxEmpty_Validating);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string output;
            output  = "Name: " + this.textBoxName.Text + "\r\n";
            output += "Address: " + this.textBoxAddress.Text + "\r\n";
            output += "Occupation: " + this.textBoxOccupation.Text + "\r\n";
            output += "Age: " + this.textBoxAge.Text + "\r\n";
            this.textBoxOutput.Text = output;
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            string output;
            output  = "Name = Your name\r\n";
            output += "Address = Your address\r\n";
            output += "Occupation = Only allowed value is 'Programmer'\r\n";
            output += "Age = Your age\r\n";
        /*
            string output;
            output  = "Name = Ваше имя\r\n";
            output += "Address = Ваш адрес\r\n";
            output += "Occupation = Единственное допустимое значение 'Programmer'\r\n";
            output += "Age = Ваш возраст\r\n";
        */
            this.textBoxOutput.Text = output;
        }

        private void textBoxEmpty_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Отправитель TextBox, поэтому приводим sender к типу TextBox
            TextBox tb = (TextBox)sender;
            if (tb.Text.Length == 0)
            {
                tb.BackColor = Color.Red;
                tb.Tag = false;
            }
            else
            {
                tb.BackColor = System.Drawing.SystemColors.Window;
                tb.Tag = true;
            }
            ValidateOK();
        }

        private void textBoxOccupation_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (System.String.Compare(tb.Text, "Programmer", System.StringComparison.Ordinal) == 0 || tb.Text.Length == 9)
            {
                tb.Tag = true;
                tb.BackColor = System.Drawing.SystemColors.Window;
            }
            else
            {
                tb.Tag = false;
                tb.BackColor = Color.Red;
            }
            ValidateOK();
        }

        private void textBoxAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        { 
            TextBox tb = (TextBox)sender;
            if (tb.Text.Length == 0 && tb != textBoxOccupation)
            {
                tb.Tag = false;
                tb.BackColor = Color.Red;
            }
            else if (tb == textBoxOccupation &&
            (tb.Text.Length != 0 && tb.Text.CompareTo("Programmer") != 0))
            {
                tb.Tag = false;
            }
            else
            {
                tb.Tag = true;
                tb.BackColor = System.Drawing.SystemColors.Window;
            }
            ValidateOK(); 
        }
        private void ValidateOK()
        {
            this.buttonOK.Enabled = ((bool)(this.textBoxName.Tag) &&
                                     (bool)(this.textBoxAddress.Tag) &&
                                     (bool)(this.textBoxOccupation.Tag) &&
                                     (bool)(this.textBoxAge.Tag));
        }
    }
}
