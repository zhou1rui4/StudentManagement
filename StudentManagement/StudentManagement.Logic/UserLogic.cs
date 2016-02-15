using System;
using System.Collections.Generic;
using System.Linq;
using StudentManagement.Data.Models;
using StudentManagement.ILogic;
using StudentManagement.Infrustructure;
using StudentManagement.IRepository;
using StudentManagement.Repository.UnitOfWork;

namespace StudentManagement.Logic
{
    public class UserLogic:IUserLogic
    {
        private readonly IUserRepository _userRepository ;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public UserLogic(IUserRepository userRepository ,IUnitOfWorkFactory unitOfWorkFactory)
        {
            _userRepository = userRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        
        public void Create(User model)
        {
            using (var unitOfwork= _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                model.Password = Cryptography.Encrypt(model.Password);
                model.LastLoginTime=DateTime.Now;
                _userRepository.Create(model);
                unitOfwork.Commit();
            }
        }

        public void Edit(User model)
        {
            using (var unitOfwork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _userRepository.Edit(model);
                unitOfwork.Commit();
            }
        }

        public void Delete(int id)
        {
            using (var unitOfwork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _userRepository.Delete(id);
                unitOfwork.Commit();
            }
        }

        public User Get(int id)
        {
            return _userRepository.Get(id);
        }

        public bool Login(string userName, string password,out string message)
        {
            message = "";
            
            var user = _userRepository.Get(userName);

            if (user == null)
            {
                message= "the userName is not register";
                return false;
            }
            if (user.Password.Equals(Cryptography.Encrypt(password)))
            {
                user.LastLoginTime=DateTime.Now;
                _userRepository.Edit(user);
                return true;
            }
            else
            {
                message = "the password error";
                return false;
            }
            
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.Query().ToList();
        }

        public IEnumerable<User> QueryByName(string userName)
        {
            return
                _userRepository.Query()
                    .Where(x => x.UserName.Contains(userName) )
                    .ToList();
        }
    }
}
