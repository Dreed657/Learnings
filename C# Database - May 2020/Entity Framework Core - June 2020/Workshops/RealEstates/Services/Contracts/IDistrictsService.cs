using Services.DataTransferObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IDistrictsService
    {
        Task<IEnumerable<DistrictViewModel>> GetTopDistrictsByAveragePrice(int count = 10);

        Task<IEnumerable<DistrictViewModel>> GetTopDistrictsByByNumberOfProperties(int count = 10);
    }
}
