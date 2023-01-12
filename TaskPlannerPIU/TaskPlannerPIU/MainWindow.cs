using System;
using System.Windows.Forms;
using TaskPlannerPIU.database;
using TaskPlannerPIU.entities;

namespace TaskPlannerPIU
{
    public partial class MainWindow : Form
    {
        private string _username;
        private string _password;
        private DatabaseConnection _connection;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DeleteTextBoxText()
        {
            this.textBoxUsername.Text = "";
            this.textBoxPassword.Text = "";
        }

        public string Username { get { return _username; } }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            _connection = new DatabaseConnection();
            _connection.connect();

            _username = textBoxUsername.Text;
            _password = textBoxPassword.Text;

            var users = _connection.getAllUsers();
            User foundUser = null;
            foreach (var user in users)
            {
                if (!user.Username.Equals(_username))
                    continue;
                else
                    foundUser = new User { Username = user.Username, Password = user.Password};
            }
            if (foundUser != null)
            {

                if (foundUser.Password.Equals(_password))
                {
                    TaskPlannerWindow taskPlannerWindow = new TaskPlannerWindow(this, _connection);
                    taskPlannerWindow.Show();
                    this.Hide();
                    DeleteTextBoxText();
                }
                else
                    MessageBox.Show("Wrong password!");
            }
            else
                MessageBox.Show("User doesn't exist!");
        }
    }
}