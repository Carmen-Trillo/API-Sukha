using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface ISecurityLogic
    {
        bool ValidateUserCredentials(string usuarioUsuario, string usuarioPassword, int idRol);
    }

}
