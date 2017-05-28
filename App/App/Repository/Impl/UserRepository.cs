﻿using App.Context;
using App.Entity;
using System.Collections.Generic;
using System.Linq;

namespace App.Repository.Impl
{
    /// <summary>
    /// 
    /// User Repository
    /// Author : Catalin Radoiu
    /// Author : Claudiu Nicola
    /// 
    /// </summary>
    public class UserRepository : AbstractRepository<User>, IUserRepository
    {
        public UserRepository(AppContext context) : base(context)
        {
        }

        public User FindUserByEmail(string email)
        {
            return Context.Users.SingleOrDefault(user => user.Email == email);
        }

        public List<Role> GetRoles(User user)
        {
            var queryRole = from item in Context.Roles
                            where item.UserRoles.Any(x => x.UserId == user.UserId)
                            select item;
            return queryRole.ToList();

        }
    }
}