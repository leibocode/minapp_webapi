using _02_Mapping_Welfare_Domain.DomainModels;
using _03_Mapping_Welfare_Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Mapping_Welfare_Infrastructure
{
    /// <summary>
    /// 初始化数据
    /// </summary>
    public class Seed
    {
        public static async Task SeedAsync(
            WelfareContext context,ILoggerFactory logger, int retry =0)
        {
            int retryForAvilability = retry;

            try
            {
                if (!context.Banners.Any())
                {
                    context.Banners.AddRange(new List<Banner>()
                    {
                        new Banner()
                        { 
                          Id = Guid.NewGuid(),
                          Url = ""
                        }
                    });

                   await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
