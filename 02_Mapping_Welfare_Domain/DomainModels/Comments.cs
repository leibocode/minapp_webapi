using _02_Mapping_Welfare_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Mapping_Welfare_Domain.DomainModels
{
    public class Comments : IEntity
    {
        public Guid Id { get; set; }

        public DateTime Crated { get; set; }

        public string CommentText { get; set; }

        public Activity Activity { get; set; }

        public Guid ActivityId { get; set; }
    }
}
