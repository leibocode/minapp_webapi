using _02_Mapping_Welfare_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Mapping_Welfare_Domain.DomainModels
{
    public class Banner:IEntity
    {
       
        public Guid Id { get; set; }

        public string Url { get; set; }
    }
}
