using System.Collections;
using System.Collections.Generic;
using Services.DataTransferObject;

namespace Services.Contracts
{
    public interface IDistrictsService
    {
        IEnumerable<DistrictViewModel> GetTopDistrictsByAveragePrice(int count = 10);

        IEnumerable<DistrictViewModel> GetTopDistrictsByByNumberOfProperties(int count = 10);
    }
}
