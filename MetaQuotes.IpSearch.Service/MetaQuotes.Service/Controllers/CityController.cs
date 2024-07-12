using MetaQuotes.IpSearch.Managers;
using MetaQuotes.IpSearch.Managers.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace MetaQuotes.IpSearch.Service.Controllers;

[Route("[controller]")]
public class CityController : ControllerBase
{
    private readonly ICityManager _cityManager;

    public CityController(ICityManager cityManager)
    {
        _cityManager = cityManager;
    }

    [HttpGet]
    public async Task<IActionResult> Locations(string city)
    {
        if (string.IsNullOrWhiteSpace(city))
            return BadRequest($"{nameof(city)} is empty");

        var result = await _cityManager.GetCoordinationByCity(city);

        if (result.IsFailed)
            return BadRequest();

        return Ok(new CoordinationResponse(result.Value));
    }
}
