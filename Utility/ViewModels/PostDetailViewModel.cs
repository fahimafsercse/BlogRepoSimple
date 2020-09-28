using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.ViewModels
{
    public class PostDetailViewModel
    {
        public long id { get; set; }

        public long? totalComment { get; set; }

        public string post { get; set; }

        public DateTime? created { get; set; }

        public DateTime? modified { get; set; }

        public long author { get; set; }

        public long editor { get; set; }

        public bool? active { get; set; }
        public List<CommentDetailViewModel> commentDetailViewModels { get; set; }
    }
}
