namespace Car_Dealership.Interfaces
{
    public interface ISeatTypeService
    {
        Task<ServiceResponse<IEnumerable<SeatTypeGetDto>>> GetSeatTypesAsync();
        Task<ServiceResponse<SeatTypeGetDto?>> GetSeatTypeAsync(int id);
        Task<ServiceResponse<SeatTypeGetDto?>> CreateSeatTypeAsync(SeatTypeCreateDto seatTypeCreateDto);
        Task<ServiceResponse<SeatTypeGetDto?>> UpdateSeatTypeAsync(SeatTypeEditDto seatTypeEditDto);
        Task<ServiceResponse<SeatTypeGetDto?>> DeleteSeatTypeAsync(int id);
    }
}
