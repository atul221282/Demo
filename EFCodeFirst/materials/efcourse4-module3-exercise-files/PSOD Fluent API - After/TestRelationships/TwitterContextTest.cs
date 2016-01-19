using System.Linq;
using DataLayerFluent;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DomainClasses;
using System.Data.Entity;

namespace TestRelationships
{
    
    
    /// <summary>
    ///This is a test class for TwitterContextTest and is intended
    ///to contain all TwitterContextTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TwitterContextTest
    {
        [TestMethod()]
        public void AddGuestAuthorToAliasReturnsOneGuestAuthor()
        {
            Database.SetInitializer(new TweetInitializer());
            var context = new TwitterContext();
            var firstTwitterAlias=context.Aliases.First();
            var newPerson = new Person {Name = "Julie", AliasAdministrator = firstTwitterAlias};
            context.People.Add(newPerson);
            Assert.IsTrue(firstTwitterAlias.Admins.Count == 1);

         
        }
        [TestMethod()]
        public void AddGuestAuthorToAliasAndSaveChangesReturnsOneGuestAuthor()
        {
            Database.SetInitializer(new TweetInitializer());
            var context = new TwitterContext();
            var firstTwitterAlias = context.Aliases.First();
            var newPerson = new Person { Name = "Julie", AliasAdministrator = firstTwitterAlias };
            context.People.Add(newPerson);
            context.SaveChanges();
            context = new TwitterContext();
            var anotherTwitterAlias = context.Aliases.Include("Admins").First();
            Assert.IsTrue(anotherTwitterAlias.Admins.Count == 1);
        }
    }
}
