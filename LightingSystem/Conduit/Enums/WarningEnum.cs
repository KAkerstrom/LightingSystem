using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Enums
{
    public enum Warning
    {
        OK,
        RxWarning,
        TxWarning,
        Buffer0Warning,
        Buffer1Warning,
        RxPassive,
        TxPassive,
        BussOff,
        BufferEquals1500
    }
}
