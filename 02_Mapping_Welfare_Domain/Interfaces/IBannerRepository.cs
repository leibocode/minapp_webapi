using _02_Mapping_Welfare_Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _02_Mapping_Welfare_Domain.Interfaces
{
    public interface IBannerRepository
    {
        Task<List<Banner>> GetBanners();
    }
}
