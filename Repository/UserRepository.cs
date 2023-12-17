using blogCSharp.Context;
using blogCSharp.Models;
using blogCSharp.Repository.Base;
using blogCSharp.Repository.Interfaces;

namespace blogCSharp.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(BlogDbContext context) : base(context)
        {
        }
    }
}
