using Glossary.Classes.Exceptions;
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
    public partial class AddingCategory : Form
    {
        public AddingCategory()
        {
            InitializeComponent();
           
        }
        public String getCategoryName()
        {
                  return txtCategory.Text;

        }
        private Glossary instanse;
        public Glossary getObjOfForm(Glossary obj)
        {
            return instanse=obj;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            Glossary obj = instanse;
            Catigories.Instance.add(txtCategory.Text);
            obj.getCheckedBox().Items.Add(txtCategory.Text);
            this.Close();
        }

    }
}
