namespace SiemensCSharp;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        BookGridView = new System.Windows.Forms.DataGridView();
        panel1 = new System.Windows.Forms.Panel();
        TitleTextBox = new System.Windows.Forms.TextBox();
        TitleLabel = new System.Windows.Forms.Label();
        AuthorTextBox = new System.Windows.Forms.TextBox();
        AuthorLabel = new System.Windows.Forms.Label();
        panel2 = new System.Windows.Forms.Panel();
        ReturnButton = new System.Windows.Forms.Button();
        LoanButton = new System.Windows.Forms.Button();
        BookLoanGridView = new System.Windows.Forms.DataGridView();
        ((System.ComponentModel.ISupportInitialize)BookGridView).BeginInit();
        panel1.SuspendLayout();
        panel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)BookLoanGridView).BeginInit();
        SuspendLayout();
        // 
        // BookGridView
        // 
        BookGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        BookGridView.Location = new System.Drawing.Point(9, 8);
        BookGridView.Name = "BookGridView";
        BookGridView.RowHeadersWidth = 51;
        BookGridView.Size = new System.Drawing.Size(295, 368);
        BookGridView.TabIndex = 0;
        BookGridView.Text = "dataGridView1";
        // 
        // panel1
        // 
        panel1.Controls.Add(TitleTextBox);
        panel1.Controls.Add(TitleLabel);
        panel1.Controls.Add(AuthorTextBox);
        panel1.Controls.Add(AuthorLabel);
        panel1.Location = new System.Drawing.Point(9, 392);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(695, 45);
        panel1.TabIndex = 1;
        // 
        // TitleTextBox
        // 
        TitleTextBox.Location = new System.Drawing.Point(401, 3);
        TitleTextBox.Name = "TitleTextBox";
        TitleTextBox.Size = new System.Drawing.Size(294, 27);
        TitleTextBox.TabIndex = 3;
        TitleTextBox.TextChanged += AuthorTextBox_TextChanged;
        // 
        // TitleLabel
        // 
        TitleLabel.Location = new System.Drawing.Point(335, 0);
        TitleLabel.Name = "TitleLabel";
        TitleLabel.Size = new System.Drawing.Size(60, 30);
        TitleLabel.TabIndex = 2;
        TitleLabel.Text = "Title";
        TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // AuthorTextBox
        // 
        AuthorTextBox.Location = new System.Drawing.Point(66, 3);
        AuthorTextBox.Name = "AuthorTextBox";
        AuthorTextBox.Size = new System.Drawing.Size(163, 27);
        AuthorTextBox.TabIndex = 1;
        AuthorTextBox.TextChanged += AuthorTextBox_TextChanged;
        // 
        // AuthorLabel
        // 
        AuthorLabel.Location = new System.Drawing.Point(0, 0);
        AuthorLabel.Name = "AuthorLabel";
        AuthorLabel.Size = new System.Drawing.Size(60, 30);
        AuthorLabel.TabIndex = 0;
        AuthorLabel.Text = "Author";
        AuthorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // panel2
        // 
        panel2.Controls.Add(ReturnButton);
        panel2.Controls.Add(LoanButton);
        panel2.Location = new System.Drawing.Point(710, 8);
        panel2.Name = "panel2";
        panel2.Size = new System.Drawing.Size(84, 429);
        panel2.TabIndex = 2;
        // 
        // ReturnButton
        // 
        ReturnButton.Location = new System.Drawing.Point(0, 39);
        ReturnButton.Name = "ReturnButton";
        ReturnButton.Size = new System.Drawing.Size(84, 33);
        ReturnButton.TabIndex = 1;
        ReturnButton.Text = "Return";
        ReturnButton.UseVisualStyleBackColor = true;
        ReturnButton.Click += ReturnBookButton_Click;
        // 
        // LoanButton
        // 
        LoanButton.Location = new System.Drawing.Point(0, 0);
        LoanButton.Name = "LoanButton";
        LoanButton.Size = new System.Drawing.Size(84, 33);
        LoanButton.TabIndex = 0;
        LoanButton.Text = "Loan";
        LoanButton.UseVisualStyleBackColor = true;
        LoanButton.Click += LoanBookButton_Click;
        // 
        // BookLoanGridView
        // 
        BookLoanGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        BookLoanGridView.Location = new System.Drawing.Point(310, 8);
        BookLoanGridView.Name = "BookLoanGridView";
        BookLoanGridView.RowHeadersWidth = 51;
        BookLoanGridView.Size = new System.Drawing.Size(394, 368);
        BookLoanGridView.TabIndex = 3;
        BookLoanGridView.Text = "dataGridView2";
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(BookLoanGridView);
        Controls.Add(panel2);
        Controls.Add(panel1);
        Controls.Add(BookGridView);
        Text = "Library Admin";
        ((System.ComponentModel.ISupportInitialize)BookGridView).EndInit();
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)BookLoanGridView).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.TextBox AuthorTextBox;
    private System.Windows.Forms.Label TitleLabel;
    private System.Windows.Forms.TextBox TitleTextBox;
    private System.Windows.Forms.DataGridView BookLoanGridView;
    private System.Windows.Forms.Button ReturnButton;

    private System.Windows.Forms.DataGridView BookGridView;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label AuthorLabel;
    private System.Windows.Forms.Button LoanButton;

    #endregion
}