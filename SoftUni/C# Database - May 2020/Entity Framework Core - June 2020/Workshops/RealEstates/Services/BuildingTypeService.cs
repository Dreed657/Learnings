using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Contracts;

namespace Services
{
    public class BuildingTypeService : IBuildingTypeService
    {
        private readonly RealEstateDbContext _context;

        public BuildingTypeService(RealEstateDbContext db)
        {
            this._context = db;
        }

        public async Task<IEnumerable<BuildingType>> GetAll(int count)
        {
            return await this._context.BuildingTypes
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllNames()
        {
            return await this._context.BuildingTypes
                .Select(x => x.Name)
                .ToListAsync();
        }
    }
}
