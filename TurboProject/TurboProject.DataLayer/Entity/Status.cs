﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboProject.DataLayer.Entity
{
    public class Status:BaseEntity
    {
        public string StatusName { get; set; }
        public DateTime EndTime { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
