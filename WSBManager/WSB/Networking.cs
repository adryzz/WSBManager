using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSBManager.WSB
{
    /// <summary>
    /// Enables or disables networking in the sandbox.
    /// You can disable network access to decrease the attack surface exposed by the sandbox.
    /// </summary>
    public enum Networking
    {
        Default = 0,
        Disable = 1,
    }
}
