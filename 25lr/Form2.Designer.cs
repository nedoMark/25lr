namespace _25lr
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent() // Changed from 'public' to 'private' to resolve CS0111  
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.usersDataGridView = new System.Windows.Forms.DataGridView();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.registerNewButton = new System.Windows.Forms.Button();
            this.searchLabel = new System.Windows.Forms.Label();
            this.headerLabel = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).BeginInit();
            this.SuspendLayout();

            // panelMain  
            this.panelMain.Controls.Add(this.usersDataGridView);
            this.panelMain.Controls.Add(this.searchTextBox);
            this.panelMain.Controls.Add(this.searchButton);
            this.panelMain.Controls.Add(this.registerNewButton);
            this.panelMain.Controls.Add(this.searchLabel);
            this.panelMain.Controls.Add(this.headerLabel);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(800, 500);
            this.panelMain.TabIndex = 0;

            // usersDataGridView  
            this.usersDataGridView.AllowUserToAddRows = false;
            this.usersDataGridView.AllowUserToDeleteRows = false;
            this.usersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.usersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersDataGridView.Location = new System.Drawing.Point(20, 100);
            this.usersDataGridView.Name = "usersDataGridView";
            this.usersDataGridView.ReadOnly = true;
            this.usersDataGridView.Size = new System.Drawing.Size(760, 350);
            this.usersDataGridView.TabIndex = 5;

            // searchTextBox  
            this.searchTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.searchTextBox.Location = new System.Drawing.Point(20, 70);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(600, 25);
            this.searchTextBox.TabIndex = 1;

            // searchButton  
            this.searchButton.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.searchButton.Location = new System.Drawing.Point(630, 70);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(80, 25);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Пошук";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);

            // registerNewButton  
            this.registerNewButton.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.registerNewButton.Location = new System.Drawing.Point(720, 70);
            this.registerNewButton.Name = "registerNewButton";
            this.registerNewButton.Size = new System.Drawing.Size(60, 25);
            this.registerNewButton.TabIndex = 3;
            this.registerNewButton.Text = "Новий";
            this.registerNewButton.UseVisualStyleBackColor = true;
            this.registerNewButton.Click += new System.EventHandler(this.registerNewButton_Click);

            // searchLabel  
            this.searchLabel.AutoSize = true;
            this.searchLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.searchLabel.Location = new System.Drawing.Point(20, 50);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(134, 17);
            this.searchLabel.TabIndex = 4;
            this.searchLabel.Text = "Пошук користувачів:";

            // headerLabel  
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.headerLabel.Location = new System.Drawing.Point(20, 20);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(271, 30);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Список споживачів енергії";

            // UserListForm  
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.panelMain);
            this.Name = "UserListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управління споживачами";
            this.Load += new System.EventHandler(this.UserListForm_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.DataGridView usersDataGridView;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button registerNewButton;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.Label headerLabel;
    }
}