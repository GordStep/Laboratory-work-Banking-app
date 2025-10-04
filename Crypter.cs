using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Banking_app
{
    internal class Crypter
    {
        private static byte[] GetIV(string ivSecret)
        {
            using MD5 md5 = MD5.Create();
            return md5.ComputeHash(Encoding.UTF8.GetBytes(ivSecret));
        }

        private static byte[] GetKey(string key)
        {
            using SHA256 sha256 = SHA256.Create();
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
        }

        

        static public void CryptoFile(string sourceFileName, string outputFileName, string key, string ivSecret)
        {
            using Aes aes = Aes.Create();
            aes.IV = GetIV(ivSecret);
            aes.Key = GetKey(key);

            using FileStream inStream = new FileStream(sourceFileName, FileMode.Open); //создаем файловый поток на чтение
            using FileStream outStream = new FileStream(outputFileName, FileMode.Create);//создаем файловый поток на запись

            //поток для шифрования данных
            CryptoStream encStream = new CryptoStream(outStream, aes.CreateEncryptor(aes.Key, aes.IV), CryptoStreamMode.Write);

            long readTotal = 0;

            int len;
            int tempSize = 100; //размер временного хранилища
            byte[] bin = new byte[tempSize];    //временное Хранилище для зашифрованной информации

            while (readTotal < inStream.Length)
            {
                len = inStream.Read(bin, 0, tempSize);
                encStream.Write(bin, 0, len);
                readTotal = readTotal + len;
                Console.WriteLine($"{readTotal} байт обработано");
            }

            encStream.Close();
            outStream.Close();
            inStream.Close();
        }

        public static string DecryptFile(string sourceFile, string destFile, byte[] key, byte[] iv, bool IsCacheFile = false)
        {
            using FileStream fileStream = new(sourceFile, FileMode.Open);
            using Aes aes = Aes.Create();
            string decryptResult = "";

            aes.IV = iv;

            using CryptoStream cryptoStream = new(fileStream,
                                       aes.CreateDecryptor(key, iv),
                                                  CryptoStreamMode.Read); //создаем поток для чтения (расшифровки) данных
            using FileStream outStream = new FileStream(destFile, FileMode.Create);//создаем поток для расшифрованных данных

            using BinaryReader decryptReader = new(cryptoStream);
            int tempSize = 10;  //размер временного хранилища
            byte[] data;        //временное хранилище для зашифрованной информации
            while (true)
            {
                data = decryptReader.ReadBytes(tempSize);
                if (data.Length == 0)
                    break;

                outStream.Write(data, 0, data.Length);
            }
            cryptoStream.Close();
            outStream.Close();
            decryptResult = File.ReadAllText(destFile);
            
            if (IsCacheFile) File.Delete(destFile); // Если это кеш файл, то удаляем расшифрованную версию

            return decryptResult;
        }
    }
}
