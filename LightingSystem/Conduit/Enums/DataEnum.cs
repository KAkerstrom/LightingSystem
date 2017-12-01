namespace Conduit.Enums
{
    /// <summary>
    /// The identifiers for each byte in the data array.
    /// </summary>
    public enum Data : byte
    {
        /// <summary>
        /// The number of bytes.
        /// </summary>
        NumBytes = 1,

        /// <summary>
        /// The control byte 2.
        /// </summary>
        Control2 = 2,

        /// <summary>
        /// The start of the ID bytes.
        /// </summary>
        ID0 = 3,

        /// <summary>
        /// The second ID byte.
        /// </summary>
        ID1 = 4,

        /// <summary>
        /// The third ID byte.
        /// </summary>
        ID2 = 5,

        /// <summary>
        /// The fourth ID byte.
        /// </summary>
        ID3 = 6,

        /// <summary>
        /// Data byte 0.
        /// Also used as the Command byte.
        /// </summary>
        Data0 = 7,

        /// <summary>
        /// Data byte 1.
        /// </summary>
        Data1 = 8,

        /// <summary>
        /// Data byte 2.
        /// </summary>
        Data2 = 9,

        /// <summary>
        /// Data byte 3.
        /// </summary>
        Data3 = 10,

        /// <summary>
        /// Data byte 4.
        /// </summary>
        Data4 = 11,

        /// <summary>
        /// Data byte 5.
        /// </summary>
        Data5 = 12,

        /// <summary>
        /// Data byte 6.
        /// </summary>
        Data6 = 13,

        /// <summary>
        /// Data byte 7.
        /// </summary>
        Data7 = 14,
    }
}
