using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Common.Models;
using WebApplication.Framework.Database;

namespace WebApplication.Data.Interfaces
{
    public interface IUserRepository
    {
        IList<UserModal> GetAllUser();
        UserModal SaveUser(UserModal userModal);
        UserModal EditUser(UserModal userModal);
        UserModal GetUserByUserId(int userId);
        User GetByUsername(string username);
        bool DeleteUserByUserId(int userId);
    }
}
