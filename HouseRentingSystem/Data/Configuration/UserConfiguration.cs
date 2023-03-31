namespace HouseRentingSystem.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .Property(p => p.IsActive)
                .HasDefaultValue(true);

            builder.HasData(CreateUsers());
        }

        private List<ApplicationUser> CreateUsers()
        {
            var users = new List<ApplicationUser>();
            var hasher = new PasswordHasher<ApplicationUser>();

            var user = new ApplicationUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "agent@mail.com",
                NormalizedUserName = "agent@mail.com",
                Email = "agent@mail.com",
                NormalizedEmail = "agent@mail.com",
                FirstName = "Linda",
                LastName = "Michaels",
            };

            user.PasswordHash =
                 hasher.HashPassword(user, "agent123");

            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com",
                FirstName = "Teodor",
                LastName = "Lesly",
            };

            user.PasswordHash =
                hasher.HashPassword(user, "guest123");

            users.Add(user);
            
            user = new ApplicationUser()
            {
                Id = "6d4350ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "agent2@mail.com",
                NormalizedUserName = "agent2@mail.com",
                Email = "agent2@mail.com",
                NormalizedEmail = "agent2@mail.com",
                FirstName = "Jackson",
                LastName = "Dreison",
            };

            user.PasswordHash =
                hasher.HashPassword(user, "agent123");

            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                Email = AdminEmail,
                NormalizedEmail = AdminEmail,
                UserName = AdminEmail,
                NormalizedUserName = AdminEmail,
                FirstName = "Great",
                LastName = "Admin",
            };

            user.PasswordHash =
                hasher.HashPassword(user, "admin123");

            users.Add(user);

            return users;
        }
    }
}
