namespace Glossary.Forms
{
    partial class AddingTerms
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddingTerms));
            this.txBxRus1 = new System.Windows.Forms.TextBox();
            this.txBxRus2 = new System.Windows.Forms.TextBox();
            this.txBxRus3 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txBxEng1 = new System.Windows.Forms.TextBox();
            this.txBxEng2 = new System.Windows.Forms.TextBox();
            this.txBxEng3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txBxDet = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbCateg = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txBxRus1
            // 
            this.txBxRus1.Location = new System.Drawing.Point(6, 19);
            this.txBxRus1.Name = "txBxRus1";
            this.txBxRus1.Size = new System.Drawing.Size(145, 20);
            this.txBxRus1.TabIndex = 0;
            // 
            // txBxRus2
            // 
            this.txBxRus2.Location = new System.Drawing.Point(6, 45);
            this.txBxRus2.Name = "txBxRus2";
            this.txBxRus2.Size = new System.Drawing.Size(145, 20);
            this.txBxRus2.TabIndex = 2;
            // 
            // txBxRus3
            // 
            this.txBxRus3.Location = new System.Drawing.Point(6, 71);
            this.txBxRus3.Name = "txBxRus3";
            this.txBxRus3.Size = new System.Drawing.Size(145, 20);
            this.txBxRus3.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txBxRus1);
            this.groupBox1.Controls.Add(this.txBxRus2);
            this.groupBox1.Controls.Add(this.txBxRus3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 101);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Русские аналоги:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txBxEng1);
            this.groupBox2.Controls.Add(this.txBxEng2);
            this.groupBox2.Controls.Add(this.txBxEng3);
            this.groupBox2.Location = new System.Drawing.Point(190, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(159, 101);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Английские аналоги:";
            // 
            // txBxEng1
            // 
            this.txBxEng1.Location = new System.Drawing.Point(6, 19);
            this.txBxEng1.Name = "txBxEng1";
            this.txBxEng1.Size = new System.Drawing.Size(145, 20);
            this.txBxEng1.TabIndex = 1;
            // 
            // txBxEng2
            // 
            this.txBxEng2.Location = new System.Drawing.Point(6, 45);
            this.txBxEng2.Name = "txBxEng2";
            this.txBxEng2.Size = new System.Drawing.Size(145, 20);
            this.txBxEng2.TabIndex = 3;
            // 
            // txBxEng3
            // 
            this.txBxEng3.Location = new System.Drawing.Point(6, 71);
            this.txBxEng3.Name = "txBxEng3";
            this.txBxEng3.Size = new System.Drawing.Size(145, 20);
            this.txBxEng3.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 179);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Определение:";
            // 
            // txBxDet
            // 
            this.txBxDet.Location = new System.Drawing.Point(12, 199);
            this.txBxDet.Multiline = true;
            this.txBxDet.Name = "txBxDet";
            this.txBxDet.Size = new System.Drawing.Size(337, 90);
            this.txBxDet.TabIndex = 6;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(243, 296);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(106, 31);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Добавить";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 296);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 31);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbCateg);
            this.groupBox3.Location = new System.Drawing.Point(102, 119);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(159, 55);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Категории";
            // 
            // cmbCateg
            // 
            this.cmbCateg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCateg.FormattingEnabled = true;
            this.cmbCateg.Location = new System.Drawing.Point(6, 19);
            this.cmbCateg.Name = "cmbCateg";
            this.cmbCateg.Size = new System.Drawing.Size(147, 21);
            this.cmbCateg.TabIndex = 0;
            // 
            // AddingTerms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 336);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txBxDet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddingTerms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление термина";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txBxRus1;
        private System.Windows.Forms.TextBox txBxRus2;
        private System.Windows.Forms.TextBox txBxRus3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txBxEng1;
        private System.Windows.Forms.TextBox txBxEng2;
        private System.Windows.Forms.TextBox txBxEng3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txBxDet;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbCateg;
    }
}