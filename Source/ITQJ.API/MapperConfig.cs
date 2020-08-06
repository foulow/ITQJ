using AutoMapper;
using ITQJ.Domain.DTOs;
using ITQJ.Domain.Entities;

namespace ITQJ.Domain
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            #region User Data Mapping
            // Mapeo de datos modelo User.
            CreateMap<UserCreateDTO, User>()
                .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<User, UserResponseDTO>();

            // Mapeo de datos modelo Review.
            CreateMap<ReviewCreateDTO, Review>()
                .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<Review, ReviewResponseDTO>();
            #endregion

            #region PersonalInfo Data Mapping
            // Mapeo de datos modelo Skill.
            CreateMap<Skill, SkillDTO>();
            // Mapeo de datos modelo ProfesionalSkills.
            CreateMap<ProfesionalSkillCreateDTO, ProfesionalSkill>()
                .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<ProfesionalSkillUpdateDTO, ProfesionalSkill>()
                .ForMember(dest => dest.Id, act => act.Ignore())
                .ForMember(dest => dest.PersonalInfoId, act => act.Ignore());
            CreateMap<ProfesionalSkill, ProfesionalSkillResponseDTO>();

            // Mapeo de datos modelo DocumentType.
            CreateMap<DocumentType, DocumentTypeDTO>();
            // Mapeo de datos modelo LegalDocument.
            CreateMap<LegalDocumentCreateDTO, LegalDocument>()
                .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<LegalDocumentUpdateDTO, LegalDocument>()
                .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<LegalDocument, LegalDocumentResponseDTO>();

            // Mapeo de datos modelo PersonalInfo.
            CreateMap<PersonalInfoCreateDTO, PersonalInfo>()
                .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<PersonalInfoUpdateDTO, PersonalInfo>()
                .ForMember(dest => dest.Id, act => act.Ignore())
                .ForMember(dest => dest.UserId, act => act.Ignore())
                .ForMember(dest => dest.LegalDocumentId, act => act.Ignore());
            CreateMap<PersonalInfo, PersonalInfoResponseDTO>();
            #endregion

            #region Project Data Mapping
            // Mapeo de datos modelo Project.
            CreateMap<ProjectCreateDTO, Project>()
                .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<ProjectUpdateDTO, Project>()
                .ForMember(dest => dest.Id, act => act.Ignore())
                .ForMember(dest => dest.UserId, act => act.Ignore());
            CreateMap<Project, ProjectResponseDTO>();

            // Mapeo de datos modelo Postulant.
            CreateMap<PostulantCreateDTO, Postulant>()
                .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<Postulant, PostulantResponseDTO>();

            // Mapeo de datos modelo Message.
            CreateMap<MessageCreateDTO, Message>()
                .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<Message, MessageResponseDTO>();
            #endregion
        }
    }
}
