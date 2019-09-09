﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareDAL.ViewModel
{
    public class StocksLoadViewModel
    {
        public string StockName { get; set; }

        public int TotalCount { get; set; }

        public IEnumerable<Tuple<string, int>> Components { get; set; }
    }
}
