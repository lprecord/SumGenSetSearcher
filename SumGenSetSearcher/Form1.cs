using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SumGenSetSearcher
{
    public partial class Form1 : Form
    {
        SummandListCatalogue Results;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResultSelector.Items.Clear();
            ResDisplay.Text = "";
            this.Results = SummandListSearcher.BFS_SummandLists2Range((uint)MinSum.Value, (uint)MaxSum.Value, (uint)MaxNumSummands.Value);
            if (this.Results.isEmpty())
            {
                ResDisplay.Text = "No summand list for this range found.";
            }
            else
            {
                for (uint i = 1; i <= this.Results.GetLength(); i++)
                {
                    SummandList current = this.Results.GetNthSummandList(i);
                    ResultSelector.Items.Add(current.ToString());
                }
            }
        }

        private void MinSum_ValueChanged(object sender, EventArgs e)
        {
            ResultSelector.Items.Clear();
            ResDisplay.Text = "";
            if (MinSum.Value <= MaxSum.Value) 
            { 
                button1.Enabled = true; 
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void MaxSum_ValueChanged(object sender, EventArgs e)
        {
            ResultSelector.Items.Clear();
            ResDisplay.Text = "";
            if (MinSum.Value <= MaxSum.Value)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void MaxNumSummands_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ResultSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(ResultSelector.SelectedIndex.ToString() + ": " + ResultSelector.SelectedItem.ToString());
            string result = "";
            SummandList current = this.Results.GetNthSummandList((uint)(ResultSelector.SelectedIndex+1));
            ReachedSumsResult shortresult = current.GetReachableSumsShort((uint)MaxNumSummands.Value);
            result = result + "Summands: " + current.ToString() + "\n"
                + "Results:\n" + shortresult.ToString((uint)MinSum.Value, (uint)MaxSum.Value);
            ResDisplay.Text = result;
        }
    }
}
