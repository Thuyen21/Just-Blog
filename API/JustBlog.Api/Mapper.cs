using JustBlog.Entities.Entities;
using JustBlog.Model.Categories;
using JustBlog.Model.Posts;
using Mapster;

namespace JustBlog.Api
{
    public static class Mapper
    {
        public static void AddMapperGlobal(this WebApplicationBuilder webApplicationBuilder)
        {
            TypeAdapterConfig<Category, CategoryVM>
                 .NewConfig()
             .Map(dest => dest.PostTitles,
                 src => src.Posts.Select(x => x.Title).ToList())
             .Map(dest => dest.PostIds,
                 src => src.Posts.Select(x => x.Id).ToList()).TwoWays();

            TypeAdapterConfig<PostCM, Post>
                 .NewConfig()
             .Map(dest => dest.PostTags,
                 src => src.Tags.Select(x => new PostTag { TagId = x }).ToList()).TwoWays();

            TypeAdapterConfig<Post, PostVM>
                 .NewConfig()
                 .Map(dest => dest.Tags,
                 src => src.PostTags.Select(x => x.Tag.Name).ToList()).TwoWays();

            TypeAdapterConfig<PostUM, Post>
                .NewConfig()
            .Map(dest => dest.PostTags,
                src => src.Tags.Select(x => new PostTag { TagId = x }).ToList()).TwoWays();

            //TypeAdapterConfig<Category, Select>
            //    .NewConfig()
            //.Map(dest => dest.Id,
            //    src => src.Id)
            //.Map(dest => dest.Name,
            //    src => src.Name)
            //.TwoWays();

            //TypeAdapterConfig<Tag, Select>
            //    .NewConfig()
            //.Map(dest => dest.Id,
            //    src => src.Id)
            //.Map(dest => dest.Name,
            //    src => src.Name)
            //.TwoWays();
        }
    }
}