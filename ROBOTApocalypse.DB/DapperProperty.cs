using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROBOTApocalypse.DB
{
    public class DapperProperty
    {
        public DynamicParameters DynamicParameters { get; set; }
        public string ProcName { get; set; }
        public int CommandTimeout { get; set; }

    }
}
