using _02_Mapping_Welfare_Domain.DomainModels;
using _02_Mapping_Welfare_Domain.DtoParamters;
using _02_Mapping_Welfare_Domain.Interfaces;
using _03_Mapping_Welfare_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Mapping_Welfare_Infrastructure.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly WelfareContext _context;

        public OrganizationRepository(WelfareContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 获取热门活动
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Activity>> GetActivities()
        {
            var query = await _context.Activities.OrderBy(x=>x.Created).Take(2).ToListAsync();
            return query;
        }

      

        /// <summary>
        /// 获取我的组织
        /// </summary>
        /// <param name="paramters"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        public Task<IEnumerable<Organization>> GetMyOrganization(OrganizationDtoParamters paramters, string openid)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取组织列表
        /// </summary>
        /// <param name="paramters"></param>
        /// <returns></returns>
        public Task<IEnumerable<Organization>> GetOrganizations(OrganizationDtoParamters paramters)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 加入组织
        /// </summary>
        /// <returns></returns>
        public Task<bool> Join()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        public Task<bool> SignOut()
        {
            throw new NotImplementedException();
        }
    }
}
