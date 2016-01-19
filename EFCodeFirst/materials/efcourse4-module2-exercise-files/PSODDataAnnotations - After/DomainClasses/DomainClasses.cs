using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainClasses
{
    [Table("Authors", Schema = "guest")]
    public class Alias
    {
        public Alias()
        {
            PrivacySettings = new Privacy();
        }
        [Key, Column(Order = 0)]
        public int AuthorKey { get; set; }
        [Required]
        public string Name { get; set; }
        [MaxLength(30), MinLength(5)]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        [Column("DateStarted", Order = 1, TypeName = "date")]
        public DateTime CreateDate { get; set; }
        public byte[] Avatar { get; set; }
        public ICollection<Tweet> Tweets { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        [NotMapped]
        public string AliasPlusName
        { get { return Name + "(" + UserName + ")"; } }

        public Privacy PrivacySettings { get; set; }
        [InverseProperty("AliasAdministrator")]
        public List<Person> Admins { get; set; }
        [InverseProperty("AliasGuestAuthor")]
        public List<Person> GuestAuthors { get; set; }


     }

    [ComplexType]
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
        [ForeignKey("AuthorId")]
        public Alias Author { get; set; }
        public int AuthorId { get; set; }
    }
 
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Alias AliasAdministrator { get; set; }
        public Alias AliasGuestAuthor { get; set; }

    }
}
