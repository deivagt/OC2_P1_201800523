using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OC2_P1_201800523.AST;

namespace OC2_P1_201800523
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(richTextBox1.Text);
            AnalizadorSintactico n = new AnalizadorSintactico();
            n.analisis(richTextBox1.Text);
            
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
