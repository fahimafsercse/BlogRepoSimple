using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.ViewModels
{
    public class CommentDetailViewModel
    {
        public long id { get; set; }
        public long postDetail_Id { get; set; }

        public string comment { get; set; }
        public bool isLiked { get; set; }
        public bool isDisLike { get; set; }

        public long likeCount { get; set; }

        public long? dislikeCount { get; set; }
        public bool active { get; set; }

        public long? author { get; set; }
        public long? editor { get; set; }

        public DateTime? created { get; set; }

        public DateTime? modified { get; set; }
    }
}
