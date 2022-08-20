using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Common.Models;

namespace WebApplication.Data.Interfaces
{
    public interface IUserRepository
    {
        IList<UserModal> GetAllUser();
        UserModal SaveUser(UserModal userModal);
        UserModal EditUser(UserModal userModal);
        UserModal GetUserByUserId(int userId);
        bool DeleteUserByUserId(int userId);
    }
}
