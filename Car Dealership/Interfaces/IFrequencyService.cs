namespace Car_Dealership.Interfaces
{
    public interface IFrequencyService
    {
        Task<ServiceResponse<IEnumerable<FrequencyGetDto>>> GetFrequenciesAsync();
        Task<ServiceResponse<FrequencyGetDto?>> GetFrequencyAsync(int  frequencyId);
        Task<ServiceResponse<FrequencyGetDto?>> CreateFrequencyAsync(FrequencyCreateDto frequencyCreateDto);
        Task<ServiceResponse<FrequencyGetDto?>> UpdateFrequencyAsync(FrequencyEditDto frequencyEditDto);
        Task<ServiceResponse<FrequencyGetDto?>> DeleteFrequencyAsync(int frequencyId);
    }
}
