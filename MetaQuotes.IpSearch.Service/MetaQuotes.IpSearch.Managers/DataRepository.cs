using MetaQuotes.IpSearch.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text;

namespace MetaQuotes.IpSearch.Managers;

public interface IDataRepository
{
    Task<IpLocation> GetByIpAsync(uint ipAddress);
    Task<CoordinationItem> GetByCityAsync();
    Task<CoordinationItem> GetCoordinationByIndexAsync(uint index);
}

public class DataRepository : IDataRepository
{
    private readonly ILogger _logger;
    private readonly string _filePath;

    private CoordinationItem[] coordinationItems;
    private IpLocation[] ipLocations;

    private int[] cityNameSortingIndex;

    public DataRepository(string filePath, ILogger<DataRepository> logger)
    {
        _filePath = filePath;
        _logger = logger;
        LoadFromFile();
    }
    private void LoadFromFile()
    {
        var watcher = new Stopwatch();
        watcher.Start();

        using (var fileReader = File.OpenRead(_filePath))
        {
            using (var reader = new BinaryReader(fileReader, Encoding.UTF8, false))
            {
                int version = reader.ReadInt32();         // версия база данных
                byte[] name = reader.ReadBytes(32);       // название/префикс для базы данных
                ulong timestamp = reader.ReadUInt64();         // время создания базы данных
                int records = reader.ReadInt32();           // общее количество записей
                uint offsetRanges = reader.ReadUInt32();     // смещение относительно начала файла до начала списка записей с геоинформацией
                uint offsetCities = reader.ReadUInt32(); ;     // смещение относительно начала файла до начала индекса с сортировкой по названию городов
                uint offsetLocation = reader.ReadUInt32();    // смещение относительно начала файла до начала списка записей о местоположении

                ipLocations = new IpLocation[records];
                coordinationItems = new CoordinationItem[records];

                for (int i = 0; i < records; i++)
                {
                    ipLocations[i] = new IpLocation
                    {
                        IpFrom = reader.ReadUInt32(),
                        IpTo = reader.ReadUInt32(),
                        LocationIndex = reader.ReadUInt32(),
                    };
                }

                for (int i = 0; i < records; i++)
                {
                    coordinationItems[i] = new CoordinationItem
                    {
                        Country = reader.ReadBytes(8).Select(Convert.ToSByte).ToArray(),
                        Region = reader.ReadBytes(12).Select(Convert.ToSByte).ToArray(),
                        Postal = reader.ReadBytes(12).Select(Convert.ToSByte).ToArray(),
                        City = reader.ReadBytes(24).Select(Convert.ToSByte).ToArray(),
                        Organization = reader.ReadBytes(32).Select(Convert.ToSByte).ToArray(),
                        Latitude = reader.ReadSingle(),
                        Longitude = reader.ReadSingle()
                    }; 
                }

                cityNameSortingIndex = new int[records];
                for (int i = 0; i < records; i++)
                {
                    cityNameSortingIndex[i] = reader.ReadInt32();
                }

                
            }
        }

        watcher.Stop();
        _logger.LogInformation($"Total loading time is {watcher.ElapsedMilliseconds.ToString()}");
    }

    public async Task<IpLocation> GetByIpAsync(uint ipAddress)
    {
        // TODO should be binary search
        return ipLocations.FirstOrDefault(s => s.IpFrom <= ipAddress && ipAddress <= s.IpTo);
    }

    public async Task<CoordinationItem> GetByCityAsync()
    {
        return new CoordinationItem();
    }

    public async Task<CoordinationItem> GetCoordinationByIndexAsync(uint index)
    {
        return coordinationItems[index];
    }
}
