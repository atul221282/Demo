using DomainClasses;
using Pluralsight.DataLayer;
using System.Data.Entity.Validation;
using System;
using System.Data.Entity;
using System.Linq;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Database.SetInitializer(new MyInitializer());
            //CreateBlog();
            //AddPost();
            GetJustOneBlog();
        }

        private static void GetJustOneBlog()
        {
            var db = new Context();
            var firstBlog = db.Blogs.First();
            foreach (Blog blog in db.Blogs.Local)
            {
                Console.WriteLine("{0}", blog.Title);
            }
            Console.ReadKey();

        }

        private static void AddPost()
        {
            var db = new Context();
            var blog = db.Blogs.Find(1);
            blog.Posts.Add(new Post
            {
                Title = "My First Post",
                Content = "Let's keep this short"
            });
            db.SaveChanges();
        }

        private static void CreateBlog()
        {
            var blog = new Blog {BloggerName = "Julie", Title = "EF41 Blog", DateCreated=DateTime.Now};
            //var blog = new Blog() { Title = "This is a blog with a really long blog title" };
            var db = new Context();
            db.Blogs.Add(blog);

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityError in ex.EntityValidationErrors)
                {
                    Console.WriteLine(entityError.Entry.Entity.GetType().Name);
                    foreach (var error in entityError.ValidationErrors)
                    {
                        Console.WriteLine("{0}: {1}", error.PropertyName, error.ErrorMessage);
                    }
                }
                Console.ReadKey();
            }

        }
    }
}
