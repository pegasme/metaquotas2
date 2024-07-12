namespace MetaQuotes.IpSearch.Models;

public class IpLocation
{
    /// <summary>
    /// начало диапазона IP адресов
    /// </summary>
    public uint IpFrom { get; set; }

    /// <summary>
    /// конец диапазона IP адресов
    /// </summary>
    public uint IpTo { get; set; }

    /// <summary>
    /// индекс записи о местоположении
    /// </summary>
    public uint LocationIndex { get; set; }
}
