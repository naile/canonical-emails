namespace CanonicalEmails
{
    /// <summary>
    /// Normalizer Settings
    /// </summary>
    public class NormalizerSettings
    {
        /// <summary>
        /// Remove "." for applicable domains
        /// </summary>
        public bool RemoveDots { get; set; } = true;

        /// <summary>
        /// Remove tags (ex: '+' and '-') for applicable domains)
        /// </summary>
        public bool RemoveTags { get; set; } = true;

        /// <summary>
        /// Lowercase
        /// </summary>
        public bool LowerCase { get; set; } = true;

        /// <summary>
        /// Replace the host with the canonical version (ex: googlemail.com => gmail.com)
        /// </summary>
        public bool NormalizeHost { get; set; } = true;
    }
}
