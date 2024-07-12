namespace MetaQuotes.IpSearch.Models;

public class DbInfo
{
    /// <summary>
    /// Db version
    /// </summary>
    public int Version { get; set; }

    /// <summary>
    /// Dartabase Prefix sbyte[32] 
    /// </summary>
    public sbyte Name { get; set; }

    /// <summary>
    /// Creation timestamp
    /// </summary>
    public ulong TimeStamp { get; set; }

    /// <summary>
    /// All records count
    /// </summary>
    public int Records { get; set; }

    /// <summary>
    /// смещение относительно начала файла до начала списка записей с геоинформацией
    /// </summary>
    public uint OffsetRanges { get; set; }

    /// <summary>
    /// смещение относительно начала файла до начала индекса с сортировкой по названию городов
    /// </summary>
    public uint OffsetCities { get; set; }

    /// <summary>
    /// смещение относительно начала файла до начала списка записей о местоположении
    /// </summary>
    public uint OffsetLocations { get; set; }
}
