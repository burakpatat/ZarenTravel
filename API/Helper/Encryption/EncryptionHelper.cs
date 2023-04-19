using System;
using System.Security.Cryptography;
using System.Text;


public class EncryptionHelper
{
    public static string EncryptData(string data, string key = "")
    {
        RijndaelManaged AES = new RijndaelManaged();
        MD5CryptoServiceProvider Hash_AES = new MD5CryptoServiceProvider();
        string encrypted = "";

        try
        {
            byte[] hash = new byte[32];
            byte[] temp = Hash_AES.ComputeHash(Encoding.UTF8.GetBytes(key));
            Array.Copy(temp, 0, hash, 0, 16);
            Array.Copy(temp, 0, hash, 15, 16);
            AES.Key = hash;
            AES.Mode = CipherMode.ECB;
            ICryptoTransform DESEncrypter = AES.CreateEncryptor();
            byte[] Buffer = Encoding.UTF8.GetBytes(data);
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length));
        }
        catch (Exception ex)
        {
        }
        return encrypted;
    }

    public static string DecryptData(string data, string key = "")
    {
        RijndaelManaged AES = new RijndaelManaged();
        MD5CryptoServiceProvider Hash_AES = new MD5CryptoServiceProvider();
        string decrypted = "";
        try
        {
            byte[] hash = new byte[32];
            byte[] temp = Hash_AES.ComputeHash(Encoding.UTF8.GetBytes(key));
            Array.Copy(temp, 0, hash, 0, 16);
            Array.Copy(temp, 0, hash, 15, 16);
            AES.Key = hash;
            AES.Mode = CipherMode.ECB;
            ICryptoTransform DESDecrypter = AES.CreateDecryptor();
            byte[] Buffer = Convert.FromBase64String(data);
            decrypted = Encoding.UTF8.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length));
        }
        catch (Exception ex)
        {
        }
        return decrypted;
    }
}
