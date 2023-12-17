using blogCSharp.Context;
using blogCSharp.Models;
using blogCSharp.Repository.Base;
using blogCSharp.Repository.Interfaces;

namespace blogCSharp.Repository
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(BlogDbContext context) : base(context)
        {
        }
    }
}
