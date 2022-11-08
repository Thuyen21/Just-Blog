using JustBlog.Entities.Entities;
using Microsoft.AspNetCore.Identity;

namespace JustBlog.Entities.Context;

public static class Seed
{
    internal static Post[] Posts =
    {
        new()
        {
            Id = Guid.Parse("37026059-494f-499e-ac1a-17fb1f8736b0"),
            Title = "Post 1",
            ShortDescription = "Short Description 1",
            Description = "Description 1",
            Content = "Content 1",
            UrlSlug = "post-1",
            Published = true,
            PostedOn = DateTime.Parse("9/21/2022"),
            Modified = DateTime.Parse("9/21/2022"),
            ViewCount = 2,
            RateCount = 2,
            TotalRate = 10,
            CategoryId = Guid.Parse("bf2a84ab-68f7-482d-8dcd-f2c0f9028049"),
        },
        new()
        {

            Id = Guid.Parse("8d248b4b-2a7d-4a85-a2d9-9688ce5aa9a2"),
            Title = "Post 2",
            ShortDescription = "Short Description 2",
            Description = "Description 2",
            Content = "Content 2",
            UrlSlug = "post-2",
            Published = true,
            PostedOn = DateTime.Parse("9/21/2022"),
            Modified = DateTime.Parse("9/21/2022"),
            ViewCount = 5,
            RateCount = 5,
            TotalRate = 15,
            CategoryId = Guid.Parse("e1a767ca-708a-4392-bf9a-c16dcf9ab04f"),

        },
        new()
        {
            Id = Guid.Parse("274ccdc9-922d-42d3-9931-5448b6a21f21"),
            Title = "Post 3",
            ShortDescription = "Short Description 3",
            Description = "Description 3",
            Content = "Content 3",
            UrlSlug = "post-3",
            Published = true,
            PostedOn = DateTime.Parse("9/21/2022"),
            Modified = DateTime.Parse("9/21/2022"),
            ViewCount = 10,
            RateCount = 10,
            TotalRate = 10,
            CategoryId = Guid.Parse("4245cf7a-4aa2-4467-b411-518830a4a43a"),
        },

    };
    internal static Category[] Categories =
    {
        new()
        {
            Id = Posts[0].CategoryId,
            Name = "Category 1",
            UrlSlug = "category-1",
            Description = "Description 1"
        } ,

        new()
        {
            Id = Posts[1].CategoryId,
            Name = "Category 2",
            UrlSlug = "category-2",
            Description = "Description 2"
        },
        new()
        {
            Id = Posts[2].CategoryId,
            Name = "Category 3",
            UrlSlug = "category-3",
            Description = "Description 3"

        }
    };
    internal static Tag[] Tags =
    {
        new()
        {
            Id = Guid.Parse("bc341849-ae9c-4dc6-8735-ac10d1d76ac1"),
            Name = "Tag 1",
            UrlSlug = "tag-1",
            Description = "Description 1"
        },
        new()
        {
            Id = Guid.Parse("90ee6cd8-7e27-43ea-95a2-1cb21edff54e"),
            Name = "Tag 2",
            UrlSlug = "tag-2",
            Description = "Description 2"
        },
        new()
        {
            Id = Guid.Parse("48c1c139-b86e-4811-899b-05d81814a394"),
            Name = "Tag 3",
            UrlSlug = "tag-3",
            Description = "Description 3"
        }
    };
    internal static PostTag[] PostTags =
    {
        new()
        {
            PostId = Posts[0].Id,
            TagId = Tags[0].Id
        },
        new()
        {
            PostId = Posts[0].Id,
            TagId = Tags[1].Id
        },
        new()
        {
            PostId = Posts[1].Id,
            TagId = Tags[1].Id
        },
        new()
        {
            PostId = Posts[1].Id,
            TagId = Tags[2].Id
        },
        new()
        {
            PostId = Posts[2].Id,
            TagId = Tags[2].Id
        },
        new()
        {
            PostId = Posts[2].Id,
            TagId = Tags[0].Id
        }
    };
    internal static Comment[] Comments =
    {
        new ()
        {
            Id = Guid.Parse("257b9810-bb2d-4d79-a862-a90dbb7f614d"),
            PostId = Posts[0].Id,
            Name = "Comment 1",
            Email = "email1@exmaple.com",
            Body = "Content 1",
            Header = "Comment Header 1",
        },
        new ()
        {
            Id = Guid.Parse("bc6223dd-dd5d-44d0-b0a9-920360514b6f"),
            PostId = Posts[0].Id,
            Name = "Comment 2",
            Email = "email2@exmaple.com",
            Body = "Content 2",
            Header = "Comment Header 2",
        },
        new ()
        {
            Id = Guid.Parse("92c9b568-c7f1-48ad-a8c6-d547ed663fd8"),
            PostId = Posts[1].Id,
            Name = "Comment 3",
            Email = "email3@exmaple.com",
            Body = "Content 3",
            Header = "Comment Header 3",
        },
    };


