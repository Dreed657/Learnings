using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using AutoMapper.QueryableExtensions;
using MusicHub.DataProcessor.ExportDtos;
using Newtonsoft.Json;

namespace MusicHub.DataProcessor
{
    using System;

    using Data;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .ToList()
                .Where(x => x.ProducerId == producerId)
                .Select(x => new
                {
                    AlbumName = x.Name,
                    ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = x.Producer.Name,
                    Songs = x.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        Price = s.Price.ToString("0.00"),
                        Writer = s.Writer.Name
                    })
                    .OrderByDescending(s => s.SongName)
                    .ThenBy(s => s.Writer)
                    .ToList(),
                    AlbumPrice = x.Songs.Sum(s => s.Price).ToString("F2")
                })
                .OrderByDescending(x => x.AlbumPrice)
                .ToList();

            return JsonConvert.SerializeObject(albums, Formatting.Indented);
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .ToArray()
                .Where(x => x.Duration > TimeSpan.FromSeconds(duration))
                .Select(x => new ExportSongDto
                {
                    SongName = x.Name,
                    WriterName = x.Writer.Name,
                    Performer = x.SongPerformers.Select(s => s.Performer.FirstName + " " + s.Performer.LastName).FirstOrDefault(),
                    AlbumProducer = x.Album.Producer.Name,
                    Duration = x.Duration.ToString("c")
                })
                .OrderBy(x => x.SongName)
                .ThenBy(x => x.WriterName)
                .ThenBy(x => x.Performer)
                .ToArray();

            return Serialize(songs, "Songs");
        }

        public static string Serialize<T>(
            T[] dataTransferObjects,
            string xmlRootAttributeName)
        {
            var serializer = new XmlSerializer(typeof(T[]), new XmlRootAttribute(xmlRootAttributeName));
            var builder = new StringBuilder();

            var xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            var writer = new StringWriter(builder);
            serializer.Serialize(writer, dataTransferObjects, xmlNamespaces);

            return builder.ToString();
        }
    }
}