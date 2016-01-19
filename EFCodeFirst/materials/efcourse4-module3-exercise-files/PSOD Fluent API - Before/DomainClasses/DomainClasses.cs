﻿using System;
using System.Collections.Generic;

namespace DomainClasses
{
    public class Alias
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public DateTime CreateDate { get; set; }
        public byte[] Avatar { get; set; }
        public ICollection<Tweet> Tweets { get; set; }
        public byte[] RowVersion { get; set; }
        public string AliasPlusName
        {
            get { return Name + "(" + UserName + ")"; }
        }
     }

    public class Tweet
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Content { get; set; }
        public Alias Author { get; set; }
        public int AuthorId { get; set; }
    }
 
    public class Person
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public  Alias AliasAdministrator { get; set; }
        public  Alias AliasGuestAuthor { get; set; }
    }
    
}
