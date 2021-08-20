using Species;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DeepBlueSea
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // declare and initialise fields
            string species = null;
            bool blood = false, echolation = false;
            int size = 0;

            // get user input
            species = comboBox1.SelectedItem.ToString();

            // get user input
            if (radioButton1.Checked)
            {
                blood = true;
            }

            // get user input
            if (radioButton3.Checked)
            {
                echolation = false;
            }

            // get user input
            size = (int)numericUpDown1.Value;

            // instantiate MarineLife class object
            MarineLife m = new MarineLife(species, blood, echolation, size);

            // add to generic collection
            m.AddToCollection(m);

            // set user interface components back to default
            comboBox1.Text = null;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            numericUpDown1.Value = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = 100;
            numericUpDown1.Minimum = 0;

            richTextBox1.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // clear component
            richTextBox1.Clear();

            // declare and initialise field
            string keyword = null;

            // get user input
            keyword = textBox1.Text;

            // LINQ
            var filt = Collection.lstSpecies.
                Where(x => x.Species == keyword).
                Select(x => new
                {
                    x.Species,
                    x.WarmBlooded,
                    x.UseEcholation,
                    x.MaxSizeInMeters
                }).ToList();

            // check list count
            if (filt.Count < 1)
            {
                richTextBox1.AppendText("No species found.\nPlease try again.");
            }
            else
            {
                // iterate and display
                foreach (var i in filt)
                {
                    richTextBox1.AppendText(
                          "Species: " + i.Species
                        + "\nIs Warm Blooded?: " + i.WarmBlooded
                        + "\nIs Use Echolation?: " + i.UseEcholation
                        + "\nMax Size(m): " + i.MaxSizeInMeters
                        + "\n");
                }
            }

            //var namesAndPrices =  
            //products.
            //Where(p => p.UnitPrice >= 10).
            //Select(p => new { p.Name, p.UnitPrice }).
            //ToList();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
}
