using AutoMapper;
using Shared;
using Server.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Server.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Queue, Shared.Queue>()
                .ForMember(d => d.QueueId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.ImageLink, o => o.MapFrom(s => s.ImageLink))
                .ForMember(d => d.Count, o => o.MapFrom(s => s.Count));
            CreateMap<Models.QueueToken, Shared.QueueToken>()
                .ForMember(d => d.Animal, o => o.MapFrom(s => s.Animal))
                .ForMember(d => d.Color, o => o.MapFrom(s => s.Color));
        }
    }
}