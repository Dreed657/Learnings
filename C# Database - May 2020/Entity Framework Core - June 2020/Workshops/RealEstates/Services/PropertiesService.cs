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
        private RealEstateDbContext db;

        public PropertiesService(RealEstateDbContext db)
        {
            this.db = db;
        }

        public void Create(string district, int size, int? year, int price, string propertyType, string buildingType, int? floor, int? maxFloors)
        {
            if (district == null)
            {
                throw new ArgumentException("District was null");
            }

            var property = new RealEstateProperty()
            {
                Size = size,
                Price = price,
                Year = year < 1800 ? null : year,
                Floor = floor <= 0 ? null : floor,
                TotalNumberOfFloors = maxFloors <= 0 ? null : maxFloors,
            };

            var districtEntity = this.db.Districts.FirstOrDefault(x => x.Name.Trim() == district.Trim()) ?? 
                                    new District { Name = district };

            property.District = districtEntity;

            var propertyTypeEntity = this.db.PropertyTypes.FirstOrDefault(x => x.Name.Trim() == propertyType.Trim()) ?? 
                                     new PropertyType {Name = propertyType};

            property.PropertyType = propertyTypeEntity;

            var buildingTypeEntity = this.db.BuildingTypes.FirstOrDefault(x => x.Name.Trim() == buildingType.Trim()) ??
                                     new BuildingType {Name = buildingType};

            property.BuildingType = buildingTypeEntity;

            this.db.RealEstateProperties.Add(property);
            this.db.SaveChanges();

            this.UpdateTags(property.Id);
        }

        public void UpdateTags(int propertyId)
        {
            var property = this.db.RealEstateProperties.FirstOrDefault(x => x.Id == propertyId);
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

            this.db.SaveChanges();
        }

        private Tag GetOrCreateTag(string tagName)
        {
            return this.db.Tags.FirstOrDefault(x => x.Name.Trim() == tagName.Trim()) ?? new Tag { Name = tagName }; 
        }

        public IEnumerable<PropertyViewModel> Search(int minYear, int maxYear, int minSize, int maxSize)
        {
            return this.db.RealEstateProperties
                .Where(x => x.Year >= minYear && x.Year <= maxYear && x.Size >= minSize && x.Size <= maxSize)
                .Select(MapToPropertyViewModel())
                .OrderBy(x => x.Size)
                .ToList();
        }

        public IEnumerable<PropertyViewModel> SearchByPrice(int minPrice, int maxPrice)
        {
            return this.db.RealEstateProperties
                .Where(x => x.Price >= minPrice && x.Price <= maxPrice)
                .Select(MapToPropertyViewModel())
                .OrderBy(x => x.Price)
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
            };
        }
    }
}
