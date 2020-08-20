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
            CreateMap<User, UserCreateDTO>();

            // Mapeo de datos modelo Review.
            CreateMap<ReviewCreateDTO, Review>()
                .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<Review, ReviewCreateDTO>();
            CreateMap<Review, ReviewResponseDTO>();
            #endregion

            #region PersonalInfo Data Mapping
            // Mapeo de datos modelo Skill.
            CreateMap<SkillDTO, Skill>();
            CreateMap<Skill, SkillDTO>();
            // Mapeo de datos modelo ProfesionalSkills.
            CreateMap<ProfesionalSkillCreateDTO, ProfesionalSkill>()
                .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<ProfesionalSkillUpdateDTO, ProfesionalSkill>()
                .ForMember(dest => dest.Id, act => act.Ignore())
                .ForMember(dest => dest.SkillId, act => act.Ignore())
                .ForMember(dest => dest.PersonalInfoId, act => act.Ignore());
            CreateMap<ProfesionalSkillResponseDTO, ProfesionalSkill>()
                .ForMember(dest => dest.Id, act => act.Ignore())
                .ForMember(dest => dest.SkillId, act => act.Ignore())
                .ForMember(dest => dest.PersonalInfoId, act => act.Ignore());
            CreateMap<ProfesionalSkill, ProfesionalSkillCreateDTO>();
            CreateMap<ProfesionalSkill, ProfesionalSkillResponseDTO>();

            // Mapeo de datos modelo DocumentType.
            CreateMap<DocumentTypeDTO, DocumentType>();
            CreateMap<DocumentType, DocumentTypeDTO>();
            // Mapeo de datos modelo LegalDocument.
            CreateMap<LegalDocumentCreateDTO, LegalDocument>()
                .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<LegalDocumentUpdateDTO, LegalDocument>()
                .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<LegalDocument, LegalDocumentCreateDTO>();
            CreateMap<LegalDocument, LegalDocumentResponseDTO>();

            // Mapeo de datos modelo PersonalInfo.
            CreateMap<PersonalInfoCreateDTO, PersonalInfo>()
                .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<PersonalInfoUpdateDTO, PersonalInfo>()
                .ForMember(dest => dest.Id, act => act.Ignore())
                .ForMember(dest => dest.UserId, act => act.Ignore())
                .ForMember(dest => dest.LegalDocumentId, act => act.Ignore());
            CreateMap<PersonalInfo, PersonalInfoCreateDTO>();
            CreateMap<PersonalInfo, PersonalInfoResponseDTO>();
            #endregion

            #region Project Data Mapping
            // Mapeo de datos modelo Project.
            CreateMap<ProjectCreateDTO, Project>()
                .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<ProjectUpdateDTO, Project>()
                .ForMember(dest => dest.Id, act => act.Ignore())
                .ForMember(dest => dest.UserId, act => act.Ignore());
            CreateMap<Project, ProjectCreateDTO>();
            CreateMap<Project, ProjectResponseDTO>();

            // Mapeo de datos modelo Postulant.
            CreateMap<PostulantCreateDTO, Postulant>()
                .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<PostulantUpdateDTO, Postulant>()
                .ForMember(dest => dest.Id, act => act.Ignore())
                .ForMember(dest => dest.ProjectId, act => act.Ignore())
                .ForMember(dest => dest.UserId, act => act.Ignore());
            CreateMap<Postulant, PostulantCreateDTO>();
            CreateMap<Postulant, PostulantResponseDTO>();

            // Mapeo de datos modelo Message.
            CreateMap<MessageCreateDTO, Message>()
                .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<Message, MessageCreateDTO>();
            CreateMap<Message, MessageResponseDTO>();

            // Mapeo de datos modelo MileStone.
            CreateMap<MileStoneCreateDTO, MileStone>()
                .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<MileStone, MileStoneCreateDTO>();
            CreateMap<MileStone, MileStoneResponseDTO>();
            #endregion
        }
    }
}
