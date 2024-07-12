using MetaQuotes.IpSearch.Managers;
using MetaQuotes.IpSearch.Managers.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace MetaQuotes.IpSearch.Service.Controllers;

[Route("[controller]")]
public class IpController : ControllerBase
{
    private readonly IIpManager _ipManager;

    public IpController(IIpManager ipManager)
    {
        _ipManager = ipManager;
    }

    [HttpGet]
    public async Task<IActionResult> Location(string ip)
    {
        if (string.IsNullOrWhiteSpace(ip))
            return BadRequest($"{nameof(ip)} is empty");

        var result = await _ipManager.GetCoordinatesByIp(ip);

        if (result.IsFailed)
            return BadRequest();

        return Ok(new CoordinationResponse(result.Value));
    }
}
