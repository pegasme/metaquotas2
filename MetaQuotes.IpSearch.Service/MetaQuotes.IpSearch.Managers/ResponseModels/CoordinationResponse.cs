using MetaQuotes.IpSearch.Models;

namespace MetaQuotes.IpSearch.Managers.ResponseModels;

public class CoordinationResponse
{
    // Bad way - needs to add strategy
    public CoordinationResponse(CoordinationItem item)
    {
        Country = GetFromSbyte(item.Country);
        Region = GetFromSbyte(item.Region);
        City = GetFromSbyte(item.City);
        Organization = GetFromSbyte(item.Organization);
        Latitude = item.Latitude;
        Longitude = item.Longitude;
    }

    string GetFromSbyte(sbyte[] val)
    {
        var byteArray = Array.ConvertAll(val, (a) => (byte)a);
        return System.Text.Encoding.UTF8.GetString(byteArray);
    }

    /// <summary>
    /// Country name
    /// </summary>
    public string Country { get; set; }

    /// <summary>
    /// Country region - randon string with prefix reg_
    /// </summary>
    public string Region { get; set; }

    /// <summary>
    /// Postal code - randon string with prefix pos_
    /// </summary>
    public string Postal { get; set; }

    /// <summary>
    /// City - randon string with prefix cit_
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Organization - randon string with prefix org_
    /// </summary>
    public string Organization { get; set; }

    /// <summary>
    /// Latitude
    /// </summary>
    public float Latitude { get; set; }

    /// <summary>
    /// Longitude
    /// </summary>
    public float Longitude { get; set; }
}
