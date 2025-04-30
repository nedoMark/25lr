using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace _25lr
{
    public partial class Form2 : Form
    {
        private OleDbConnection connection;
        private string dbPath = @"C:\Users\pppii\source\repos\25lr\25lr\25lr_database.accdb";

        public Form2()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};";
            connection = new OleDbConnection(connectionString);
        }

        private void UserListForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers(string searchTerm = "")
        {
            try
            {
                connection.Open();

                string query = "SELECT ConsumerID, FirstName, LastName, MiddleName, Address, Phone, Email, " +
                              "RegistrationDate, IsActive FROM Consumers";

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    query += " WHERE FirstName LIKE ? OR LastName LIKE ? OR Phone LIKE ? OR Email LIKE ?";
                }

                query += " ORDER BY LastName, FirstName";

                OleDbCommand command = new OleDbCommand(query, connection);

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    string likeTerm = $"%{searchTerm}%";
                    command.Parameters.AddWithValue("@p1", likeTerm);
                    command.Parameters.AddWithValue("@p2", likeTerm);
                    command.Parameters.AddWithValue("@p3", likeTerm);
                    command.Parameters.AddWithValue("@p4", likeTerm);
                }

                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                usersDataGridView.DataSource = dataTable;

                // Налаштування відображення стовпців
                if (usersDataGridView.Columns.Contains("ConsumerID"))
                    usersDataGridView.Columns["ConsumerID"].Visible = false;

                if (usersDataGridView.Columns.Contains("IsActive"))
                {
                    usersDataGridView.Columns["IsActive"].HeaderText = "Активний";
                    usersDataGridView.Columns["IsActive"].Width = 60;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при завантаженні даних: {ex.Message}", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            LoadUsers(searchTextBox.Text);
        }

        private void registerNewButton_Click(object sender, EventArgs e)
        {
            OpenRegistrationForm();
        }

        private void OpenRegistrationForm()
        {
            // Створюємо нову форму реєстрації
            Form1 registrationForm = new Form1();

            // Встановлюємо її власником поточну форму
            registrationForm.Owner = this;

            // Підписуємось на подію закриття форми
            registrationForm.FormClosed += RegistrationForm_FormClosed;

            // Показуємо форму реєстрації
            registrationForm.Show();

            // Ховаємо поточну форму (не обов'язково)
            this.Hide();
        }

        private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Коли форма реєстрації закривається:

            // 1. Показуємо поточну форму знову
            this.Show();

            // 2. Оновлюємо список користувачів
            LoadUsers();

            // 3. Переводимо фокус на поле пошуку
            searchTextBox.Focus();
        }

        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadUsers(searchTextBox.Text);
                e.Handled = true;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Закриваємо додаток при закритті цієї форми
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}