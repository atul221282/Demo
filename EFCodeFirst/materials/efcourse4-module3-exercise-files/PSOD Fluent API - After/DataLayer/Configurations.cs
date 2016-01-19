using System.Data.Entity.ModelConfiguration;
using DomainClasses;

namespace DataLayerFluent
{
    internal class AliasConfiguration : EntityTypeConfiguration<Alias>
    {
        public AliasConfiguration()
        {
           HasKey(a => a.AuthorKey);
          Property(a => a.CreateDate)
                .HasColumnName("StartDate")
                .HasColumnOrder(1)
                .HasColumnType("date");
                //.HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.DatabaseGeneratedOption.Computed);
            Property(a => a.Name).IsFixedLength().HasMaxLength(40);
            ToTable("TwitterAliases");
            HasRequired(a => a.Avatar).WithRequiredPrincipal();
            
            Property(a => a.Name).IsConcurrencyToken();
            Property(a => a.RowVersion).IsRowVersion();
        }
    }

    internal class TweetConfiguration: EntityTypeConfiguration<Tweet>
    {
        public TweetConfiguration()
        {
            HasRequired(t => t.Author).WithMany(a => a.Tweets).HasForeignKey(t => t.AuthorId);
            HasRequired(t => t.Author).WithMany(a => a.Tweets).HasForeignKey(t => t.AuthorId);
            
            //Map<Tweet>(m => m.Requires("IsLong").HasValue(0));
            //Map<LongTweet>(m => m.Requires("IsLong").HasValue(1));

            Map<Tweet>(m=>m.ToTable("Tweets"));
        }
    }
    internal class LongTweetConfiguration : EntityTypeConfiguration<LongTweet>
    {
        public LongTweetConfiguration()
        {
           Map<LongTweet>(m=>m.ToTable("LongTweets"));
        }
    }
    internal class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            HasOptional(p => p.AliasAdministrator).WithMany(a => a.Admins).WillCascadeOnDelete(false);
            HasOptional(p => p.AliasGuestAuthor).WithMany(a => a.GuestAuthors).WillCascadeOnDelete(false);
        }
    }
    internal class AvatarConfiguration : EntityTypeConfiguration<TwitterAvatar>
    {
        public AvatarConfiguration()
        {
            HasKey(a => a.AuthorKey);
            ToTable("TwitterAliases");
        }
    }
}
