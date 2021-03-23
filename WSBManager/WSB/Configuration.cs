using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSBManager.WSB
{
    /// <summary>
    /// Sandbox configuration
    /// </summary>
    public struct Configuration
    {
        /// <summary>
        /// Specifies the amount of memory that the sandbox can use in megabytes (MB).
        /// If the memory value specified is insufficient to boot a sandbox, it will be automatically increased to the required minimum amount.
        /// </summary>
        public ulong MemoryInMB;

        /// <summary>
        /// Enables or disables GPU sharing.
        /// </summary>
        public VGpu VGpu;

        /// <summary>
        /// Enables or disables networking in the sandbox. 
        /// You can disable network access to decrease the attack surface exposed by the sandbox.
        /// </summary>
        public Networking Networking;

        /// <summary>
        /// A list of <see cref="MappedFolder"/>s
        /// </summary>
        public List<MappedFolder> MappedFolders;

        /// <summary>
        /// Specifies a single command that will be invoked automatically after the sandbox logs on.
        /// </summary>
        public LogonCommand LogonCommand;

        /// <summary>
        /// Enables or disables audio input to the sandbox.
        /// </summary>
        public AudioInput AudioInput;

        /// <summary>
        /// Enables or disables video input to the sandbox.
        /// </summary>
        public VideoInput VideoInput;

        /// <summary>
        /// Applies additional security settings to the sandbox Remote Desktop client, decreasing its attack surface.
        /// </summary>
        public ProtectedClient ProtectedClient;

        /// <summary>
        /// Enables or disables printer sharing from the host into the sandbox.
        /// </summary>
        public PrinterRedirection PrinterRedirection;

        /// <summary>
        /// Enables or disables sharing of the host clipboard with the sandbox.
        /// </summary>
        public ClipboardRedirection ClipboardRedirection;
    }
}
