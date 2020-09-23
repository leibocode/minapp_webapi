using _02_Mapping_Welfare_Domain.DomainModels;
using _02_Mapping_Welfare_Domain.DtoParamters;
using _02_Mapping_Welfare_Domain.Interfaces;
using _03_Mapping_Welfare_Infrastructure.Data;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Organization>> GetMyOrganization(OrganizationDtoParamters paramters)
        {
           
        }

        public Task<IEnumerable<Organization>> GetOrganizations(OrganizationDtoParamters paramters)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Join()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SignOut()
        {
            throw new NotImplementedException();
        }
    }
}
