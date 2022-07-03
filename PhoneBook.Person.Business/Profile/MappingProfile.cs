using AutoMapper;
using PhoneBook.Person.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Person.Business
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<dbPerson, PersonView>().ReverseMap();

            CreateMap<dbPerson, PersonDetailView>()
                .ForMember(source => source.Contacts, dest => dest.MapFrom(p => p.dbContacts))
                .ReverseMap();

            CreateMap<dbContactType, ContactTypeView>().ReverseMap();

            CreateMap<dbContact, ContactView>().
                ForMember(source => source.UUID, dest => dest.MapFrom(p => p.UUID)).
                ForMember(source => source.Content, dest => dest.MapFrom(p => p.Content)).
                ForMember(source => source.ContactTypeUUID, dest => dest.MapFrom(p => p.dbContactTypeUUID)).
                ForMember(source => source.PersonUUID, dest => dest.MapFrom(p => p.dbPersonUUID)).
                ReverseMap();
        }
    }
}
