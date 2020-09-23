using _02_Mapping_Welfare_Domain.DomainModels;
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
    public class ActivityRepository : IActivityRepository
    {
        public readonly WelfareContext _context;

        public ActivityRepository(WelfareContext context)
        {
            _context = context;
        }

        public async Task<bool> ActivityExits(Guid Id)
        {
            return await _context.Activities.AnyAsync(x => x.Id == Id);
        }

        public void  AddComment(Comments comments,Guid avId)
        {
            if (comments == null)
            {
                throw new ArgumentNullException();
            }

            if (avId ==Guid.Empty)
            {
                throw new ArgumentNullException();
            }

            comments.Id = Guid.NewGuid();
            comments.ActivityId = avId;
            comments.Created = DateTime.Now;

            _context.Comments.Add(comments);

            
        }

        public async Task<IEnumerable<Comments>> GetComments(Guid guid)
        {
            return await _context.Comments.Where(x=>x.ActivityId==guid).ToListAsync();
        }
    }
}
