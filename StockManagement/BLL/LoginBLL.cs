using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagement.GateWay;
using StockManagement.Model;

namespace StockManagement.BLL
{
    public class LoginBLL
    {
        LoginGateway loginGateway = new LoginGateway();

        public bool CheckUserNamePassword(Users user)
        {
            return loginGateway.CheckUserNamePassword(user);
        }
    }
}