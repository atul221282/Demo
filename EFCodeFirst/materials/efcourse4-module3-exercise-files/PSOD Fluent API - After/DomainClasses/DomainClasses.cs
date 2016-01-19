using System;
using System.Collections.Generic;

namespace DomainClasses
{
    public class Alias
    {
        public Alias()
        {
            PrivacySettings = new Privacy();
        }
        public int AuthorKey { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public DateTime CreateDate { get; set; }
       // public byte[] Avatar { get; set; }
        public virtual TwitterAvatar Avatar { get; set; }
        public ICollection<Tweet> Tweets { get; set; }
        public byte[] RowVersion { get; set; }
        public string AliasPlusName
        {
            get { return Name + "(" + UserName + ")"; }
        }

        public Privacy PrivacySettings { get; set; }
        public List<Person> Admins { get; set; }
        public List<Person> GuestAuthors { get; set; }

     }

    public class TwitterAvatar
    {
        public int AuthorKey { get; set; }
        public byte[] Avatar { get; set; }
    }

    public class Privacy
    {
        public int PrivacyId { get; set; }
        public bool TweetsArePrivate { get; set; }
        public bool AddLocationToTweets { get; set; }
        public bool HttpsRequired { get; set; }
    }

    public class Tweet
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Content { get; set; }
        public Alias Author { get; set; }
        public int AuthorId { get; set; }
    }
    public class LongTweet:Tweet
    {
        public string ExtraContent { get; set; }
    }
 
    public class Person
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public  Alias AliasAdministrator { get; set; }
        public  Alias AliasGuestAuthor { get; set; }
    }
    
}
