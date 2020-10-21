using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Contracts;
using Services.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services
{
    public class PropertiesService : IPropertiesService
    {
        private readonly RealEstateDbContext _context;

        public PropertiesService(RealEstateDbContext db)
        {
            this._context = db;
        }

        public async Task SingleInsert(PropertyCreateDto model)
        {
            var property = this.Create(model);
            await this._context.RealEstateProperties.AddAsync(property);
        }

        public async Task BulkInsert(PropertyCreateDto[] models)
        {
            var convertedProperties = new List<RealEstateProperty>();

            var count = 0;

            foreach (var dto in models)
            {
                var timer = new Stopwatch();

                timer.Start();
                count++;

                var property = this.Create(dto);
                convertedProperties.Add(property);
                
                timer.Stop();

                Console.WriteLine(this.PropertyToString(property, timer.ElapsedTicks));
                
                if (count % 50 == 0) Console.WriteLine(count + "...");
            }

            await this._context.RealEstateProperties.AddRangeAsync(convertedProperties);
            await this._context.SaveChangesAsync();
        }

        public async Task<PropertyViewModel> CreateOne(PropertyCreateDto model)
        {
            var property = this.Create(model);

            await this._context.RealEstateProperties.AddAsync(property);
            await this._context.SaveChangesAsync();

            return this.SingleMapToPropertyViewModel(property);
        }

        private RealEstateProperty Create(PropertyCreateDto model)
        {
            if (model.District == null) throw new ArgumentException("District was null");

            var property = new RealEstateProperty()
            {
                Size = model.Size,
                Price = model.Price,
                Year = model.Year < 1800 ? null : model.Year,
                Floor = model.Floor <= 0 ? null : model.Floor,
                TotalNumberOfFloors = model.MaxFloors <= 0 ? null : model.MaxFloors,
                Url = model.Url
            };

            var districtEntity = this._context.Districts.FirstOrDefault(x => x.Name.Trim() == model.District.Trim()) ??
                                    new District { Name = model.District };

            property.District = districtEntity;

            var propertyTypeEntity = this._context.PropertyTypes.FirstOrDefault(x => x.Name.Trim() == model.PropertyType.Trim()) ??
                                     new PropertyType { Name = model.PropertyType };

            property.PropertyType = propertyTypeEntity;

            var buildingTypeEntity = this._context.BuildingTypes.FirstOrDefault(x => x.Name.Trim() == model.BuildingType.Trim()) ??
                                     new BuildingType { Name = model.BuildingType };

            property.BuildingType = buildingTypeEntity;

            return property;
        }

        public bool Delete(int id)
        {
            var property = this._context.RealEstateProperties.FirstOrDefault(x => x.Id == id);

            if (property == null) return false;

            this._context.RealEstateProperties.Remove(property);
            return true;
        }

        public bool Update(int id)
        {
            throw new NotImplementedException();
        }

        public async void BulkUpdateTags()
        {
            var propertiesToUpdate = this._context.RealEstateProperties.ToList();

            foreach (var property in propertiesToUpdate)
            {
                await this.UpdateTags(property);
            }
        }

        public async Task UpdateTags(RealEstateProperty property)
        {
            property.Tags.Clear();

            if (property.Year.HasValue && property.Year < 1990)
            {
                property.Tags.Add(new RealEstatePropertyTag { Tag = this.GetOrCreateTag("OldBuilding") });
            }

            if (property.Size > 120)
            {
                property.Tags.Add(new RealEstatePropertyTag { Tag = this.GetOrCreateTag("HugeApartment") });
            }

            if (property.Year > 2018)
            {
                property.Tags.Add(new RealEstatePropertyTag { Tag = this.GetOrCreateTag("NewApartment") });
            }

            if (property.Year > 2018 && property.TotalNumberOfFloors > 5)
            {
                property.Tags.Add(new RealEstatePropertyTag { Tag = this.GetOrCreateTag("HasParking") });
            }

            if (property.Floor == property.TotalNumberOfFloors)
            {
                property.Tags.Add(new RealEstatePropertyTag { Tag = this.GetOrCreateTag("LastFloor") });
            }

            if ((double)property.Price / property.Size < 800)
            {
                property.Tags.Add(new RealEstatePropertyTag { Tag = this.GetOrCreateTag("CheapApartment") });
            }

            if ((double)property.Price / property.Size > 2000)
            {
                property.Tags.Add(new RealEstatePropertyTag { Tag = this.GetOrCreateTag("ExpensiveApartment") });
            }

            this._context.SaveChangesAsync();
        }

        private Tag GetOrCreateTag(string tagName)
        {
            return this._context.Tags.FirstOrDefault(x => x.Name.Trim() == tagName.Trim()) ?? new Tag { Name = tagName };
        }

        public async Task<IEnumerable<PropertyViewModel>> GetAll(int count = 10)
        {
            return await this._context.RealEstateProperties
                .Select(MapToPropertyViewModel())
                .Take(count)
                .ToListAsync();
        }

        public async Task<IEnumerable<PropertyViewModel>> Search(int minYear, int maxYear, int minSize, int maxSize)
        {
            return await this._context.RealEstateProperties
                .Where(x => x.Year >= minYear && x.Year <= maxYear && x.Size >= minSize && x.Size <= maxSize)
                .Select(MapToPropertyViewModel())
                .OrderBy(x => x.Size)
                .ToListAsync();
        }

        public async Task<IEnumerable<PropertyViewModel>> SearchByPrice(int minPrice, int maxPrice)
        {
            return await this._context.RealEstateProperties
                .Where(x => x.Price >= minPrice && x.Price <= maxPrice)
                .Select(MapToPropertyViewModel())
                .OrderBy(x => x.District)
                .ThenByDescending(x => x.Price)
                .ToListAsync();
        }

        public int Count()
        {
            return this._context.RealEstateProperties.Count();
        }

        private static Expression<Func<RealEstateProperty, PropertyViewModel>> MapToPropertyViewModel()
        {
            return x => new PropertyViewModel
            {
                Price = x.Price,
                Floor = (x.Floor ?? 0).ToString() + "/" + (x.TotalNumberOfFloors ?? 0).ToString(),
                Size = x.Size,
                Year = x.Year,
                BuildingType = x.BuildingType.Name,
                PropertyType = x.PropertyType.Name,
                District = x.District.Name,
                Url = x.Url
            };
        }

        private PropertyViewModel SingleMapToPropertyViewModel(RealEstateProperty x)
        {
            return new PropertyViewModel
            {
                Price = x.Price,
                Floor = (x.Floor ?? 0).ToString() + "/" + (x.TotalNumberOfFloors ?? 0).ToString(),
                Size = x.Size,
                Year = x.Year,
                BuildingType = x.BuildingType.Name,
                PropertyType = x.PropertyType.Name,
                District = x.District.Name,
                Url = x.Url
            };
        }

        private string PropertyToString(RealEstateProperty property, long TimeSpan)
        {
            return $"District: {property.District.Name} ({property.Floor}/{property.TotalNumberOfFloors})," +
                   $" {property.Year}, {property.Size}m2, Price: {property.Price} ({TimeSpan} ticks)";
        }
    }
}
