using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Common.Models;
using WebApplication.Data.Interfaces;
using WebApplication.Framework.Database;

namespace WebApplication.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly TestDbContext testDbContext;

        public UserRepository(TestDbContext testDbContext)
        {
            this.testDbContext = testDbContext;
        }

        public IList<UserModal> GetAllUser()
        {
            var userEntity = testDbContext.Users.ToList();

            var userModelList = new List<UserModal>();

            userModelList = userEntity.Select(x => new UserModal
            {
                UserId = x.UserId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName,
                Age = x.Age,
                CodeId = x.CodeId,
                Password = "",
                UserRole = x.UserRole

            }).ToList();

            return userModelList;
        }

        public UserModal SaveUser(UserModal userModal)
        {
            //var userEntity = testDbContext.Users.Add
            User user = new User();

            if (userModal.UserId == 0)
            {
                user.UserId = userModal.UserId;
                user.FirstName = userModal.FirstName;
                user.LastName = userModal.LastName;
                user.Age = userModal.Age;
                user.UserName = userModal.UserName;
                user.CodeId = userModal.CodeId;
                user.Password = userModal.Password;
                user.UserRole = userModal.UserRole;
                user.CreateTime = DateTime.Now;

                testDbContext.Users.Add(user);
                testDbContext.SaveChanges();

                userModal.UserId = user.UserId;
            }

            return userModal;

        }


        public UserModal EditUser(UserModal userModal)
        {
            var findUser = testDbContext.Users.FirstOrDefault(x => x.UserId == userModal.UserId);

            if (findUser != null)
            {
                findUser.UserId = userModal.UserId;
                findUser.FirstName = userModal.FirstName;
                findUser.LastName = userModal.LastName;
                findUser.Age = userModal.Age;
                findUser.UserName = userModal.UserName;
                findUser.CodeId = userModal.CodeId;
                findUser.Password = userModal.Password;
                findUser.UserRole = userModal.UserRole;

                testDbContext.Users.Update(findUser);
                testDbContext.SaveChanges();
            }

            return userModal;
        }

        public UserModal GetUserByUserId(int userId)
        {
            var userModal = new UserModal();

            var findUser = testDbContext.Users.FirstOrDefault(x => x.UserId == userId);

            if (findUser != null)
            {
                userModal.UserId = findUser.UserId;
                userModal.FirstName = findUser.FirstName;
                userModal.LastName = findUser.LastName;
                userModal.Age = findUser.Age;
                userModal.UserName = findUser.UserName;
                userModal.CodeId = findUser.CodeId;
                userModal.Password = "";
                userModal.UserRole = findUser.UserRole;
            }

            return userModal;
        }

        public bool DeleteUserByUserId(int userId)
        {
            var findUser = testDbContext.Users.Find(userId);
            if (findUser != null)
            {
                testDbContext.Users.Remove(findUser);
                testDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
