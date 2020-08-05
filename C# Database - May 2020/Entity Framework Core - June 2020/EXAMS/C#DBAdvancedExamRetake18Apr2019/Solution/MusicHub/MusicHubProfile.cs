using MusicHub.Data.Models;
using MusicHub.DataProcessor.ImportDtos;

namespace MusicHub
{
    using AutoMapper;

    public class MusicHubProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public MusicHubProfile()
        {
            this.CreateMap<ImportProducerDto, Producer>();
            this.CreateMap<ImportAlbumDto, Album>();

            this.CreateMap<ImportSongPerformers, Performer>();
            this.CreateMap<ImportPerformerSongDto, SongPerformer>()
                .ForMember(t => t.SongId, 
                    y => y.MapFrom(k => k.Id));
        }
    }
}
