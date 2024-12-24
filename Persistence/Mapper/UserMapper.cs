using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Services.Mapper
{
    public class UserMapper
    {
        private readonly IMapper mapperToDTO;
        private readonly IMapper mapperToEntity;

        public UserMapper()
        {
            mapperToDTO = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            mapperToEntity = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()).CreateMapper();
        }
        
        public UserDTO ToDTO(User user)
        {
            return mapperToDTO.Map<UserDTO>(user);
        }

        public User ToEntity(UserDTO userDTO)
        {
            return mapperToEntity.Map<User>(userDTO);
        }

        public ICollection<UserDTO> ToListDTO(ICollection<User> users)
        {
            return mapperToDTO.Map<ICollection<UserDTO>>(users);
        }

        public ICollection<User> ToListEntity(ICollection<UserDTO> userDtos)
        {
            return mapperToEntity.Map<ICollection<User>>(userDtos);
        }
    }
}
