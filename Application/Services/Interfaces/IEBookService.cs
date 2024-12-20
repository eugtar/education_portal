using Application.Dtos.EbookDtos;
using Application.Results;

namespace Application.Services.Interfaces;

public interface IEbookService
{
    public Task<Result> CreateAsync(CreateEbookDto dto);
    public Task<Result> UpdateAsync(int id, UpdateEbookDto dto);
    public Task<Result> DeleteAsync(int id);
    public Task<Result<EbookDto>> GetByIdAsync(int id);
    public Task<Result<List<EbookDto>>> GetAllAsync();
}
