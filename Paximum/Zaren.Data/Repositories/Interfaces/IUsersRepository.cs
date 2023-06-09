﻿using Zaren.Domain;
using System.Collections.Generic;

namespace Zaren.Data.Repositories.Interfaces
{
    public interface IUsersRepository : IRepository<User>
    {
        List<User> GetUsers();
        User FindUser(int id);
        void ActivateUser(User user);
        void SoftDeleteUser(User user);
        void EditUser(User user);
    }
}