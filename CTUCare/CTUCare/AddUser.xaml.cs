using System.Linq;
using System.Windows;

namespace CTUCare
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
        }

        CTUCareDB db = new CTUCareDB();

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            txtAPassword.IsEnabled = true;
            label_Copy1.IsEnabled = true;
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            txtAPassword.IsEnabled = false;
            label_Copy1.IsEnabled = false;
        }

        private void addUser()
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Password;
            string adminPassword = txtAPassword.Password;

            var userList = CTUCareDB.Instance.Users.ToList();
            var adminUser = userList.Find(x => x.Password == adminPassword);
            var existingUser = userList.Find(x => x.Username == userName);

            User newUser = new User

            {
                Username = userName,
                Password = password,
            };

            if (checkBox.IsChecked == true)
            {
                newUser.IsUserAdmin = 1;

                if (adminUser != null)
                {
                    if (existingUser != null)
                        MessageBox.Show("User Already Exists");
                    else
                    {
                        db.Users.Add(newUser);
                        db.SaveChanges();

                        this.Close();

                        MessageBox.Show("User Added");
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Admin Password");
                }
            }
            else
            {
                newUser.IsUserAdmin = 2;

                db.Users.Add(newUser);
                db.SaveChanges();

                this.Close();

                MessageBox.Show("User Added");
            }
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            addUser();
        }
    }
}
