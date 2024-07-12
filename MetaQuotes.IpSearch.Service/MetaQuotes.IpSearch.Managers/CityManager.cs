using FluentResults;
using MetaQuotes.IpSearch.Models;

namespace MetaQuotes.IpSearch.Managers;

public interface ICityManager
{
    public ValueTask<Result<CoordinationItem>> GetCoordinationByCity(string city);  
}

public class CityManager : ICityManager
{
    private readonly IDataRepository _repository;

    public CityManager(IDataRepository repository)
    {
        _repository = repository;
    }

    public ValueTask<Result<CoordinationItem>> GetCoordinationByCity(string city)
    {
        throw new NotImplementedException();
    }
}
