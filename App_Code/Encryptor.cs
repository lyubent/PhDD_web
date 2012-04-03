using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Encryptor
/// </summary>
public class Encryptor
{
	public Encryptor()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
/*
 try
            {
                //Create a UnicodeEncoder to convert between byte array and string.
                UnicodeEncoding ByteConverter = new UnicodeEncoding();

                //Create byte arrays to hold original, encrypted, and decrypted data.
                byte[] dataToEncrypt = Convert.FromBase64String(PassEncrypt);
                byte[] encryptedData;

                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    //and a boolean flag specifying no OAEP padding.
                    encryptedData = RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);
                    string EncryptedString = Convert.ToBase64String(encryptedData);
                    Pass = EncryptedString;
                }
                
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Encryption failed.");
            }

 static public byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
    {
        try
        {
            byte[] encryptedData;
            //Create a new instance of RSACryptoServiceProvider.
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {

                //Import the RSA Key information. This only needs
                //toinclude the public key information.
                RSA.ImportParameters(RSAKeyInfo);

                //Encrypt the passed byte array and specify OAEP padding.  
                //OAEP padding is only available on Microsoft Windows XP or
                //later.  
                encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
            }
            return encryptedData;
        }
        //Catch and display a CryptographicException  
        //to the console.
        catch (CryptographicException e)
        {
            Console.Write(e.Message);
            return null;
        }

    }
    static public byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
    {
        try
        {
            //Create a new instance of RSACryptoServiceProvider.
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

            //Import the RSA Key information. This needs
            //to include the private key information.
            RSA.ImportParameters(RSAKeyInfo);

            //Decrypt the passed byte array and specify OAEP padding.  
            //OAEP padding is only available on Microsoft Windows XP or
            //later.  
            return RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
        }
        //Catch and display a CryptographicException  
        //to the console.
        catch (CryptographicException e)
        {
            Console.WriteLine(e.ToString());
            return null;
        }

    }
 * 
 * try
                {
                    //Create a UnicodeEncoder to convert between byte array and string.
                    UnicodeEncoding ByteConverter = new UnicodeEncoding();

                    //Create byte arrays to hold original, encrypted, and decrypted data.
                    //byte[] bytes = Convert.FromBase64String(dataEncryptedBase64);
                    byte[] dataToDecrypt = Convert.FromBase64String(DecryptPassword);
                    byte[] decryptedData;

                    //Create a new instance of RSACryptoServiceProvider to generate
                    //public and private key data.
                    RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                    
                    //Pass the data to DECRYPT, the private key information 
                    //(using RSACryptoServiceProvider.ExportParameters(true),
                    //and a boolean flag specifying no OAEP padding.
                    decryptedData = RSADecrypt(dataToDecrypt, RSA.ExportParameters(true), false);

                    //Display the decrypted plaintext to the console. 
                    DecryptPassword = ByteConverter.GetString(decryptedData);

                    if (DecryptPassword == InputPassword)
                    {
                        Response.Redirect("~/Index.aspx");
                    }
                    else
                    {
                        Server.Transfer("Login.aspx");
                    }
                }
                catch (ArgumentNullException)
                {
                    //Catch this exception in case the encryption did
                    //not succeed.
                    Console.WriteLine("Encryption failed.");

                }

*/