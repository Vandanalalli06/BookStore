using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        public IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public UserModel userRegistration(UserModel usermodel)
        {
            try
            {
                return userRL.userRegistration(usermodel);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
