using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.ViewModels
{
    public class AdminUserViewModel
    {
        public long id { get; set; }
        public string accountName { get; set; }
        public string displayName { get; set; }
        public string email { get; set; }
        public bool? active { get; set; }
        public long author { get; set; }
        public long editor { get; set; }
        public long userId { get; set; }
        public UserInformationViewModel user { get; set; }
        public UserInformationViewModel authorUser { get; set; }
        public UserInformationViewModel editorUser { get; set; }
        public DateTime modified { get; set; }
        public DateTime created { get; set; }
    }
}
