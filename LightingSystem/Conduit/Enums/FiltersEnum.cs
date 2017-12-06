namespace Conduit.Enums
{
    public enum Filters
    {
        /// <summary>
        /// '&H9FFFFF00 ' ID for receive message 1  ' at this point, accept from any node SS
        /// </summary>
        MESS0 = 0x00000000,

        /// <summary>
        /// ' ID for receive message 2  ' same for this one
        /// </summary>
        MESS1 = 0x00000000,

        /// <summary>
        /// ' &H98EFFE00 ' filter 0  ' Mess 0 accept FE messages from anyone (for now)
        /// </summary>
        FILTER0 = 0x00000000,

        /// <summary>
        /// Filter 1
        /// </summary>
        FILTER1 = 0x00000000,

        /// <summary>
        /// Filter 2
        /// Mess 1 accept FF messages (name announce) always.
        /// </summary>
        FILTER2 = 0x00000000,

        /// <summary>
        /// Filter 3
        /// </summary>
        FILTER3 = 0x00000000,

        /// <summary>
        /// Filter 4
        /// </summary>
        FILTER4 = 0x00000000,

        /// <summary>
        /// Filter 5
        /// </summary>
        FILTER5 = 0x00000000
    }
}
