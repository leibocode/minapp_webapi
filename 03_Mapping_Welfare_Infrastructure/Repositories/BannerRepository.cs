using _02_Mapping_Welfare_Domain.DomainModels;
using _02_Mapping_Welfare_Domain.Interfaces;
using _03_Mapping_Welfare_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _03_Mapping_Welfare_Infrastructure.Repositories
{
    public class BannerRepository : IBannerRepository
    {

        public readonly WelfareContext _context;

        public BannerRepository(WelfareContext context)
        {
            _context = context;
        }

        public async Task<List<Banner>> GetBanners()
        {
            return await _context.Banners.ToListAsync();
        }
    }
}
