using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;
using MusicHub.Data.Models;
using MusicHub.DataProcessor.ImportDtos;
using Newtonsoft.Json;

namespace MusicHub.DataProcessor
{
    using System;

    using Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter 
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone 
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong 
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var writersResult = JsonConvert.DeserializeObject<ImportWriterDto[]>(jsonString);

            var writers = new List<Writer>();

            foreach (var writerDto in writersResult)
            {
                if (!IsValid(writerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var writer = new Writer
                {
                    Name = writerDto.Name,
                    Pseudonym = writerDto.Pseudonym
                };

                writers.Add(writer);

                sb.AppendLine(string.Format(SuccessfullyImportedWriter, writer.Name));
            }

            context.AddRange(writers);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producerDtos = JsonConvert.DeserializeObject<ImportProducerDto[]>(jsonString);

            var sb = new StringBuilder();
            var validProducers = new List<Producer>();

            foreach (var producerDto in producerDtos)
            {
                if (!IsValid(producerDto) || !producerDto.Albums.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //var producer = AutoMapper.Mapper.Map<Producer>(producerDto);

                var producer = new Producer
                {
                    Name = producerDto.Name,
                    PhoneNumber = producerDto.PhoneNumber,
                    Pseudonym = producerDto.Pseudonym
                };

                foreach (var albumDto in producerDto.Albums)
                {
                    producer.Albums.Add(new Album
                    {
                        Name = albumDto.Name,
                        ReleaseDate = DateTime.ParseExact(albumDto.ReleaseDate, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture)
                    });
                }

                validProducers.Add(producer);

                sb.AppendLine(producer.PhoneNumber == null
                    ? string.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count)
                    : string.Format(SuccessfullyImportedProducerWithPhone, producer.Name, producer.PhoneNumber, producer.Albums.Count));

                validProducers.Add(producer);
            }

            context.Producers.AddRange(validProducers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var songResults = DeserializeObject<ImportSongsDto>("Songs", xmlString);
            var songs = new List<Song>();

            foreach (var songDto in songResults)
            {
                if (!IsValid(songDto) || !IsAlbumExists(context, songDto.AlbumId) || !IsWriterExists(context, songDto.WriterId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                try
                {
                    var song = new Song
                    {
                        Name = songDto.Name,
                        Duration = TimeSpan.ParseExact(songDto.Duration, "c", CultureInfo.InvariantCulture),
                        CreatedOn = DateTime.ParseExact(songDto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None),
                        Genre = Enum.Parse<Genre>(songDto.Genre),
                        AlbumId = songDto.AlbumId,
                        WriterId = songDto.WriterId,
                        Price = songDto.Price
                    };

                    songs.Add(song);
                    sb.AppendLine(string.Format(SuccessfullyImportedSong, song.Name, song.Genre, song.Duration));
                }
                catch (Exception)
                {
                    sb.AppendLine(ErrorMessage);
                }
            }
                
            context.AddRange(songs);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsAlbumExists(MusicHubDbContext context, int albumId)
        {
            return context.Albums.Any(x => x.Id == albumId);
        }

        private static bool IsWriterExists(MusicHubDbContext context, int writerId)
        {
            return context.Writers.Any(x => x.Id == writerId);
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var performersResult = DeserializeObject<ImportSongPerformers>("Performers", xmlString);
            var validPerformers = new List<Performer>();

            foreach (var performerDto in performersResult)
            {
                if (!IsValid(performerDto) || !performerDto.PerformerSongs.All(x => IsSongExists(context, x.Id)))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var performer = AutoMapper.Mapper.Map<Performer>(performerDto);
                validPerformers.Add(performer);

                sb.AppendLine(string.Format(SuccessfullyImportedPerformer, performer.FirstName, performer.PerformerSongs.Count));
            }

            context.Performers.AddRange(validPerformers);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsSongExists(MusicHubDbContext context, int songId)
        {
            return context.Songs.Any(x => x.Id == songId);
        }

        private static T[] DeserializeObject<T>(string rootElement, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(T[]), new XmlRootAttribute(rootElement));
            var deserializedDtos = (T[])xmlSerializer.Deserialize(new StringReader(xmlString));
            return deserializedDtos;
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(entity, validationContext, validationResult, true);
        }
    }
}