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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //ir al login
            this.Close();          
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            //tomar datos del usario del form
            User user = new User();
            user.nickName = textNick.Text;
            user.fullName = textFullName.Text;
            user.bornDate = dateBornDate.Value;
            user.password = textPassword.Text;
            //validar!!!

            ///
            //enviar los datos al server
            CreateReponse response = UsersRepo.CrearUsuario(user);
            //errores?
            if(response.error != null)
            {
                //mostrar mensaje
                MessageBox.Show(response.error, "Error al crear usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // ir a login
                this.Close();
            }
        }
    }
}
