using AutoMapper;
using ITQJ.Domain.Models;

namespace ITQJ.API.DTOs
{
    public class DTOMapper : Profile
    {
        public DTOMapper()
        {
            #region WebData
            // Mapeo de datos de los Roles.
            CreateMap<RolDTO, Rol>()
                .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<Rol, RolDTO>();
            // Mapeo de datos de los Skills.
            CreateMap<SkillDTO, Skill>()
                .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<Skill, SkillDTO>();
            // Mapeo de datos de los DocumentTypes.
            CreateMap<DocumentTypeDTO, DocumentType>()
                .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<DocumentType, DocumentTypeDTO>();
            #endregion

            #region UserData
            // Mapeo de datos de los Usuarios.
            CreateMap<UserCreateDTO, User>();
            CreateMap<UserUpdateDTO, User>();
            CreateMap<User, UserResponseDTO>();
            #endregion
        }
    }
}
