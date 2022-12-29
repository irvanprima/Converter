using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Converter_Project.InfoCuaca;

namespace Converter_Project
{
    class nama_kota
    {
        public class RECORDS    
        {
            public string owm_city_name { get; set; }             
        }
        public class root
        {
            public RECORDS RECORDS { get; set; }
            
        }
    }
}
