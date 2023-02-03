using AutoMapper;
using Zhao.Admin.ApplicationCore.Entities;
using Zhao.Admin.WebApi.Dtos;

namespace Zhao.Admin.WebApi.Profiles
{
    public class SampleProfile : Profile
    {
        public SampleProfile()
        {
            CreateMap<SampleDto, Sample>()
                .ForMember(
                    dest => dest.DateOnly,
                    opt =>
                    {
                        opt.MapFrom(src => DateOnly.FromDateTime(src.DateTime));
                    }
                );
            //CreateMap<Sample, SampleDto>();
        }
    }
}
