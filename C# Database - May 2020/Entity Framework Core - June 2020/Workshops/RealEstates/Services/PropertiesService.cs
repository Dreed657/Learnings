using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Data;
using Models;
using Services.Contracts;
using Services.DataTransferObject;

namespace Services
{
    public class PropertiesService : IPropertiesService
    {
        private readonly RealEstateDbContext _context;

        public PropertiesService(RealEstateDbContext db)
        {
            this._context = db;
        }

        public PropertyCreateDto Create(PropertyCreateDto model)
        {
            if (model.District == null)
            {
                throw new ArgumentException("District was null");
            }

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
                                     new PropertyType {Name = model.PropertyType};

            property.PropertyType = propertyTypeEntity;

            var buildingTypeEntity = this._context.BuildingTypes.FirstOrDefault(x => x.Name.Trim() == model.BuildingType.Trim()) ??
                                     new BuildingType {Name = model.BuildingType};

            property.BuildingType = buildingTypeEntity;

            this._context.RealEstateProperties.Add(property);
            this._context.SaveChanges();

            this.UpdateTags(property.Id);

            return model;
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

        public void UpdateTags(int propertyId)
        {
            var property = this._context.RealEstateProperties.FirstOrDefault(x => x.Id == propertyId);
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

            this._context.SaveChanges();
        }

        private Tag GetOrCreateTag(string tagName)
        {
            return this._context.Tags.FirstOrDefault(x => x.Name.Trim() == tagName.Trim()) ?? new Tag { Name = tagName }; 
        }

        public IEnumerable<PropertyViewModel> GetAll(int count = 10)
        {
            return this._context.RealEstateProperties
                .Select(MapToPropertyViewModel())
                .Take(count)
                .ToList();
        }

        public IEnumerable<PropertyViewModel> Search(int minYear, int maxYear, int minSize, int maxSize)
        {
            return this._context.RealEstateProperties
                .Where(x => x.Year >= minYear && x.Year <= maxYear && x.Size >= minSize && x.Size <= maxSize)
                .Select(MapToPropertyViewModel())
                .OrderBy(x => x.Size)
                .ToList();
        }

        public IEnumerable<PropertyViewModel> SearchByPrice(int minPrice, int maxPrice)
        {
            return this._context.RealEstateProperties
                .Where(x => x.Price >= minPrice && x.Price <= maxPrice)
                .Select(MapToPropertyViewModel())
                .OrderBy(x => x.District)
                .ThenByDescending(x => x.Price)
                .ToList();
        }

        private Expression<Func<RealEstateProperty, PropertyViewModel>> MapToPropertyViewModel()
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
    }
}
