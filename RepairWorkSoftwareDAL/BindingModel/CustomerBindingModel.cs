﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkSoftwareDAL.BindingModel
{
    [DataContract]
    public class CustomerBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string CustomerFIO { get; set; }
        
        [DataMember]
        public string Mail { get; set; }
    }
}
