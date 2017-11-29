namespace LightTest.Kyle
{
    /// <summary>
    /// The status of the CAN.
    /// </summary>
    public enum CANSTAT : int
    {
        /// <summary>
        /// Status unknown.
        /// </summary>
        UNKNOWN = 0,

        /// <summary>
        /// Connected with no errors.
        /// </summary>
        OK,

        /// <summary>
        /// No interface present.
        /// </summary>
        NOINTERFACE,

        /// <summary>
        /// Connected, but unknown error.
        /// </summary>
        ERROR,

        /// <summary>
        /// Connected, but with a sending error.
        /// </summary>
        SENDERROR
    };
}
