﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakerPlatform.Models
{
    public class PageResult<T>
    {
        #region BootStrap Table
        public int total { get; set; }

        public List<T> rows { get; set; }

        public PageResult(int totalCount, List<T> pageRows)
        {
            total = totalCount;
            rows = pageRows;
        }
        #endregion
    }
}