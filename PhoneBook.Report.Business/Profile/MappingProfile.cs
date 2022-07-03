using AutoMapper;
using PhoneBook.Report.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Report.Business
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<dbReport, ReportView>().
                ForMember(source => source.UUID, dest => dest.MapFrom(p => p.UUID)).
                ForMember(source => source.RequestDate, dest => dest.MapFrom(p => p.RequestDate)).
                ForMember(source => source.Status, dest => dest.MapFrom(p => p.Status)).
                ForMember(source => source.FileUrl, dest => dest.MapFrom(p => p.FileUrl)).
                ReverseMap();
        }
    }
}
