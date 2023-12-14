using Microsoft.EntityFrameworkCore;

namespace WebProject.Models
{
    public partial class FPTBookContext : DbContext
    {
        public FPTBookContext()
        {
        }

        public FPTBookContext(DbContextOptions<FPTBookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAuthor> TblAuthors { get; set; } = null!;
        public virtual DbSet<TblBook> TblBooks { get; set; } = null!;
        public virtual DbSet<TblBookAuthor> TblBookAuthors { get; set; } = null!;
        public virtual DbSet<TblCart> TblCarts { get; set; } = null!;
        public virtual DbSet<TblCategory> TblCategories { get; set; } = null!;
        public virtual DbSet<TblCustomer> TblCustomers { get; set; } = null!;
        public virtual DbSet<TblOrder> TblOrders { get; set; } = null!;
        public virtual DbSet<TblPublisher> TblPublishers { get; set; } = null!;
        public virtual DbSet<TblStoreOwner> TblStoreOwners { get; set; } = null!;
        public virtual DbSet<Tbladmin> Tbladmins { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // #warning directive
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LIBRA13576; Database=FPTBook; Trusted_Connection=True; TrustServerCertificate=True;");
#pragma warning restore CS1030 // #warning directive
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAuthor>(entity =>
            {
                entity.HasKey(e => e.AuthorId)
                    .HasName("PK__tblAutho__8E2731D961022560");

                entity.ToTable("tblAuthor");

                entity.Property(e => e.AuthorId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("authorID");

                entity.Property(e => e.AuthorAdress)
                    .HasMaxLength(50)
                    .HasColumnName("authorAdress");

                entity.Property(e => e.AuthorEmail)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("authorEmail");

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(30)
                    .HasColumnName("authorName");
            });

            modelBuilder.Entity<TblBook>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__tblBook__8BE5A12DF6D6CCE0");

                entity.ToTable("tblBook");

                entity.Property(e => e.BookId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("bookID");

                entity.Property(e => e.BookDetailes)
                    .HasMaxLength(500)
                    .HasColumnName("bookDetailes");

                entity.Property(e => e.BookImage1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("bookImage1");

                entity.Property(e => e.BookPrice)
                    .HasColumnName("bookPrice")
                    .HasDefaultValueSql("((10))");

                entity.Property(e => e.BookTitle)
                    .HasMaxLength(60)
                    .HasColumnName("bookTitle");

                entity.Property(e => e.CatId).HasColumnName("catID");

                entity.Property(e => e.OwnerId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ownerID");

                entity.Property(e => e.PublisherId).HasColumnName("publisherID");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.TblBooks)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_catID");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.TblBooks)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ownerID");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.TblBooks)
                    .HasForeignKey(d => d.PublisherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_publisherID");
            });

            modelBuilder.Entity<TblBookAuthor>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.AuthorId })
                    .HasName("pk_bookauthor");

                entity.ToTable("tblBookAuthor");

                entity.Property(e => e.BookId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("bookID");

                entity.Property(e => e.AuthorId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("authorID");

                entity.Property(e => e.Details)
                    .HasMaxLength(300)
                    .HasColumnName("details");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.TblBookAuthors)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_authorID");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.TblBookAuthors)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_bookID");
            });

            modelBuilder.Entity<TblCart>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.CustomerId })
                    .HasName("pk_customercart");

                entity.ToTable("tblCart");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("orderID");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("customerID");

                entity.Property(e => e.BookId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("bookID");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.TblCarts)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_book");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TblCarts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customer_cart");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TblCarts)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cart_order");
            });

            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("PK__tblCateg__17B6DD26C2503E63");

                entity.ToTable("tblCategory");

                entity.HasIndex(e => e.CatName, "UQ__tblCateg__14D6C89BCED8FEC0")
                    .IsUnique();

                entity.Property(e => e.CatId).HasColumnName("catID");

                entity.Property(e => e.CatDetails)
                    .HasMaxLength(300)
                    .HasColumnName("catDetails");

                entity.Property(e => e.CatName)
                    .HasMaxLength(50)
                    .HasColumnName("catName");
            });

            modelBuilder.Entity<TblCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__tblCusto__B611CB9DDD8F8F9D");

                entity.ToTable("tblCustomer");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("customerID");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(30)
                    .HasColumnName("customerAddress");

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("customerEmail");

                entity.Property(e => e.CustomerFullname)
                    .HasMaxLength(30)
                    .HasColumnName("customerFullname");

                entity.Property(e => e.CustomerPassword)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("customerPassword");

                entity.Property(e => e.CustomerPhone)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("customerPhone");

                entity.Property(e => e.Customerphoto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("customerphoto");
            });

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__tblOrder__0809337D60267174");

                entity.ToTable("tblOrder");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("orderID");

                entity.Property(e => e.BookId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("bookID");

                entity.Property(e => e.CartId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cartID");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("customerID");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customer_order");
            });

            modelBuilder.Entity<TblPublisher>(entity =>
            {
                entity.HasKey(e => e.PublisherId)
                    .HasName("PK__tblPubli__7E8A0DF6C7B0E7DB");

                entity.ToTable("tblPublisher");

                entity.HasIndex(e => e.PublisherName, "UQ__tblPubli__22E7F395C7859A84")
                    .IsUnique();

                entity.Property(e => e.PublisherId).HasColumnName("publisherID");

                entity.Property(e => e.PublisherAddress)
                    .HasMaxLength(50)
                    .HasColumnName("publisherAddress");

                entity.Property(e => e.PublisherDetails)
                    .HasMaxLength(300)
                    .HasColumnName("publisherDetails");

                entity.Property(e => e.PublisherName)
                    .HasMaxLength(30)
                    .HasColumnName("publisherName");

                entity.Property(e => e.Publogo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("publogo");
            });

            modelBuilder.Entity<TblStoreOwner>(entity =>
            {
                entity.HasKey(e => e.OwnerId)
                    .HasName("PK__tblStore__7E4B716C05C8681E");

                entity.ToTable("tblStoreOwner");

                entity.Property(e => e.OwnerId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ownerID");

                entity.Property(e => e.OwnerAddress)
                    .HasMaxLength(50)
                    .HasColumnName("ownerAddress");

                entity.Property(e => e.OwnerDetails)
                    .HasMaxLength(300)
                    .HasColumnName("ownerDetails");

                entity.Property(e => e.OwnerName)
                    .HasMaxLength(30)
                    .HasColumnName("ownerName");

                entity.Property(e => e.OwnerPassword)
                    .HasMaxLength(300)
                    .HasColumnName("ownerPassword");

                entity.Property(e => e.OwnerPhone)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("ownerPhone");

                entity.Property(e => e.OwnerTaxCode)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("ownerTaxCode");

                entity.Property(e => e.Ownerphoto)
                    .HasMaxLength(50)
                    .HasColumnName("ownerphoto");
            });

            modelBuilder.Entity<Tbladmin>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("PK__tbladmin__AD05008694736448");

                entity.ToTable("tbladmin");

                entity.Property(e => e.AdminId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("adminID");

                entity.Property(e => e.Adminname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("adminname");

                entity.Property(e => e.Adminpassword)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("adminpassword");

                entity.Property(e => e.Adminphoto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("adminphoto");

                entity.Property(e => e.CatId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("catID");

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("customerEmail");

                entity.Property(e => e.OwnerId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ownerID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
