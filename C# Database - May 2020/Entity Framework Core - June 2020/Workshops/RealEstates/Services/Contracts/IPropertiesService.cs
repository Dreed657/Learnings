using System.Collections;
using System.Collections.Generic;
using Models;
using Services.DataTransferObject;

namespace Services.Contracts
{
    public interface IPropertiesService
    {
        PropertyCreateDto Create(PropertyCreateDto models);

        bool Delete(int Id);

        bool Update(int Id);

        void UpdateTags(int propertyId);

        public IEnumerable<PropertyViewModel> GetAll(int count);

        IEnumerable<PropertyViewModel> Search(int minYear, int maxYear, int minSize, int maxSize);

        IEnumerable<PropertyViewModel> SearchByPrice(int minPrice, int maxPrice);
    }
}
