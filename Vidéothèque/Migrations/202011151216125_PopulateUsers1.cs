namespace Vidéothèque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUsers1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    
                
                INSERT INTO [dbo].[AspNetRoles]
                           ([Id]
                           ,[Name])
                     VALUES
                           ('50172e8e-76c3-4fbc-a85c-a6e130708b56'
                           ,'CanManageEverything')
                ;
                



                
                INSERT INTO [dbo].[AspNetUsers]
                           ([Id]
                           ,[Email]
                           ,[EmailConfirmed]
                           ,[PasswordHash]
                           ,[SecurityStamp]
                           ,[PhoneNumber]
                           ,[PhoneNumberConfirmed]
                           ,[TwoFactorEnabled]
                           ,[LockoutEndDateUtc]
                           ,[LockoutEnabled]
                           ,[AccessFailedCount]
                           ,[UserName])
                     VALUES
                           ('9f8ebacc-ea87-4d45-b338-22ac1ac149f9'
                           ,'test@guest.com'
                           ,0
                           ,'AKaXCx2fXRSQ0UdnR4wKO0vFi3uZfBfrWFasCNuy2F9SpNzKNBeFl5SiO47qEJfOZg=='
                           ,'20d9dd2e-1862-45dc-a26c-60c7da8852cb'
                           ,NULL
                           ,0
                           ,0
                           ,NULL
                           ,1
                           ,0
                           ,'test@guest.com');
                INSERT INTO [dbo].[AspNetUsers]
                           ([Id]
                           ,[Email]
                           ,[EmailConfirmed]
                           ,[PasswordHash]
                           ,[SecurityStamp]
                           ,[PhoneNumber]
                           ,[PhoneNumberConfirmed]
                           ,[TwoFactorEnabled]
                           ,[LockoutEndDateUtc]
                           ,[LockoutEnabled]
                           ,[AccessFailedCount]
                           ,[UserName])
                     VALUES
                           ('ca176bdb-6ac6-4770-8724-a957d9087e91'
                           ,'admin@test.com'
                           ,0
                           ,'AGSDXiNq/xGuaCF5xvsgbQ03uegOt2ObQUlJNxXt5EeRhpAh9rXMTLDE5q7RLzoTvw=='
                           ,'4dc56c07-c0a9-4adf-bc2a-f5ee2d75dde9'
                           ,NULL
                           ,0
                           ,0
                           ,NULL
                           ,1
                           ,0
                           ,'admin@test.com');


                INSERT INTO [dbo].[AspNetUserRoles]
                           ([UserId]
                           ,[RoleId])
                     VALUES
                           ('ca176bdb-6ac6-4770-8724-a957d9087e91'
                    ,
                           '50172e8e-76c3-4fbc-a85c-a6e130708b56')
                GO



                
                                
            ");
        }

        public override void Down()
        {
        }
    }
}
