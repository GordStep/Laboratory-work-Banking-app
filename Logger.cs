using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_app
{
    internal class Logger
    {
        static public void WriteLog(string message)
        {
            string LogFileName = "Bank_log.log";
            int sh = 5;

            string encrypted_message = CeaserCipher(message, sh);

            var time = DateTime.Now.ToString();

            File.AppendAllText(LogFileName, time + ": " + encrypted_message);

            FileDecryption(LogFileName, sh);
        }

        //public static void FileEncryption(string filePath, int sh)
        //{
        //    string text = File.ReadAllText(filePath);
        //    var enFile = File.CreateText("encrypted_file.txt");
        //    enFile.Write(CeaserCipher(text, sh));
        //    enFile.Close();
        //}

        public static void FileDecryption(string filePath, int sh)
        {
            var unFile = File.CreateText("unencrypted_file.txt");
            string text = File.ReadAllText($"{filePath}");

            unFile.Write(CeaserCipher(text, -sh));
            unFile.Close();
        }
        public static string CeaserCipher(string text, int shift)
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
    }
}
