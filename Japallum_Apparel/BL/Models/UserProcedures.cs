using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;

namespace BL.Models
{
    public class UserProcedures
    {
        UserActions uA = new UserActions();
        public IEnumerable<User> displayUserList()
        {
            List<User> users = (List<User>)uA.getUserList();
            return users;
        }

        public void changeStatus(Boolean active, int id)
        {
            uA.updateUserActive(active, id);
        }
    }
}