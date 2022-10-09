using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogin.Models;

namespace AppLogin.Repositories
{
    public class UsersRepo
    {
        private static Dictionary<long, User> Users = new Dictionary<long, User>();
        private static long UserIds = 0;

        public static CreateReponse CrearUsuario(User user)
        {
            
            Console.WriteLine(user.nickName);            
            CreateReponse response = new CreateReponse();
            //esta bien nickname?
            if (user.nickName == null || user.nickName.Length < 3)
                response.error = "No ingreso nigun usuario de almenos 4 digigitos.";
            //esta bien fullname?
            if (user.fullName == null || user.fullName.Length < 3)
                response.error = "No ingreso el nombre de almenos 4 digigitos.";
            //esta bien borndate?
            if (user.bornDate == null)
                response.error = "No ingreso fecha de nacimiento";
            //esta bien password?
            if (user.password == null || user.password.Length < 3)
                response.error = "No ingreso una contraseña de almenos 4 digigitos.";
            //hay error?
            if (response.error != null)
                return response;
            //busco el usuario por nickname
            User user2 = GetUserByNickName(user.nickName);
            //usaurio existe?
            if (user2 == null)
            {
                //+1 ids
                UserIds++;
                //edita el id del usuario
                user.id = UserIds;
                //gurdar el usaurio en la tabla
                Users.Add(UserIds, user);
                //entrega el nuevo id
                response.id = UserIds;
            }
            else response.error = "El nickName ya existe!";
            return response;           
        }

        public static User GetUserByNickNameAndPassword(string nickName, string password)
        {
            foreach(User user in Users.Values)
            {
                if(user.nickName == nickName && user.password == password)
                {
                    return user;
                }
            }
            return null;
        }

        public static User GetUserByNickName(string nickName)
        {
            foreach (User user in Users.Values)
            {
                if (user.nickName == nickName)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
