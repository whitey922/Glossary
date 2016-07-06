using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Glossary.Classes;

namespace Glossary.Forms
{
    public partial class AddingTerms : Form
    {
        public AddingTerms()
        {
            InitializeComponent();
            initCmbBox();
            txBxRus1.Focus();
        }
        public void initCmbBox()
        {
            for (int i = 0; i < Catigories.Instance.CatigoriesList.Count; i++)
            {
                cmbCateg.Items.Add(Catigories.Instance.CatigoriesList[i]);
            }

        }
        private void btnOk_Click(object sender, EventArgs e)
        {

            String[] russianArray = { txBxRus1.Text.Trim(), txBxRus2.Text.Trim(), txBxRus3.Text.Trim() };
            String[] englishArray = { txBxEng1.Text.Trim(), txBxEng2.Text.Trim(), txBxEng3.Text.Trim() };
            String determination = txBxDet.Text.Trim();
            String category = (String)cmbCateg.SelectedItem;
            if (Terms.addTerm(russianArray, englishArray, determination, category))
                this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
