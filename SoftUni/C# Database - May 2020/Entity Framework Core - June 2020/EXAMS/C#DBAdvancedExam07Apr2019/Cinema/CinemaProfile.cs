using AutoMapper;
using Cinema.Data.Models;
using Cinema.DataProcessor.ImportDto;

namespace Cinema
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<ImportMovieDTO, Movie>();
            CreateMap<ImportHallDTO, Hall>()
                .ForMember(x => x.Seats, opt => opt.Ignore());
            CreateMap<ImportProjectionsDTO, Projection>();
            CreateMap<ImportCustomerTicketDTO, Customer>();
            CreateMap<ImportTicketDTO, Ticket>();
        }
    }
}
