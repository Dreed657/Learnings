using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services.Contracts
{
    public interface IBuildingTypeService
    {
        public Task<IEnumerable<BuildingType>> GetAll(int count);

        public Task<IEnumerable<string>> GetAllNames();
    }
}
