namespace DAL
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ShopContext : DbContext
    {
        // Your context has been configured to use a 'ShopContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DAL.ShopContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ShopContext' 
        // connection string in the application configuration file.
        public ShopContext()
            : base("name=ShopDB")
        {
            Database.SetInitializer(new Configuration());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ShopHistory> ShopHistory { get; set; }
        public virtual DbSet<User> User { get; set; }
    }

    public class Configuration : CreateDatabaseIfNotExists<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
            context.User.Add(new User() { Name = "Bill", Surname = "Gates" });
            context.User.Add(new User() { Name = "Nil", Surname = "Gates" });

            context.Product.AddRange(new Product[] {
                new Product() { Name="Holo Lens",Image="Holo.jpg",Price=1500},
                new Product() { Name="Xbox One",Image="xbox.jpg",Price=300},
                new Product() { Name="Ps4",Image="ps4.jpg",Price=300}
            });

            context.SaveChanges();
        }
    }
}