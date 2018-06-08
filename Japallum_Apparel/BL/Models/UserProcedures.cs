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

        // Method used to get a list of users from the DAL
        public IEnumerable<User> displayUserList()
        {
            List<User> users = (List<User>)uA.getUserList();
            return users;
        }

        // Method used to change the active status of a user
        public void changeStatus(Boolean active, int id)
        {
            uA.updateUserActive(active, id);
        }
    }
}