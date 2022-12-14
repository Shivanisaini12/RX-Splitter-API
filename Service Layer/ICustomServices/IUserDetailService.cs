using DomainLayer.Models;
using Repository_Layer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.ICustomServices
{
    public interface IUserDetailService
    {
        IEnumerable<UserDetail> GetAll();
        UserDetail Get(int Id);
        void Insert(UserDetail entity);
        void Update(UserDetail entity);
        void Delete(UserDetail entity);
    }
}
