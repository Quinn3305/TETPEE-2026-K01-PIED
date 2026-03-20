using Microsoft.EntityFrameworkCore;
using TetPee01.Repository.Entity;

namespace TetPee01.Repository;

public class AppDbContext : DbContext
{
    //Tạo rule cho mấy cái bảng của mình ý
    //User Seller Product Product_Catogory Category
    public static Guid User01 = Guid.NewGuid();
    public static Guid User02 = Guid.NewGuid();
    public static Guid Seller01 = Guid.NewGuid();
    public static Guid Seller02 = Guid.NewGuid();
    public static Guid Product01 = Guid.NewGuid();
    public static Guid Product02 = Guid.NewGuid();
    public static Guid ParentId1 = Guid.NewGuid();
    public static Guid ParentId2 = Guid.NewGuid();
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    public DbSet<User>  Users { get; set; }
    public DbSet<Category>  Categories { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Product_Category> ProductCategories { get; set; }
    
    //Set rule
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(builder =>
        {
            builder.Property(user => user.Email).IsRequired().HasMaxLength(256);
            builder.HasIndex(user => user.Email).IsUnique();
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(128);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(128);
            // builder.Property(u => u.ImageUrl).IsRequired().HasMaxLength(256);
            builder.Property(u => u.PhoneNumber).HasMaxLength(20);
            builder.Property(u => u.HashedPassword).IsRequired().HasMaxLength(500);
            builder.Property(u => u.Role).IsRequired().HasMaxLength(20).HasDefaultValue("user");
            //User - Seller
            builder.HasOne(u => u.Seller).WithOne(s => s.User).HasForeignKey<Seller>(s => s.UserId).OnDelete(DeleteBehavior.Cascade);
            
            //Tạo list User
            List<User> users = new List<User>()
            {
                new()
                {
                    Id = User01,
                    Email = "kin332k5@gmail.com",
                    FirstName = "Quyen",
                    LastName = "Vong",
                    HashedPassword = "HashedPassword01"
                },
                new()
                {
                    Id = User02,
                    Email = "kin2k5@gmail.com",
                    FirstName = "Quyen",
                    LastName = "Vong",
                    HashedPassword = "HashedPassword01"
                },
            };
            builder.HasData(users);
        });
       //Categories
       modelBuilder.Entity<Category>(builder =>
       {
            builder.Property(category => category.Name).IsRequired().HasMaxLength(128);
            var categories = new List<Category>()
            {
                new()
                {
                    Id = ParentId1,
                    Name = "Áo",
                },
                new()
                {
                    Id = ParentId2,
                    Name = "Quần",
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Áo Trẻ em",
                    ParentId = ParentId1,
                },
                new()
                {
                    Id =  Guid.NewGuid(),
                    Name = "Quần trẻ em",
                    ParentId = ParentId2,
                },
            };
            builder.HasData(categories);
       });
       //Seller
       modelBuilder.Entity<Seller>(builder =>
       {
           builder.Property(s => s.TaxCode).IsRequired().HasMaxLength(128);
           builder.Property(s => s.CompanyName).IsRequired().HasMaxLength(128);
           builder.Property(s=> s.CompanayAdress).IsRequired().HasMaxLength(128);
           var sellers = new List<Seller>()
           {
               new()
               {
                   Id = Seller01,
                   TaxCode = "TaxCode1",
                   CompanyName = "Company1",
                   CompanayAdress = "Address1",
                   UserId =  User01,
                   
               },
               new()
               {
                   Id = Seller02,
                   TaxCode = "TaxCode2",
                   CompanyName = "Company2",
                   CompanayAdress = "Address2",
                   UserId =  User02,
                },
           };
           builder.HasData(sellers);
       });
       modelBuilder.Entity<Product>(builder =>
       {
           builder.Property(p => p.Name).IsRequired().HasMaxLength(128);
           builder.Property(p => p.Description).IsRequired().HasMaxLength(128);
           builder.Property(p => p.UrlImage).IsRequired().HasMaxLength(256);
           builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");

           var products = new List<Product>()
           {
               new()
               {
                   Id = Product01,
                   Name = "Áó thun",
                   Description = "Áo xịn cotton",
                   UrlImage = "Link Hình",
                   Price = 100m,
                   SellerId = Seller01
                    
               },
               new()
               {
                   Id = Product02,
                   Name = "Quần nữ",
                   Description = "Quần co giãn xịn cotton",
                   UrlImage = "Link Hình",
                   Price = 999m,
                   SellerId = Seller02
                    
               }
           };
           builder.HasData(products);
       });

    }
}