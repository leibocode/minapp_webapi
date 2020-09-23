using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Mapping_Welfare_Infrastructure.Data.Dtos.Comments
{
   public class CommentDto
    {
        public string WechatName { get; set; }

        public string WechatAv { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }
    }
}
