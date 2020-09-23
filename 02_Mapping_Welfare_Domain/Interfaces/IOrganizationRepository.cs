using _02_Mapping_Welfare_Domain.DomainModels;
using _02_Mapping_Welfare_Domain.DtoParamters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _02_Mapping_Welfare_Domain.Interfaces
{
    public interface IOrganizationRepository
    {
        Task<IEnumerable<Organization>> GetOrganizations(OrganizationDtoParamters paramters);

        Task<IEnumerable<Organization>> GetMyOrganization(OrganizationDtoParamters paramters,string openid);

        Task<bool> Join();

        Task<bool> SignOut();

        Task<IEnumerable<Activity>> GetActivities();

        //成为志愿者

        
    }
}
