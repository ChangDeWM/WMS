using System;
using System.Linq;
using WMS.Common.Contract;
using System.Collections.Generic;
using WMS.Common.Utility;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMS.Account.Contract
{
    [Serializable]
    public class VerifyCode // : ModelBase
    {
        public Guid Guid { get; set; }
        public string VerifyText { get; set; }
    }

}



