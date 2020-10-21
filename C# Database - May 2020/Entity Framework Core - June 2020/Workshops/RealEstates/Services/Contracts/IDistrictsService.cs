using Services.DataTransferObject;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Services.Contracts
{
    public interface IDistrictsService
    {
        public Task<IEnumerable<District>> GetAll(int count);

        public Task<IEnumerable<string>> GetAllNames();

        Task<IEnumerable<DistrictViewModel>> GetTopDistrictsByAveragePrice(int count = 10);

        Task<IEnumerable<DistrictViewModel>> GetTopDistrictsByByNumberOfProperties(int count = 10);
    }
}
