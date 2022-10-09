using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppLogin.Models;
using AppLogin.Repositories;

namespace AppLogin
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            // ir al registro
            Register register = new Register();
            register.ShowDialog();       
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            User user = UsersRepo.GetUserByNickNameAndPassword(textNickName.Text, textPassword.Text);
            if(user != null)
            {
                //logiado!!
                Console.WriteLine(user.fullName);
            }
            else
            {
                //error
                MessageBox.Show("No se pudo logiar!!");
            }
        }
    }
}
