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
    }

        public class TweetInitializer : DropCreateDatabaseAlways<TwitterContext>
        {
            protected override void Seed(TwitterContext context)
            {
                new List<Alias>{
            new Alias { Name = "julielerman", UserName = "Julie Lerman", CreateDate= new DateTime(2009,5,30),Email="julielerman@gmail.com",Bio="I live in Vermont",
            Tweets=new List<Tweet>{new Tweet() { Content="Having fun with Data Annotations",CreateDate=new DateTime(2011,6,1)}
            }},
            new Alias{ Name = "pluralsight", UserName = "Pluralsight",CreateDate=new DateTime(2009,1,20),Email="info@pluralsight.com",Bio="Hardcore developer training. Available on-demand.",
              Tweets=new List<Tweet>{new Tweet() { Content="Just published a new course on Entity Framework 4.1 by @julielerman",CreateDate=new DateTime(2011,6,15)}}},
            new Alias { Name = "giantpuppy", UserName = "Sampson the Newfie",CreateDate= new DateTime(2009,8,25),Email="giantpuppy@nomail.com",Bio="Silly Landseer Newfoundland",
                  Tweets=new List<Tweet>{new Tweet() { Content="Went for a great walk today. I swam and even saw a kitty!",CreateDate=new DateTime(2011,6,5)}
            }}
        }.ForEach(b => context.Aliases.Add(b));
                base.Seed(context);
            }
        }
    }

