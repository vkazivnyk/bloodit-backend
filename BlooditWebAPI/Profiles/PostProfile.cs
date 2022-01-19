using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlooditData.Models;
using BlooditWebAPI.GraphQL.Posts;

namespace BlooditWebAPI.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            // Source -> Target
            CreateMap<PostAddInput, Post>()
                .ForMember(p => p.Id,
                    opt => opt.MapFrom(_ => Guid.NewGuid().ToString()))
                .ForMember(p => p.Date,
                    opt => opt.MapFrom(_ => DateTime.Now));

            CreateMap<PostUpdateInput, Post>();
        }
    }
}
