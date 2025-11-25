using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;

namespace BaylanModemTest.Models
{
    public class SettingsStorage
    {
        private readonly string _filePath;
        private static readonly byte[] Entropy = Encoding.UTF8.GetBytes("BaylanModemTestEntropy");

        public SettingsStorage(string filePath)
        {
            _filePath = filePath;
        }

        public void Save(AppSettings settings)
        {
            var directory = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }
            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(settings);
            var data = Encoding.UTF8.GetBytes(json);
            var protectedBytes = ProtectedData.Protect(data, Entropy, DataProtectionScope.CurrentUser);
            File.WriteAllBytes(_filePath, protectedBytes);
        }

        public AppSettings Load()
        {
            if (!File.Exists(_filePath))
                return null;

            try
            {
                var protectedBytes = File.ReadAllBytes(_filePath);
                var data = ProtectedData.Unprotect(protectedBytes, Entropy, DataProtectionScope.CurrentUser);
                var json = Encoding.UTF8.GetString(data);
                var serializer = new JavaScriptSerializer();
                return serializer.Deserialize<AppSettings>(json);
            }
            catch (CryptographicException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
