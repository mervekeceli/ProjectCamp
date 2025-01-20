using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BusinessLayer.Helpers
{
    public class PasswordHelper
    {
        //şifreyi hashle ve salt oluştur

        public (string hash, string salt) HashPassword(string password)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var salt = new byte[16];
                rng.GetBytes(salt); //saltı rastgele oluştur

                string saltBase64 = Convert.ToBase64String(salt);

                using (var sha256 = new SHA256Managed())
                {
                    //şifreyi byte dizisine dönüştür
                    var passwordBytes = Encoding.UTF8.GetBytes(password);

                    //Saltı'ı şifre ile birleştir
                    var passwordWithSalt = passwordBytes.Concat(Convert.FromBase64String(saltBase64)).ToArray();

                    //Hash'le
                    var hashedPassword = sha256.ComputeHash(passwordWithSalt);
                    string hashBase64 = Convert.ToBase64String(hashedPassword);

                    return (hashBase64, saltBase64);
                }
            }
        }

        //şifre doğrulama  için 
        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            var salt = Convert.FromBase64String(storedSalt);

            using (var sha256 = new SHA256Managed())
            {
                var enteredPasswordBytes = Encoding.UTF8.GetBytes(enteredPassword);
                var passwordWithSalt = enteredPasswordBytes.Concat(salt).ToArray();

                var hash = sha256.ComputeHash(passwordWithSalt);
                string enteredPasswordHash = Convert.ToBase64String(hash);

                return storedHash == enteredPasswordHash;
            }
        }
    }
}
