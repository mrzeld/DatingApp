using System.Linq;
using AutoMapper;
using DatingApp.API.DTOs;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDTO>()
                .ForMember(dest => dest.PhotoURL, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).URL))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<User, UserForDetailedDTO>()
                .ForMember(dest => dest.PhotoURL, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).URL))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<UserForRegisterDTO, User>();
            CreateMap<Photo, PhotosForDetailedDTO>();
            CreateMap<UserForUpdateDTO, User>();
            CreateMap<Photo, PhotoForReturnDTO>();
            CreateMap<PhotoForCreationDTO, Photo>();
            CreateMap<MessageForCreationDTO, Message>().ReverseMap();
            CreateMap<Message, MessageToReturnDTO>()
                .ForMember(dest => dest.SenderPhotoURL, opt => opt.MapFrom(src => src.Sender.Photos.FirstOrDefault(p => p.IsMain).URL))
                .ForMember(dest => dest.RecipientPhotoURL, opt => opt.MapFrom(src => src.Recipient.Photos.FirstOrDefault(p => p.IsMain).URL));
        }
    }
}