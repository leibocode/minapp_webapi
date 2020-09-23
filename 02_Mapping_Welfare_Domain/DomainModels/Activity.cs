using _02_Mapping_Welfare_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Mapping_Welfare_Domain.DomainModels
{
    public class Activity:IEntity
    {
      
        public Guid Id { get; set; }
        
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 地区
        /// </summary>
        public int Region { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }

        /// <summary>
        /// 点赞
        /// </summary>
        public int Give { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Astate { get; set; }

        public DateTime Created { get; set; }

        public ICollection<Comments> Comments { get; set; }
    }
}
