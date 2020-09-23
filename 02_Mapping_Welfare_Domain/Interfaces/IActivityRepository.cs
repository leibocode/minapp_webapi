using _02_Mapping_Welfare_Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _02_Mapping_Welfare_Domain.Interfaces
{
    public interface IActivityRepository
    {
        void AddComment(Comments comments, Guid avId);

        Task<IEnumerable<Comments>> GetComments(Guid Id);

        Task<bool> ActivityExits(Guid Id);
    }
}
