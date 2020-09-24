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
    public class WechatUserRepository : IWechatUserRepository
    {

        public readonly WelfareContext _context;

        public WechatUserRepository(WelfareContext context)
        {
            _context = context;
        }

        public async Task<bool> AddOrUpdateUser(string openid, string name, string avr)
        {
            var  user  = await _context.WechatUsers.FirstOrDefaultAsync(x=>x.OpenId==openid);

            if (user == null)
            {
                var entity = new WechatUser()
                {
                    OpenId = openid,
                    Avr = avr,
                    NickName = name
                };

                _context.WechatUsers.Add(entity);
            }

            user.NickName = name;
            user.Avr = avr;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> WechatExits(string openid)
        {
            return await _context.WechatUsers.AnyAsync();
        }
    }
}
