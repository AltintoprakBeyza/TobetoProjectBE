﻿using AutoMapper;
using Business.Dtos.Requests.UserRequests;
using Business.Dtos.Responses.AddressResponses;
using Business.Dtos.Responses.CertificateResponses;
using Business.Dtos.Responses.ExperienceResponses;
using Business.Dtos.Responses.InstructorResponses;
using Business.Dtos.Responses.UserAnnouncementResponses;
using Business.Dtos.Responses.UserLanguageResponses;
using Business.Dtos.Responses.UserResponses;
using Business.Dtos.Responses.UserSocialMediaResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class UserProfile : Profile
{
    public UserProfile()

    {
        CreateMap<UserForLoginRequest, User>();
        CreateMap<User, CreatedUserResponse>();


        CreateMap<UserAnnouncement, GetListUserAnnouncementResponse>();
        CreateMap<Certificate, GetListCertificateResponse>();
        CreateMap<UserLanguage, GetListUserLanguageResponse>();
        CreateMap<UserSocialMedia, GetListUserSocialMediaResponse>();
        CreateMap<Experience, GetListExperienceResponse>();
        CreateMap<Address, GetListAddressResponse>();

        CreateMap<User, GetListUserResponse>()
            .ForMember(dest => dest.Certificates, opt => opt.MapFrom(src => src.Certificates))
            .ForMember(dest => dest.Experiences, opt => opt.MapFrom(src => src.Experiences))
            .ForMember(dest => dest.UserSocialMedias, opt => opt.MapFrom(src => src.UserSocialMedias))
            .ForMember(dest => dest.UserLanguages, opt => opt.MapFrom(src => src.UserLanguages))
            .ForMember(dest => dest.UserAnnouncements, opt => opt.MapFrom(src => src.UserAnnouncements))
            .ForMember(dest => dest.UserSurveys, opt => opt.MapFrom(src => src.UserSurveys))
            .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses))
            .ReverseMap();
            

        CreateMap<Paginate<User>, Paginate<GetListUserResponse>>();

        CreateMap<UpdateUserRequest, User>().ForMember(dest => dest.CreatedDate, opt => opt.Ignore());
        CreateMap<User, UpdatedUserResponse>();
    }
}