    internal static IdentityRole<Guid>[] Roles =
    {
        new()
        {
            Id = Guid.Parse("e9d69a07-8601-4d43-8e80-190e97bb068f"),
            Name = "Blog Owner",
            NormalizedName = "BLOG OWNER",
        },
        new()
        {
            Id = Guid.Parse("9b47fbf8-e0b6-48af-8fa9-3636c7f815ec"),
            Name = "User",
            NormalizedName = "USER",
        },
        new()
        {
            Id = Guid.Parse("dc71a2ee-5450-4827-a74a-4ee47043450b"),
            Name = "Contributor",
            NormalizedName = "CONTRIBUTOR",
        }
    };

    private static readonly PasswordHasher<ApplicationUser> hasher = new();
    internal static ApplicationUser[] Users =
    {
        new()
        {
            Id = Guid.Parse("56de49b5-22c6-4e3e-8e8c-6adb86a24cc9"),
            UserName = "user@example.com",
            NormalizedUserName = "user@example.com".ToUpper(),
            Email = "user@example.com",
            NormalizedEmail = "user@example.com".ToUpper(),
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "User@123"),
            SecurityStamp = string.Empty,
                LockoutEnabled = false,
        },
        new()
        {
            Id = Guid.Parse("ac924737-2076-4cab-983a-f184ef7f2f1b"),
            UserName = "user1@example.com",
            NormalizedUserName = "user1@example.com".ToUpper(),
            Email = "user1@example.com",
            NormalizedEmail = "user1@example.com".ToUpper(),
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "User1@123"),
             SecurityStamp = string.Empty,
                LockoutEnabled = false,
        },
        new()
        {
            Id = Guid.Parse("da1d155d-2eb4-46ad-81ed-ddd99ea58b4e"),
            UserName = "user2@example.com",
            NormalizedUserName = "user2@example.com".ToUpper(),
            Email = "user2@example.com",
            NormalizedEmail = "user2@example.com".ToUpper(),
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "User2@123"),
             SecurityStamp = string.Empty,
                LockoutEnabled = false,
        },
        new()
        {
            Id = Guid.Parse("1c917bbc-383b-4b7e-9fce-bfd76f2f4aed"),
            UserName = "owner@example.com",
            NormalizedUserName = "owner@example.com".ToUpper(),
            Email = "owner@example.com",
            NormalizedEmail = "owner@example.com".ToUpper(),
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "Owner@123"),
             SecurityStamp = string.Empty,
                LockoutEnabled = false,
        },
        new()
        {
            Id = Guid.Parse("c92627c0-9156-494d-bc90-ad381f136852"),
            UserName = "owner1@example.com",
            NormalizedUserName = "owner1@example.com".ToUpper(),
            Email = "owner1@example.com",
            NormalizedEmail = "owner1@example.com".ToUpper(),
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "Owner1@123"),
             SecurityStamp = string.Empty,
                LockoutEnabled = false,
        },
         new()
        {
            Id = Guid.Parse("55c97cf2-48a1-455c-80e0-307cca32e4fa"),
            UserName = "owner2@example.com",
            NormalizedUserName = "owner2@example.com".ToUpper(),
            Email = "owner2@example.com",
            NormalizedEmail = "owner2@example.com".ToUpper(),
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "Owner2@123"),
             SecurityStamp = string.Empty,
                LockoutEnabled = false,
        },
           new()
        {
            Id = Guid.Parse("8b5ed246-11b1-4df6-b36a-9be399f60891"),
            UserName = "contributor@example.com",
            NormalizedUserName = "contributor@example.com".ToUpper(),
            Email = "contributor@example.com",
            NormalizedEmail = "contributor@example.com".ToUpper(),
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "Contributor@123"),
             SecurityStamp = string.Empty,
                LockoutEnabled = false,
        },
            new()
        {
            Id = Guid.Parse("aeae5ff8-43cd-4f90-8d9e-234b9c2d14b9"),
            UserName = "contributor1@example.com",
            NormalizedUserName = "contributor1@example.com".ToUpper(),
            Email = "contributor1@example.com",
            NormalizedEmail = "contributor1@example.com".ToUpper(),
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "Contributor1@123"),
             SecurityStamp = string.Empty,
                LockoutEnabled = false,
        },
                new()
        {
            Id = Guid.Parse("70369848-8782-4928-b8e3-106db74c5f3f"),
            UserName = "contributor2@example.com",
            NormalizedUserName = "contributor2@example.com".ToUpper(),
            Email = "contributor2@example.com",
            NormalizedEmail = "contributor2@example.com".ToUpper(),
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "Contributor2@123"),
             SecurityStamp = string.Empty,
                LockoutEnabled = false,
        },
    };
    internal static IdentityUserRole<Guid>[] UserRoles =
    {
        new()
        {
            UserId = Guid.Parse("55c97cf2-48a1-455c-80e0-307cca32e4fa"),
            RoleId = Guid.Parse("e9d69a07-8601-4d43-8e80-190e97bb068f"),
        },
        new()
        {
            UserId = Guid.Parse("c92627c0-9156-494d-bc90-ad381f136852"),
            RoleId = Guid.Parse("e9d69a07-8601-4d43-8e80-190e97bb068f"),
        },
        new()
        {
            UserId = Guid.Parse("1c917bbc-383b-4b7e-9fce-bfd76f2f4aed"),
            RoleId = Guid.Parse("e9d69a07-8601-4d43-8e80-190e97bb068f"),
        },
        new()
        {
            UserId = Guid.Parse("56de49b5-22c6-4e3e-8e8c-6adb86a24cc9"),
            RoleId = Guid.Parse("9b47fbf8-e0b6-48af-8fa9-3636c7f815ec"),
        },
        new()
        {
            UserId = Guid.Parse("ac924737-2076-4cab-983a-f184ef7f2f1b"),
            RoleId = Guid.Parse("9b47fbf8-e0b6-48af-8fa9-3636c7f815ec"),
        },
        new()
        {
            UserId = Guid.Parse("da1d155d-2eb4-46ad-81ed-ddd99ea58b4e"),
            RoleId = Guid.Parse("9b47fbf8-e0b6-48af-8fa9-3636c7f815ec"),
        },
        new()
        {
            UserId = Guid.Parse("70369848-8782-4928-b8e3-106db74c5f3f"),
            RoleId = Guid.Parse("dc71a2ee-5450-4827-a74a-4ee47043450b"),
        },
        new()
        {
            UserId = Guid.Parse("aeae5ff8-43cd-4f90-8d9e-234b9c2d14b9"),
            RoleId = Guid.Parse("dc71a2ee-5450-4827-a74a-4ee47043450b"),
        }
        ,new()
        {
            UserId = Guid.Parse("8b5ed246-11b1-4df6-b36a-9be399f60891"),
            RoleId = Guid.Parse("dc71a2ee-5450-4827-a74a-4ee47043450b"),
        }
    };
}