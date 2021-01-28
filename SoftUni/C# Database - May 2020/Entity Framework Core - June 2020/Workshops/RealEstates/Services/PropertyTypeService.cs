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
    public class PropertyTypeService : IPropertyTypeService
    {
        private readonly RealEstateDbContext _context;

        public PropertyTypeService(RealEstateDbContext db)
        {
            this._context = db;
        }

        public async Task<IEnumerable<PropertyType>> GetAll(int count)
        {
            return await this._context.PropertyTypes
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllNames()
        {
            return await this._context.PropertyTypes
                .Select(x => x.Name)
                .ToListAsync();
        }
    }
}
