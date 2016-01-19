using System.Data.Entity;
using DomainClasses;
using System.Collections.Generic;

namespace Pluralsight.DataLayer
{
    public class Context : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasKey(b => b.Id).Property(b => b.Title).HasMaxLength(20);
            modelBuilder.Entity<Blog>().Property(b => b.BloggerName).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }

    public class MyInitializer : DropCreateDatabaseAlways<Context>
    {

        protected override void Seed(Context context)
        {
            new List<Blog>{
            new Blog { BloggerName = "Julie", Title = "My Code First Blog", DateCreated=new System.DateTime(2011,4,1),
            Posts=new List<Post>{new Post { Title="DB Initialization Annotation", Content="Mark navigation property with ForeignKey"}
            }},
            new Blog { BloggerName = "Ingemaar", Title = "My Life as a Blog",DateCreated=new System.DateTime(2011,3,1)},
            new Blog { BloggerName = "Sampson", Title = "Tweeting for Dogs",DateCreated=new System.DateTime(2011,5,1)}
        }.ForEach(b => context.Blogs.Add(b));
            base.Seed(context);
        }
    }


}
