using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Contracts;
using Services.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services
{
    public class DistrictsService : IDistrictsService
    {
        private RealEstateDbContext db;

        public DistrictsService(RealEstateDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<District>> GetAll(int count)
        {
            return await this.db.Districts
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllNames()
        {
            return await this.db.Districts
                .Select(x => x.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<DistrictViewModel>> GetTopDistrictsByAveragePrice(int count = 10)
        {
            return await this.db.Districts
                .OrderByDescending(x => x.Properties.Average(x => x.Price))
                .Select(MapToDistrictViewModel())
                .Take(count)
                .ToListAsync();
        }

        public async Task<IEnumerable<DistrictViewModel>> GetTopDistrictsByByNumberOfProperties(int count = 10)
        {
            return await this.db.Districts
                .OrderByDescending(x => x.Properties.Count)
                .Select(MapToDistrictViewModel())
                .Take(count)
                .ToListAsync();
        }

        private static Expression<Func<District, DistrictViewModel>> MapToDistrictViewModel()
        {
            return x => new DistrictViewModel
            {
                AveragePrice = x.Properties.Average(x => x.Price),
                MinPrice = x.Properties.Min(x => x.Price),
                MaxPrice = x.Properties.Max(x => x.Price),
                Name = x.Name,
                PropertiesCount = x.Properties.Count,
            };
        }

    }
}
