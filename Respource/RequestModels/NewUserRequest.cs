﻿using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.RequestModels
{
    public class NewUserRequest
    {
        public int IdUser { get; set; }
        public int IdPerson { get; set; }
        public int IdRol { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public UserItem ToUserItem()
        {
            var userItem = new UserItem();

            userItem.IdPerson = IdPerson;
            userItem.IdRol = IdRol;
            userItem.User = User;
            userItem.Password = Password;

            userItem.InsertDate = DateTime.Now;
            userItem.UpdateDate = DateTime.Now;
            userItem.IsActive = true;

            return userItem;
        }

  
    }
}
