﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMS.Core.Config
{
    public class ConfigNodeBase
    {
        public ConfigNodeBase()
        {
        }
        
        public int Id { get; set; }
        public int Order { get; set; }
    }
}
