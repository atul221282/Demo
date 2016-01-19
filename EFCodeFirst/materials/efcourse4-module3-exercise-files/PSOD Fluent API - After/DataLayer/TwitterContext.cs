using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Drawing;
using System.Net.Mime;
using DomainClasses;

namespace DataLayerFluent
{
    public class TwitterContext : DbContext
    {
        public DbSet<Alias> Aliases { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          //all of these commented out configs were moved into configuration classes
            //    modelBuilder.Entity<Alias>().ToTable("TwitterAliases", "guest");
            //modelBuilder.Entity<Alias>().HasKey(a => a.AuthorKey);
            //modelBuilder.Entity<TwitterAvatar>().HasKey(a => a.AuthorKey);
            //modelBuilder.Entity<Alias>().Property(a => a.CreateDate)
            //    .HasColumnName("StartDate")
            //    .HasColumnOrder(1)
            //    .HasColumnType("date")
            //    .IsRequired();
            //modelBuilder.Entity<Alias>().Property(a => a.Name).IsFixedLength().HasMaxLength(40);
            //  modelBuilder.ComplexType<Privacy>();
            modelBuilder.Ignore<Privacy>();

            //modelBuilder.Entity<Alias>()
            //    .Map(mc =>
            //    {
            //        mc.Properties(a => new { a.AuthorKey, a.Bio, a.CreateDate,
            //                                 a.Email, a.Name, a.RowVersion, a.UserName });
            //        mc.ToTable("TwitterAliases");
            //    })
            //    .Map(mc =>
            //    {
            //        mc.Properties(p => new { p.AuthorKey, p.Avatar });
            //        mc.ToTable("TwitterAvatar");
            //    });

            //modelBuilder.Entity<Alias>().ToTable("TwitterAliases");
            //modelBuilder.Entity<TwitterAvatar>().ToTable("TwitterAliases");
            //modelBuilder.Entity<Alias>().HasRequired(a => a.Avatar).WithRequiredPrincipal();
            modelBuilder.Configurations.Add(new AliasConfiguration());
            modelBuilder.Configurations.Add(new AvatarConfiguration());
            modelBuilder.Configurations.Add(new TweetConfiguration());
            modelBuilder.Configurations.Add(new PersonConfiguration());
            modelBuilder.Configurations.Add(new LongTweetConfiguration());
        }
    }

   

    public class TweetInitializer : DropCreateDatabaseAlways<TwitterContext>
    {
        protected override void Seed(TwitterContext context)
        {
            new List<Alias>{
            new Alias { Name = "julielerman", UserName = "Julie Lerman", CreateDate= new DateTime(2009,5,30),Email="julielerman@gmail.com",Bio="I live in Vermont",
                Avatar=new TwitterAvatar{ Avatar=GetImageFromFile("\\Content\\JulieSimpson.png")},
            Tweets=new List<Tweet>{new Tweet() { Content="Having fun with Data Annotations",CreateDate=new DateTime(2011,6,1)}
            }},
            new Alias{ Name = "pluralsight", UserName = "Pluralsight",CreateDate=new DateTime(2009,1,20),Email="info@pluralsight.com",Bio="Hardcore developer training. Available on-demand.",
                 Avatar=new TwitterAvatar{ Avatar=new byte[]{0}},
              Tweets=new List<Tweet>{new Tweet() { Content="Just published a new course on Entity Framework 4.1 by @julielerman",CreateDate=new DateTime(2011,6,15)}}},
            new Alias { Name = "giantpuppy", UserName = "Sampson the Newfie",CreateDate= new DateTime(2009,8,25),Email="giantpuppy@nomail.com",Bio="Silly Landseer Newfoundland",
                 Avatar=new TwitterAvatar{ Avatar=new byte[]{0}},
                  Tweets=new List<Tweet>{new Tweet() { Content="Went for a great walk today. I swam and even saw a kitty!",CreateDate=new DateTime(2011,6,5)}
            }}
        }.ForEach(b => context.Aliases.Add(b));
            base.Seed(context);
        }
        private byte[] GetImageFromFile(string imagePath)
        {
            var apppath =
                (System.IO.Directory.GetParent(
                     System.IO.Path.GetDirectoryName(
                         System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6))).FullName;
            var i = new Bitmap(apppath +imagePath);
            var converter = new ImageConverter();
            return (byte[])converter.ConvertTo(i, typeof (byte[]));
        }
    }
}
