namespace MetaQuotes.IpSearch.Models;

public class CoordinationItem
{
    /// <summary>
    /// Country name
    /// </summary>
    public sbyte[] Country { get; set; }

    /// <summary>
    /// Country region - randon string with prefix reg_
    /// </summary>
    public sbyte[] Region { get; set; }

    /// <summary>
    /// Postal code - randon string with prefix pos_
    /// </summary>
    public sbyte[] Postal { get; set; }

    /// <summary>
    /// City - randon string with prefix cit_
    /// </summary>
    public sbyte[] City { get; set; }

    /// <summary>
    /// Organization - randon string with prefix org_
    /// </summary>
    public sbyte[] Organization { get; set; }

    /// <summary>
    /// Latitude
    /// </summary>
    public float Latitude { get; set; }

    /// <summary>
    /// Longitude
    /// </summary>
    public float Longitude { get; set; }
}
