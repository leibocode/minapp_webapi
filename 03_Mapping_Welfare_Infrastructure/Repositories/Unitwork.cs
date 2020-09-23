using _02_Mapping_Welfare_Domain.Interfaces;
using _03_Mapping_Welfare_Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _03_Mapping_Welfare_Infrastructure.Repositories
{
    public class Unitwork:IUnitwork
    {
        public readonly WelfareContext _context;

        public Unitwork(WelfareContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
