using Data;
using Entities.Entities;
using Logic.ILogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class SecurityLogic : ISecurityLogic
    {
        private readonly ServiceContext _serviceContext;

        public SecurityLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        public bool ValidateUserCredentials(string userUser, string userPassWord, int idRolItem)
        {
            var selectedUser = _serviceContext.Set<UserItem>()
                                    .FirstOrDefaultAsync(u => u.User == userUser
                                        && u.Password == userPassWord
                                        && u.IdRol == idRolItem);

            return selectedUser != null;
        }
    }
}
