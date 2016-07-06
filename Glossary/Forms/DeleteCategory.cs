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
    public partial class DeleteCategory : Form
    {
        public DeleteCategory()
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
        public String getCategoryName()
        {
            /*
                При закрытии форме и при том, что мы ничего не ввели, cmbCateg возвращает "", поэтому мы делаем проверку
               */
            if(cmbCateg.Text != "")
            return cmbCateg.SelectedItem.ToString();
            return null;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Catigories.Instance.remove(cmbCateg.SelectedItem.ToString());
            this.Close();
        }
    }
}
