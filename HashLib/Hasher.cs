using System;
using System.Security.Cryptography;
using System.Text;

namespace HashLib
{
    /// <summary>
    /// Provides SHA256 hashing utilities for password storage and verification.
    /// Used by the web application to hash passwords before saving them to XML files.
    /// </summary>
    public static class Hasher
    {
        /// <summary>
        /// Computes the SHA256 hash of the input string and returns it as a lowercase hex string.
        /// </summary>
        public static string Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input cannot be null or empty.");
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                // Convert each byte to a 2-digit lowercase hex value
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Verifies whether a plain text input matches a previously stored hash.
        /// </summary>
        public static bool Verify(string input, string hash)
        {
            string inputHash = Hash(input);
            return string.Equals(inputHash, hash, StringComparison.OrdinalIgnoreCase);
        }
    }
}