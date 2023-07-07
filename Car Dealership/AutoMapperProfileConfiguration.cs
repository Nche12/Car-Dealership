
namespace Car_Dealership
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<User, UserGetDto>();
            CreateMap<UserEditDto, User>();
            CreateMap<UserCreateDto, User>();

            CreateMap<UserRole, UserRoleGetDto>();
            CreateMap<UserRoleEditDto, UserRole>();
            CreateMap<UserRoleCreateDto, UserRole>();

            CreateMap<CarMake, CarMakeGetDto>();
            CreateMap<CarMakeEditDto, CarMake>();
            CreateMap<CarMakeCreateDto, CarMake>();

            CreateMap<CarModel, CarModelGetDto>();
            CreateMap<CarModelEditDto, CarModel>();
            CreateMap<CarModelCreateDto, CarModel>();

        }
    }
}
