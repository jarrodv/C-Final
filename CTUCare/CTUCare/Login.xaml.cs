using System;
using System.Linq;
using System.Windows;

namespace CTUCare
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            ValidateCredentials();

            this.Close();
        }

        AddUser newUserWindow = new AddUser();

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                newUserWindow.Show();
            }
            catch (Exception)
            {
                AddUser newUserWindow = new AddUser();
                newUserWindow.Show();
            }
        }

        Home newHome = new Home();

        private void ValidateCredentials()
        {
            string userUserName = txtUserName.Text;
            string userPassword = txtPassword.Password;

            var userList = CTUCareDB.Instance.Users.ToList();
            var dbUser = userList.Find(x => x.Username == userUserName);

            

            //1 for admin user, 2 for regular user
            int adminUser = 1;

            if (dbUser != null)
            {
                if (dbUser.Password == userPassword)
                {
                    //Acts as a token for the users
                    if (dbUser.IsUserAdmin == adminUser)
                    {
                        UserType.UserKind = 1;
                    }
                    else
                        UserType.UserKind = 2;

                    try
                    {
                        newHome.Show();
                    }
                    catch(Exception)
                    {
                        Home newHome = new Home();
                        newHome.Show();
                    }

                }
            }
        }


    }
}
