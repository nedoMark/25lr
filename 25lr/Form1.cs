using System;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _25lr
{
    public partial class Form1 : Form
    {
        private OleDbConnection connection;
        private string dbPath = @"C:\Users\pppii\source\repos\25lr\25lr\25lr_database.accdb";

        public Form1()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};";
            connection = new OleDbConnection(connectionString);

            try
            {
                connection.Open();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка підключення до бази даних: {ex.Message}", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                connection.Open();

                // Виправлений SQL-запит з явним вказівкам типів даних
                string query = "INSERT INTO Consumers ([FirstName], [LastName], [MiddleName], [Address], " +
                              "[Phone], [Email], [Password], [RegistrationDate], [IsActive]) " +
                              "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    // Додавання параметрів з явним вказівкам типів даних
                    command.Parameters.Add("@FirstName", OleDbType.VarWChar).Value = firstNameTextBox.Text;
                    command.Parameters.Add("@LastName", OleDbType.VarWChar).Value = lastNameTextBox.Text;

                    // Обробка пустих значень для необов'язкових полів
                    command.Parameters.Add("@MiddleName", OleDbType.VarWChar).Value =
                        string.IsNullOrWhiteSpace(middleNameTextBox.Text) ? DBNull.Value : (object)middleNameTextBox.Text;

                    command.Parameters.Add("@Address", OleDbType.VarWChar).Value = addressTextBox.Text;
                    command.Parameters.Add("@Phone", OleDbType.VarWChar).Value = phoneTextBox.Text;
                    command.Parameters.Add("@Email", OleDbType.VarWChar).Value = emailTextBox.Text;
                    command.Parameters.Add("@Password", OleDbType.VarWChar).Value = HashPassword(passwordTextBox.Text);
                    command.Parameters.Add("@RegistrationDate", OleDbType.Date).Value = DateTime.Now;
                    command.Parameters.Add("@IsActive", OleDbType.Boolean).Value = true; // Нові користувачі за замовчуванням активні

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Реєстрація успішна! Ваш обліковий запис створено.", "Успіх",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show($"Помилка при реєстрації: {ex.Message}\n\nДеталі: {ex.StackTrace}", "Помилка бази даних",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неочікувана помилка: {ex.Message}", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private bool ValidateForm()
        {
            errorLabel.Text = "";

            if (string.IsNullOrWhiteSpace(firstNameTextBox.Text))
            {
                errorLabel.Text = "Введіть ім'я";
                return false;
            }

            if (string.IsNullOrWhiteSpace(lastNameTextBox.Text))
            {
                errorLabel.Text = "Введіть прізвище";
                return false;
            }

            if (string.IsNullOrWhiteSpace(addressTextBox.Text))
            {
                errorLabel.Text = "Введіть адресу";
                return false;
            }

            if (!IsValidPhoneNumber(phoneTextBox.Text))
            {
                errorLabel.Text = "Введіть коректний номер телефону";
                return false;
            }

            if (!IsValidEmail(emailTextBox.Text))
            {
                errorLabel.Text = "Введіть коректну електронну пошту";
                return false;
            }

            if (passwordTextBox.Text.Length < 6)
            {
                errorLabel.Text = "Пароль має містити мінімум 6 символів";
                return false;
            }

            if (passwordTextBox.Text != confirmPasswordTextBox.Text)
            {
                errorLabel.Text = "Паролі не співпадають";
                return false;
            }

            if (!agreementCheckBox.Checked)
            {
                errorLabel.Text = "Потрібно погодитись з умовами договору";
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phone)
        {
            return Regex.IsMatch(phone, @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");
        }

        private string HashPassword(string password)
        {
            // Проста реалізація хешування - у реальному додатку використовуйте більш безпечні методи
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        private void ClearForm()
        {
            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            middleNameTextBox.Clear();
            addressTextBox.Clear();
            phoneTextBox.Clear();
            emailTextBox.Clear();
            passwordTextBox.Clear();
            confirmPasswordTextBox.Clear();
            agreementCheckBox.Checked = false;
        }

        private void RegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        private void headerLabel_Click(object sender, EventArgs e)
        {

        }
    }
}