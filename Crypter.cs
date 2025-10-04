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
        public static string StringCeaserCipher(string text, int shift)
        {
            char[] buffer = text.ToCharArray();

            for (int i = 0; i < buffer.Length; i++)
            {
                if (char.IsLetter(buffer[i]))
                {
                    char startLetter = 'а';
                    if (char.IsUpper(buffer[i])) startLetter = 'А';

                    int char_ind = buffer[i] - startLetter;

                    buffer[i] = (char)((((buffer[i] + shift) - startLetter + 33) % 33) + startLetter);
                }
            }
            return new string(buffer);
        }

        public static void FileCeaserCipher(string inputFileName, string outputFileName, int shift)
        {
            
            string inputText, outputText;
            try
            {
                inputText = File.ReadAllText(inputFileName);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Памылка!"); return; }
            
            char[] buffer = inputText.ToCharArray();

            for (int i = 0; i < buffer.Length; i++)
            {
                if (char.IsLetter(buffer[i]))
                {
                    char startLetter = 'а';
                    if (char.IsUpper(buffer[i])) startLetter = 'А';

                    int char_ind = buffer[i] - startLetter;

                    buffer[i] = (char)((((buffer[i] + shift) - startLetter + 33) % 33) + startLetter);
                }
            }
            outputText = new string(buffer);

            MessageBox.Show(outputText, "Памылка!");

            try
            {
                File.WriteAllText(outputFileName, outputText);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Памылка!"); return; }
            MessageBox.Show(File.ReadAllText(outputFileName));
        }

        public static void FileCeaserDeCipher(string inputFileName, string outputFileName, int shift)
        {
            shift *= -1;

            string inputText, outputText;
            try
            {
                inputText = File.ReadAllText(inputFileName);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Памылка!"); return; }

            char[] buffer = inputText.ToCharArray();

            for (int i = 0; i < buffer.Length; i++)
            {
                if (char.IsLetter(buffer[i]))
                {
                    char startLetter = 'а';
                    if (char.IsUpper(buffer[i])) startLetter = 'А';

                    int char_ind = buffer[i] - startLetter;

                    buffer[i] = (char)((((buffer[i] + shift) - startLetter + 33) % 33) + startLetter);
                }
            }
            outputText = new string(buffer);

            try
            {
                File.WriteAllText(outputFileName, outputText);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Памылка!"); return; }
        }
        //private static byte[] GetIV(string ivSecret)
        //{
        //    using MD5 md5 = MD5.Create();
        //    return md5.ComputeHash(Encoding.UTF8.GetBytes(ivSecret));
        //}

        //private static byte[] GetKey(string key)
        //{
        //    using SHA256 sha256 = SHA256.Create();
        //    return sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
        //}

        ////static void Main(string[] args)
        ////{
        ////    string sourceFileName = "secretfile.txt"; //файл, который будем шифровать
        ////    string outputFileName = "secretfile.enc"; //файл, который будет содержать зашифрованные данные
        ////    string key = "секретный ключ"; //ключ для шифрования
        ////    string ivSecret = "вектор"; //вектор инициализации


        ////    CryptoFile(sourceFileName, outputFileName, key, ivSecret);
        ////    DecryptFile(outputFileName, "decrypt.txt", GetKey(key), GetIV(ivSecret));
        ////}

        //static public void CryptoFile(string sourceFileName, string outputFileName, string key, string ivSecret)
        //{
        //    using Aes aes = Aes.Create();
        //    aes.IV = GetIV(ivSecret);
        //    aes.Key = GetKey(key);

        //    using FileStream inStream = new FileStream(sourceFileName, FileMode.Open); //создаем файловый поток на чтение
        //    using FileStream outStream = new FileStream(outputFileName, FileMode.Create); //создаем файловый поток на запись

        //    //поток для шифрования данных
        //    CryptoStream encStream = new CryptoStream(outStream, aes.CreateEncryptor(aes.Key, aes.IV), CryptoStreamMode.Write);

        //    long readTotal = 0;

        //    int len;
        //    int tempSize = 100; //размер временного хранилища
        //    byte[] bin = new byte[tempSize];    //временное Хранилище для зашифрованной информации

        //    while (readTotal < inStream.Length)
        //    {
        //        len = inStream.Read(bin, 0, tempSize);
        //        encStream.Write(bin, 0, len);
        //        readTotal = readTotal + len;
        //        Console.WriteLine($"{readTotal} байт обработано");
        //    }

        //    encStream.Close();
        //    outStream.Close();
        //    inStream.Close();
        //}

        //public static void DecryptFile(string sourceFile, string destFile, string inputKey, string ivSecret)
        //{
        //    using FileStream fileStream = new(sourceFile, FileMode.Open);
        //    using Aes aes = Aes.Create();
        //    string decryptResult = "";

        //    var key = GetKey(inputKey);
        //    var iv = GetIV(ivSecret);
        //    aes.IV = iv;

        //    using CryptoStream cryptoStream = new(fileStream,
        //                               aes.CreateDecryptor(key, iv),
        //                                          CryptoStreamMode.Read); //создаем поток для чтения (расшифровки) данных
        //    using FileStream outStream = new FileStream(destFile, FileMode.Create);//создаем поток для расшифрованных данных

        //    using BinaryReader decryptReader = new(cryptoStream);
        //    int tempSize = 10;  //размер временного хранилища
        //    byte[] data;        //временное хранилище для зашифрованной информации
        //    while (true)
        //    {
        //        data = decryptReader.ReadBytes(tempSize);
        //        if (data.Length == 0)
        //            break;

        //        outStream.Write(data, 0, data.Length);
        //    }
        //    cryptoStream.Close();
        //    outStream.Close();
        //    decryptReader.Close();
        //    //decryptResult = File.ReadAllText(destFile);
        //    //File.Delete(sourceFile);

        //    //return decryptResult;
        //}
    }
}
