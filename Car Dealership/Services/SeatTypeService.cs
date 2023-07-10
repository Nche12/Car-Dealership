namespace Car_Dealership.Services
{
    public class SeatTypeService : ISeatTypeService
    {
        private readonly TenantContext _tenantContext;
        private readonly IMapper _mapper;
        public SeatTypeService(TenantContext tenantContext, IMapper mapper)
        {
            _tenantContext = tenantContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<SeatTypeGetDto?>> CreateSeatTypeAsync(SeatTypeCreateDto seatTypeCreateDto)
        {
            var serviceRespnse = new ServiceResponse<SeatTypeGetDto?>();
            var seatType = _mapper.Map<SeatType>(seatTypeCreateDto);
            _tenantContext.SeatTypes.Add(seatType);
            try
            {
                await _tenantContext.SaveChangesAsync();
                serviceRespnse.Data = _mapper.Map<SeatTypeGetDto>(seatType);
                serviceRespnse.StatusCode = StatusCodes.Status201Created;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Equals($"Cannot insert duplicate key row in object 'dbo.SeatTypes' with unique index 'IX_SeatTypes_Name'. The duplicate key value is ({seatType.Name})."))
                {
                    serviceRespnse.Data = null;
                    serviceRespnse.Success = false;
                    serviceRespnse.StatusCode = StatusCodes.Status409Conflict;
                    serviceRespnse.Message = $"Seat Type '{seatType.Name}' already exists";
                }
                else
                {
                    throw;
                }
            }
            return serviceRespnse;
        }

        public async Task<ServiceResponse<SeatTypeGetDto?>> DeleteSeatTypeAsync(int id)
        {
            var serviceRespnse = new ServiceResponse<SeatTypeGetDto?>();
            var seatType = await _tenantContext.SeatTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (seatType == null)
            {
                serviceRespnse.Data = null;
                serviceRespnse.Success = false;
                serviceRespnse.StatusCode = StatusCodes.Status404NotFound;
                serviceRespnse.Message = "Seat Type not Found";
            } 
            else
            {
                _tenantContext.SeatTypes.Remove(seatType);
                await _tenantContext.SaveChangesAsync();
                serviceRespnse.Data = _mapper.Map<SeatTypeGetDto>(seatType);
                serviceRespnse.StatusCode = StatusCodes.Status204NoContent;
            }
            return serviceRespnse;
        }

        public async Task<ServiceResponse<SeatTypeGetDto?>> GetSeatTypeAsync(int id)
        {
            var serviceRespnse = new ServiceResponse<SeatTypeGetDto?>();
            var seatType = await _tenantContext.SeatTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (seatType == null)
            {
                serviceRespnse.Data = null;
                serviceRespnse.Success = false;
                serviceRespnse.StatusCode = StatusCodes.Status404NotFound;
                serviceRespnse.Message = "Seat Type not Found";
            }
            else
            {
                serviceRespnse.Data = _mapper.Map<SeatTypeGetDto>(seatType);
                serviceRespnse.StatusCode = StatusCodes.Status200OK;
            }
            return serviceRespnse;

        }

        public async Task<ServiceResponse<IEnumerable<SeatTypeGetDto>>> GetSeatTypesAsync()
        {
            var serviceRespnse = new ServiceResponse<IEnumerable<SeatTypeGetDto>>();
            var seatTypes = await _tenantContext.SeatTypes.ToArrayAsync();
            serviceRespnse.Data = seatTypes.Select(s => _mapper.Map<SeatTypeGetDto>(s));
            serviceRespnse.StatusCode = StatusCodes.Status200OK;
            return serviceRespnse;
        }

        public async Task<ServiceResponse<SeatTypeGetDto?>> UpdateSeatTypeAsync(SeatTypeEditDto seatTypeEditDto)
        {
            var serviceRespnse = new ServiceResponse<SeatTypeGetDto?>();
            var seatType = _mapper.Map<SeatType>(seatTypeEditDto);
            _tenantContext.Entry(seatType).State = EntityState.Modified;
            try
            {
                await _tenantContext.SaveChangesAsync();
                serviceRespnse.Data = _mapper.Map<SeatTypeGetDto>(seatType);
                serviceRespnse.StatusCode = StatusCodes.Status204NoContent;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeatTypeExists(seatType.Id))
                {
                    serviceRespnse.Data = null;
                    serviceRespnse.Success = false;
                    serviceRespnse.StatusCode = StatusCodes.Status404NotFound;
                    serviceRespnse.Message = "Seat Type not Found";
                }
            }

            return serviceRespnse;
        }

        public bool SeatTypeExists(int id)
        {
            return _tenantContext.SeatTypes.Any(t => t.Id == id);
        }
    }
}
