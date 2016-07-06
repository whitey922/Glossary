using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Glossary.Classes;
using Glossary.Forms;
using Glossary.Classes.Exceptions;

namespace Glossary
{
    public partial class Glossary : Form
    {
        public Glossary()
        {
            InitializeComponent();

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(91, 75, 72);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Miriam", 14);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(210, 205, 202);
            dgv.EnableHeadersVisualStyles = false;

            Terms.deserializeOfList();
            Catigories.deserialize();

            showTerms();
            initCategories();

            resize();
        }
        /*
        Добавляем категории в чекбокслист на Main форме
        */
        public CheckedListBox getCheckedBox()
        {
            return checkedListBox1;
        }

        public Glossary getObjGlossary()
        {
            return this;
        }

        public void initCategories()
        {
            for (int i = 0; i < Catigories.Instance.CatigoriesList.Count; i++)
            {
                checkedListBox1.Items.Add(Catigories.Instance.CatigoriesList[i]);
            }

        }

        private void resize()
        {
            DataGridViewColumn column = dgv.Columns[0];
            column.Width = (int)(dgv.Width / 100.0 * 20);
            DataGridViewColumn column2 = dgv.Columns[1];
            column2.Width = (int)(dgv.Width / 100.0 * 20);
            DataGridViewColumn column3 = dgv.Columns[2];
            column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void Glossary_Resize(object sender, EventArgs e)
        {
            resize();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addingTerms();
        }

        private void редактироватьТермиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editingTerms();
        }

        private void удалениеТерминаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removingTerms();
        }

        private void showTerms()
        {
            dgv.Rows.Clear();
            for (int i = 0; i < Terms.getCount(); i++)
            {
                dgv.Rows.Add(Terms.getRussianAsString(i), Terms.getEnglishAsString(i), Terms.getDetermination(i));
            }
        }

        private void addingTerms()
        {
            AddingTerms addingForm = new AddingTerms();
            addingForm.ShowDialog();
            showTerms();
        }

        private void editingTerms()
        {
            int row = dgv.CurrentRow.Index;
            try
            {
                EditingTerms editingTerms = new EditingTerms(Terms.getIndex(dgv[0, row].Value.ToString(),
                                                                            dgv[1, row].Value.ToString(),
                                                                            dgv[2, row].Value.ToString()));
                editingTerms.ShowDialog();
                showTerms();
            }
            catch (Exception)
            {
                MessageBox.Show("Не-не-не, так не покатит =\\", "Не-а");
            }
        }

        private void removingTerms()
        {
            int row = dgv.CurrentRow.Index;
            try
            {
                Terms.removeTerm(Terms.getIndex(dgv[0, row].Value.ToString(),
                                                dgv[1, row].Value.ToString(),
                                                dgv[2, row].Value.ToString()));
                showTerms();
            }
            catch (Exception)
            {
                MessageBox.Show("Не-не-не, так не покатит =\\", "Не-а");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
             
            dgv.Rows.Clear();
            for (int i = 0; i < Terms.getCount(); i++)
            {
                if(Terms.search(txtSearch.Text) != null)
                        dgv.Rows.Add(Terms.search(txtSearch.Text).getRussianAsString(), Terms.search(txtSearch.Text).getEnglishAsString(),
                  Terms.search(txtSearch.Text).getDetermination());
              
            }
        }
        private void добавлениеКатегорииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddingCategory addCategory = new AddingCategory();
            addCategory.getObjOfForm(this);
            addCategory.ShowDialog();
               
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            String[] arrOfCategories = new String[checkedListBox1.SelectedItems.Count];
            for (int i = 0; i < arrOfCategories.Length; i++)
            {
                arrOfCategories[i] = checkedListBox1.SelectedItems[i].ToString();
            }

            dgv.Rows.Clear();
            for (int i = 0; i < Terms.search(arrOfCategories).Count; i++)
            {
                if (Terms.search(arrOfCategories) != null)
                    dgv.Rows.Add(Terms.search(arrOfCategories)[i].getRussianAsString(), Terms.search(arrOfCategories)[i].getEnglishAsString(),
             Terms.search(arrOfCategories)[i].getDetermination());

            }
        }
        private void Glossary_FormClosed(object sender, FormClosedEventArgs e)
        {
            Terms.serializeOfList();
            Catigories.serialize();
        }

        private void редактированиеКатегорииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeCategory objForm = new ChangeCategory();
            objForm.ShowDialog();
            if(objForm.getCategoryDelete() != null && objForm.getCategoryNewName() != null)
            {
                int index = checkedListBox1.Items.IndexOf(objForm.getCategoryDelete());
                checkedListBox1.Items.Remove(objForm.getCategoryDelete());
                checkedListBox1.Items.Insert(index, objForm.getCategoryNewName());
            }
       


        }

        private void удалениеКатегорииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCategory objFormDelete = new DeleteCategory();
            objFormDelete.ShowDialog();
            if(objFormDelete.getCategoryName() != null)
            checkedListBox1.Items.Remove(objFormDelete.getCategoryName());
        }
    }
}

