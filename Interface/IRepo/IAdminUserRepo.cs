﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.IRepo
{
    public interface IAdminUserRepo
    {
        AdminUser GetAdminUserByUserId(long userId);
    }
}
