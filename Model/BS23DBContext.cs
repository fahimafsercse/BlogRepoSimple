namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BS23DBContext : DbContext
    {
        public BS23DBContext()
            : base("name=BS23DBContext")
        {
        }

        public virtual DbSet<AdminUser> AdminUsers { get; set; }
        public virtual DbSet<CommentDetail> CommentDetails { get; set; }
        public virtual DbSet<PostDetail> PostDetails { get; set; }
        public virtual DbSet<UserInformation> UserInformations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminUser>()
                .Property(e => e.AccountName)
                .IsUnicode(false);

            modelBuilder.Entity<AdminUser>()
                .Property(e => e.DisplayName)
                .IsUnicode(false);

            modelBuilder.Entity<AdminUser>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<CommentDetail>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<PostDetail>()
                .Property(e => e.Post)
                .IsUnicode(false);

            modelBuilder.Entity<PostDetail>()
                .HasMany(e => e.CommentDetails)
                .WithRequired(e => e.PostDetail)
                .HasForeignKey(e => e.PostDetail_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserInformation>()
                .Property(e => e.AccountName)
                .IsUnicode(false);

            modelBuilder.Entity<UserInformation>()
                .Property(e => e.DisplayName)
                .IsUnicode(false);

            modelBuilder.Entity<UserInformation>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<UserInformation>()
                .Property(e => e.Designation)
                .IsUnicode(false);

            modelBuilder.Entity<UserInformation>()
                .Property(e => e.Department)
                .IsUnicode(false);
        }
    }
}
