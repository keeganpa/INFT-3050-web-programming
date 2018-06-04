using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;

namespace BL.Models
{
    public class UserProcedures
    {
        RetrieveAccount accounts = new RetrieveAccount();
        public IEnumerable<User> displayUserList()
        {
            List<User> users = (List<User>)accounts.getUserList();
            return users;
        }

        public void changeStatus(Boolean active, int id)
        {
            UserActions uA = new UserActions();
            uA.updateUserActive(active, id);
        }
    }
}