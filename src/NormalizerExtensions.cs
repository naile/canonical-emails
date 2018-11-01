using System.Net.Mail;

namespace CanonicalEmails
{
    /// <summary>
    /// 
    /// </summary>
    public static class NormalizerExtensions
    {
        /// <summary>
        /// Normalize email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static MailAddress Normalize(this MailAddress email, NormalizerSettings settings = null)
        {
            return Normalizer.Normalize(email, settings);
        }

    }
}
