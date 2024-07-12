using FluentResults;
using MetaQuotes.IpSearch.Models;
using System.Net;

namespace MetaQuotes.IpSearch.Managers;

public interface IIpManager
{
    public ValueTask<Result<CoordinationItem>> GetCoordinatesByIp(string ip);
}

public class IpManager : IIpManager
{
    private readonly IDataRepository _repository;

    public IpManager(IDataRepository repository)
    {
        _repository = repository;
    }

    public async ValueTask<Result<CoordinationItem>> GetCoordinatesByIp(string ip)
    {
        var ipuint32 = BitConverter.ToUInt32(IPAddress.Parse(ip).GetAddressBytes(), 0);

        var ipLocation = await _repository.GetByIpAsync(ipuint32);

        if (ipLocation is null)
        {
            return Result.Fail("Coordinates by this ip not found");
        }

        var coordination = await _repository.GetCoordinationByIndexAsync(ipLocation.LocationIndex);

        return Result.Ok(coordination);
    }
}
