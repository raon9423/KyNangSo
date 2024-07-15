using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebAppCore.Helper
{
    public class Utilities
    {
        public const int PAGE_SIZE = 20;
        //Kiểm tra Gmail
        public static bool IsValidEmail(string email)
        {
            if (email.Trim().EndsWith("."))
            {
                return false; 
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        //Tạo thư mục
        public static void CreateIfMissing(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        public static string ToTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        public static bool IsInteger(string str)
        {
            return int.TryParse(str, out _);
        }

        public static string SEOUrl(string url)
        {
            // Your SEO logic here
            return url;
        }
        public static async Task<string> UploadFile(IFormFile file, string directory)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            CreateIfMissing(directory);

            string fileName = Path.Combine(directory, Path.GetRandomFileName());
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;

        }
            //TextElementEnumerator

            public static string GetRandomKey(int length = 5)
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                Random random = new Random();
                return new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}