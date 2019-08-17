namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [DrivingLicense], [Phone], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a8d0d8bd-0d41-4c5c-9431-3d46714df8b8', N'Yes', N'0726396065', N'guest@vidly.com', 0, N'AKjoKYfbtkUdX5PN/ZM0MsTl/JJA9FhkRqzp9CM+vR+0NNdmH2m/kIvQbZfZnZYnRA==', N'8fc7d679-4f7e-4019-b64f-3ae7e42085d8', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [DrivingLicense], [Phone], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'aed40754-ef56-4f69-82ad-30209b5d1230', N'Yes', N'0722655071', N'admin@vidly.com', 0, N'AInHYXeq2CmkUb7dJ8PEARRf5D2mthhz0v21llvDgRRvPZR05CjZlCermD9GCB4ZSQ==', N'a2b868c1-a7dd-4493-b689-1fad0a8fd8cf', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [DrivingLicense], [Phone], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd700142c-d4f8-40ec-86ac-b4b03e3396d6', N'Yes', N'0722655071', N'arcas.gabi@gmail.com', 0, N'AIpkQJjZnQG/NCD0yrHWyKM3bMuBuca2C/vmkb5XoaYpabzMvjJCkVAkTpgoOj6ZXg==', N'fe1b6006-b0dc-48b6-9424-2922ce49f4b3', NULL, 0, 0, NULL, 1, 0, N'arcas.gabi@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'f04a6ba0-0bf5-49a7-a815-064d6d067051', N'CanManageMovies', N'IdentityRole')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'aed40754-ef56-4f69-82ad-30209b5d1230', N'f04a6ba0-0bf5-49a7-a815-064d6d067051')
");
        }
        
        public override void Down()
        {
        }
    }
}
