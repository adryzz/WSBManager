namespace WSBManager.WSB
{
    /// <summary>
    /// A location on the host machine that will be shared into the sandbox at the specified path. At this time, relative paths are not supported. If no path is specified, the folder will be mapped to the container user's desktop.
    /// </summary>
    public struct MappedFolder
    {
        /// <summary>
        /// Specifies the folder on the host machine to share into the sandbox. Note that the folder must already exist on the host, or the container will fail to start.
        /// </summary>
        public string HostFolder;

        /// <summary>
        /// Specifies the destination in the sandbox to map the folder to. If the folder doesn't exist, it will be created. If no sandbox folder is specified, the folder will be mapped to the container desktop.
        /// </summary>
        public string SandboxFolder;

        /// <summary>
        /// If true, enforces read-only access to the shared folder from within the container.
        /// </summary>
        public bool ReadOnly;
    }
}