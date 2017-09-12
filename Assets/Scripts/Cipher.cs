using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System;

public static class Cipher {


    public static string Encryption(string strText) {
        var publicKey = "<RSAKeyValue><Modulus>xiwmLwEhg61/Ky8x08CqgZxYzwHlzypa4kj7qQQAs6j5urK7NEPC3/60A/E4AysrB4FrSHAn8WThTsqLF5SypaEfhIOvAz38S30mG8zN4ja+LUYxU09NUblTQzqpC0Tlck8wCBhsK30sK1v34+MOCNNPeNUaRvB6gwWbSGaMTdU=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        var testData = Encoding.UTF8.GetBytes(strText);

        using (var rsa = new RSACryptoServiceProvider(1024)) {
            try {
                // client encrypting data with public key issued by server                    
                rsa.FromXmlString(publicKey.ToString());
                var encryptedData = rsa.Encrypt(testData, true);

                var base64Encrypted = Convert.ToBase64String(encryptedData);
                return base64Encrypted;
            }
            finally {
                rsa.PersistKeyInCsp = false;
            }
        }
    }

   


}
