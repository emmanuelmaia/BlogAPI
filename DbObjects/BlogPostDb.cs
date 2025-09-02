using APIRestful.Objetos;
using Microsoft.EntityFrameworkCore;
namespace APIRestful.DbObjects
{
    public class BlogPostDb : DbContext
    {        public BlogPostDb(DbContextOptions<BlogPostDb> options)
        : base(options) { }

        public DbSet<BlogPost> BlogPosts => Set<BlogPost>();
    }
}
