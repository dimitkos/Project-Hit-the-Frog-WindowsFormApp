using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrogGame_MPPL17024
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //allazoume to xrwma ths formas
            this.BackColor = Color.Khaki;
            //allazoume to xrwma tou menoy
            menu.BackColor = Color.LightBlue;
            //periorizv ton xrhsth na megalwsei thn forma panw katv deksia aristera
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //an o xrhsths pathsei exit tha tou vgalei ena mynhma an einai ontws vevaiws kai na pathsei nai h oxi
            DialogResult dialogResult = MessageBox.Show("Are you sure that you want to quit?", "Question", MessageBoxButtons.YesNo);
            //an pathsei nai na feygei apo thn efarmogh
            if (dialogResult == DialogResult.Yes)
            {
                Close();
            }
            //alliws an pathsei oxi na paramenei sto paixnidi
            else if (dialogResult == DialogResult.No)
            {
                // do nothing
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //an pathsei to koumpi about tou bgazei mynhma poia ekdosh paizei kai poios einai o dhmiourgos
            MessageBox.Show("Hit the Frog - Version 1.0 Created by Dimitris Kosmas");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //an pathsei to koumpi help tou bgazei mynhma odhgies gia to pws paizetai
            MessageBox.Show("Υou must hit the frog as many times as possible within 30 seconds.There are 2 levels of difficulty.Good luck! ");
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ftiwxnw mia nea forma pou thn onomazw my form pou einai typou userform
            Userform myForm = new Userform();
            //me to poy pathsou to koumpi emfanizetai h nea forma
            myForm.Show(this);
            //sthn synexeia kryvw thn prwth forma
            this.Hide();
        }
    }
}
