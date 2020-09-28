using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.ViewModels
{
    public class UserInformationViewModel
    {
        public long id { get; set; }

        public string accountName { get; set; }

        public string displayName { get; set; }

        public string email { get; set; }

        public string designation { get; set; }

        public string department { get; set; }
        public bool active { get; set; }
    }
}
