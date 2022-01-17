using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlooditData.Models;
using BlooditWebAPI.GraphQL.Topics;

namespace BlooditWebAPI.Profiles
{
    public class TopicProfile : Profile
    {
        public TopicProfile()
        {
            // Source -> Target
            CreateMap<TopicAddInput, Topic>()
                .ForMember(t => t.Id,
                    opt => opt.MapFrom(_ => Guid.NewGuid().ToString()))
                .ForMember(t => t.CreationDate,
                    opt => opt.MapFrom(_ => DateTime.Now));
        }
    }
}
