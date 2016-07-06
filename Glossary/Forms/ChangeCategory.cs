using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Glossary.Forms
{
    public partial class ChangeCategory : Form
    {
        public ChangeCategory()
        {
            InitializeComponent();
            initCmbBox();
        }
        public void initCmbBox()
        {
            for (int i = 0; i < Catigories.Instance.CatigoriesList.Count; i++)
            {
                cmbCateg.Items.Add(Catigories.Instance.CatigoriesList[i]);
            }
            
        }
        public String getCategoryNewName()
        {
            return txtChange.Text;
        }
        public String getCategoryDelete()
        {
            if(cmbCateg == null)
            return cmbCateg.SelectedItem.ToString();
            return null;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            Catigories.Instance.change(cmbCateg.SelectedItem.ToString(), txtChange.Text);
            this.Close();
        }
    }
}
