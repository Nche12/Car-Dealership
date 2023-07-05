namespace Car_Dealership
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<User, UserGetDto>();
            CreateMap<UserEditDto, User>();
            CreateMap<UserCreateDto, User>();
        }
    }
}
