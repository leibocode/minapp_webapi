using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Mapping_Welfare_Domain.DomainModels
{
    public class WechatUser
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string PIDNumber { get; set; }

        /// <summary>
        /// 地区
        /// </summary>
        public int Region { get; set; }

        public Organization Organizations { get; set; }

        public Guid? OrgId { get; set; }

        public string Address { get; set; }
    }
}
