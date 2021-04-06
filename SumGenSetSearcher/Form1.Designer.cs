namespace SumGenSetSearcher
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MinSum = new System.Windows.Forms.NumericUpDown();
            this.MaxSum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ResultSelector = new System.Windows.Forms.ListBox();
            this.ResDisplay = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.MaxNumSummands = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxNumSummands)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.MinSum, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.MaxSum, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ResultSelector, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.ResDisplay, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.MaxNumSummands, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 569);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // MinSum
            // 
            this.MinSum.Location = new System.Drawing.Point(3, 3);
            this.MinSum.Name = "MinSum";
            this.MinSum.Size = new System.Drawing.Size(194, 20);
            this.MinSum.TabIndex = 4;
            this.MinSum.ValueChanged += new System.EventHandler(this.MinSum_ValueChanged);
            // 
            // MaxSum
            // 
            this.MaxSum.Location = new System.Drawing.Point(3, 116);
            this.MaxSum.Name = "MaxSum";
            this.MaxSum.Size = new System.Drawing.Size(194, 20);
            this.MaxSum.TabIndex = 5;
            this.MaxSum.ValueChanged += new System.EventHandler(this.MaxSum_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Min Value";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Max Value";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Max Num Summands";
            // 
            // ResultSelector
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.ResultSelector, 3);
            this.ResultSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultSelector.FormattingEnabled = true;
            this.ResultSelector.Location = new System.Drawing.Point(403, 116);
            this.ResultSelector.Name = "ResultSelector";
            this.ResultSelector.Size = new System.Drawing.Size(594, 107);
            this.ResultSelector.TabIndex = 9;
            this.ResultSelector.SelectedIndexChanged += new System.EventHandler(this.ResultSelector_SelectedIndexChanged);
            // 
            // ResDisplay
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.ResDisplay, 3);
            this.ResDisplay.Location = new System.Drawing.Point(403, 229);
            this.ResDisplay.Name = "ResDisplay";
            this.tableLayoutPanel1.SetRowSpan(this.ResDisplay, 3);
            this.ResDisplay.Size = new System.Drawing.Size(594, 337);
            this.ResDisplay.TabIndex = 10;
            this.ResDisplay.Text = "";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(403, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 107);
            this.button1.TabIndex = 8;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MaxNumSummands
            // 
            this.MaxNumSummands.Enabled = false;
            this.MaxNumSummands.Location = new System.Drawing.Point(3, 229);
            this.MaxNumSummands.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxNumSummands.Name = "MaxNumSummands";
            this.MaxNumSummands.Size = new System.Drawing.Size(194, 20);
            this.MaxNumSummands.TabIndex = 6;
            this.MaxNumSummands.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.MaxNumSummands.ValueChanged += new System.EventHandler(this.MaxNumSummands_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 569);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxNumSummands)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown MinSum;
        private System.Windows.Forms.NumericUpDown MaxSum;
        private System.Windows.Forms.NumericUpDown MaxNumSummands;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox ResultSelector;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox ResDisplay;
    }
}

