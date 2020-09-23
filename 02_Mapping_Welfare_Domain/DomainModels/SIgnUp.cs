using _02_Mapping_Welfare_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Mapping_Welfare_Domain.DomainModels
{
    /// <summary>
    /// 活动报名人次
    /// </summary>
    public class SIgnUp:IEntity
    {
        public Guid Id { get; set; }

        public string Url { get; set; }

        public string UserName { get; set; }
    }
}
