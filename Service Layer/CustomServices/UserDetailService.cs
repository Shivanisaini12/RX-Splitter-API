//using DomainLayer.Data;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Repository_Layer.IRepository;
using Service_Layer.ICustomServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.CustomServices
{
    public class UserDetailService : IUserDetailService
    {
        private readonly IRepository<UserDetail> _user;
        public RxSplitterContext _context;
        public UserDetailService(IRepository<UserDetail> user, RxSplitterContext context)
        {
            _user = user;
            _context = context;
        }

        public void Delete(UserDetail entity)
        {
            _user.Delete(entity);
        }

        public UserDetail Get(int Id)
        {
            return _user.Get(Id);
        }

        public IEnumerable<UserDetail> GetAll()
        {
            return _user.GetAll();
        }

        public void Insert(UserDetail entity)
        {
            throw new NotImplementedException();
        }

        public void Update(UserDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
