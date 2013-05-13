using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infraestructure.DataHandle
{
  public class Hash
  {

    /// <summary>
    /// Hash the given value with SHA algorithm and a key of 256 characters.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The hash string</returns>
    public static string SHA256(string text)
    {
      string hash = Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(text)));

      return hash;
    }

  }
}
