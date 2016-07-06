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
    public partial class EditingTerms : Form
    {
        int index;
        public EditingTerms(int index)
        {
            InitializeComponent();
            this.index = index;
            initForm();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            String[] russianArray = { txBxRus1.Text, txBxRus2.Text, txBxRus3.Text };
            String[] englishArray = { txBxEng1.Text, txBxEng2.Text, txBxEng3.Text };
            String determination = txBxDet.Text;
            String category = cmbCateg.SelectedItem.ToString().Trim();
            if (Terms.editTerm(index, russianArray, englishArray, determination, category))
                this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void initForm()
        {
            cmbCateg.Items.Clear();

            txBxRus1.Text = Terms.getRussianAsArray(index)[0];
            txBxRus2.Text = Terms.getRussianAsArray(index)[1];
            txBxRus3.Text = Terms.getRussianAsArray(index)[2];

            txBxEng1.Text = Terms.getEnglishAsArray(index)[0];
            txBxEng2.Text = Terms.getEnglishAsArray(index)[1];
            txBxEng3.Text = Terms.getEnglishAsArray(index)[2];

            txBxDet.Text = Terms.getDetermination(index);

            cmbCateg.Items.Add(Terms.getCategory(index));
        }
    }
}
