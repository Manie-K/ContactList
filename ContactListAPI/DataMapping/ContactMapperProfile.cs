using AutoMapper;
using ContactListAPI.DTO;
using ContactListAPI.Models;

namespace ContactListAPI.DataMapping
{
    public class ContactMapperProfile : Profile
    {
        public ContactMapperProfile()
        {
            CreateMap<Contact, GetContactBasicDTO>();
            CreateMap<Contact, GetContactDetailsDTO>();
        }
    }
}
