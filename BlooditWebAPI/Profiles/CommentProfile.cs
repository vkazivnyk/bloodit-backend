using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlooditData.Models;
using BlooditWebAPI.GraphQL.Comments;

namespace BlooditWebAPI.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            // Source -> Target
            CreateMap<CommentAddInput, Comment>()
                .ForMember(c => c.Id, opt =>
                    opt.MapFrom(_ => Guid.NewGuid().ToString()))
                .ForMember(c => c.Date, opt =>
                    opt.MapFrom(_ => DateTime.Now));
        }
    }
}
