﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace BLL.Interfaces
{
    public interface IDanhMucBLL
    {
       DanhMucModel GetDanhMucCay(int id);
    }
}
