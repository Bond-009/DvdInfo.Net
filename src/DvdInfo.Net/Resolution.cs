namespace DvdInfo
{
    /// <summary>
    /// Resolution NTSC (PAL).
    /// </summary>
    public enum Resolution : uint
    {
        /// <summary>
        /// <c>720x480 (720x576)</c>.
        /// </summary>
        Full = 0,

        /// <summary>
        /// <c>704x480 (704x576)</c>.
        /// </summary>
        Reduced = 1,

        /// <summary>
        /// <c>352x480 (352x576)</c>.
        /// </summary>
        Half = 2,

        /// <summary>
        /// <c>352x240 (352x288)</c>.
        /// </summary>
        Quarter = 3
    }
}
