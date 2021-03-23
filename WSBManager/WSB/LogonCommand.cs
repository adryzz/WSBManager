namespace WSBManager.WSB
{
    /// <summary>
    /// Specifies a single command that will be invoked automatically after the sandbox logs on.
    /// </summary>
    public struct LogonCommand
    {
        /// <summary>
        /// A path to an executable or script inside the container that will be executed after login.
        /// </summary>
        public string Command;
    }
}