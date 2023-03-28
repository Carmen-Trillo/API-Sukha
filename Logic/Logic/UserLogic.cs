﻿using Data;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly ServiceContext _serviceContext;
        public UserLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public int InsertUser(UserItem userItem)
        {
            if (userItem.IdRol == 1)
            {
                throw new InvalidOperationException();
            };

            _serviceContext.Users.Add(userItem);
            _serviceContext.SaveChanges();
            return userItem.Id;
        }

        public void UpdateUser(UserItem userItem)
        {
            _serviceContext.Users.Update(userItem);

            _serviceContext.SaveChanges();
        }
        public void DeleteUser(int id)
        {
            var userToDelete = _serviceContext.Set<UserItem>()
                 .Where(u => u.Id == id).First();

            userToDelete.IsActive = false;

            _serviceContext.SaveChanges();

        }

        public List<UserItem> GetAllUsers()
        {
            return _serviceContext.Set<UserItem>().ToList();
        }
        public List<UserItem> GetUsersByCriteria(UserFilter userFilter)
        {
            var resultList = _serviceContext.Set<UserItem>()
                  .Where(u => u.IsActive == true);

            if (userFilter.InsertDateFrom != null)
            {
                resultList = resultList.Where(u => u.InsertDate > userFilter.InsertDateFrom);
            }

            if (userFilter.InsertDateTo != null)
            {
                resultList = resultList.Where(u => u.InsertDate < userFilter.InsertDateTo);
            }

            return resultList.ToList();
        }

        
    }
}

/*namespace Entities.Entities
{
    public class UserItem
    {
        //atributos privados
        private string EncryptedPassword { get; set; }
        private string EncryptedToken { get; set; }
        //o así sería lo mismo, ya que ese { get; set; } está definido más abajo
        //private string EncryptedPassword;
        //private string EncryptedToken;
        //modificadores de accesibilidad
        //sirven para que como programador te asegures que no se están usando mal esos atributos,
        //sea en el Get o en el Set
        //puede ser privado tanto el Get del atributo, como el Set, como ambos
        //{ get; set; } esto lo que hace es definir por defecto un Get y un Set públicos simples.
        public string GetEncryptedPassword(string parametrosNecesarios, string masParametrosEnCasoDeNecesitarlos)
        {
            //validaciones
            //y toda la lógica o cuestiones de seguridad necesarias
            //restricciones y operaciones al Get
            //da más control y poder al momento de hacer el Get
            return this.EncryptedPassword;
        }
        public void SetEncryptedPassword(string parametrosNecesarios, string masParametrosEnCasoDeNecesitarlos)
        {
            //validaciones
            //y toda la lógica o cuestiones de seguridad necesarias
            //restricciones y operaciones al Set
            //da más control y poder al momento de hacer el Set
            this.EncryptedPassword = "lo que sea";
        }
    }
}*/
