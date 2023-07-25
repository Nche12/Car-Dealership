

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

            CreateMap<TransmissionType, TransmissionTypeGetDto>();
            CreateMap<TransmissionTypeEditDto, TransmissionType>();
            CreateMap<TransmissionTypeCreateDto, TransmissionType>();

            CreateMap<FuelType, FuelTypeGetDto>();
            CreateMap<FuelTypeCreateDto, FuelType>();
            CreateMap<FuelTypeEditDto, FuelType>();

            CreateMap<SeatType, SeatTypeGetDto>();
            CreateMap<SeatTypeCreateDto, SeatType>();
            CreateMap<SeatTypeEditDto, SeatType>();

            CreateMap<CarType, CarTypeGetDto>();
            CreateMap<CarTypeCreateDto, CarType>();
            CreateMap<CarTypeEditDto, CarType>();

            CreateMap<CarDriveType, CarDriveTypeGetDto>();
            CreateMap<CarDriveTypeCreateDto, CarDriveType>();
            CreateMap<CarDriveTypeEditDto, CarDriveType>();

            CreateMap<CarColour, CarColourGetDto>();
            CreateMap<CarColourCreateDto, CarColour>();
            CreateMap<CarColourEditDto, CarColour>();

            CreateMap<Client, ClientGetDto>();
            CreateMap<ClientCreateDto, Client>();
            CreateMap<ClientEditDto, Client>();

            CreateMap<Car, CarGetDto>()
                .ForMember(dest => dest.CarMakeName, opt => opt.MapFrom(src => src.CarMake == null ? null : src.CarMake.Name));
            CreateMap<CarCreateDto, Car>();
            CreateMap<CarEditDto, Car>();
        }
    }
}
