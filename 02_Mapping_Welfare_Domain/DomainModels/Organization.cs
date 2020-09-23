using _02_Mapping_Welfare_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Mapping_Welfare_Domain.DomainModels
{
    public class Organization : IEntity
    {
        public Guid Id { get; set; }

        public string Category { get; set; }

        public string Url { get; set; }

        public int Region { get; set; }

        public string Name { get; set; }

        public int orgState { get; set; }

        public ICollection<WechatUser> WechatUsers { get; set; }
         

    }
}
