using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

public class Encryptor : IDisposable
{
    public SymmetricAlgorithm CryptoAlgorithm { get; }
    public CipherMode Mode { get; }


    public Encryptor(SymmetricAlgorithm cryptoAlgorithm, CipherMode mode)
    {
        CryptoAlgorithm = cryptoAlgorithm;
        cryptoAlgorithm.Mode = mode;
    }

    public byte[] Encrypt(string text)
    {
        return EncryptAsync(text).Result;
    }

    public async Task<byte[]> EncryptAsync(string text)
    {
        return await EncryptAsync(text, CryptoAlgorithm.CreateEncryptor());
    }

    public async Task<byte[]> EncryptAsync(string text, Stream outputFileStream)
    {
        return await EncryptAsync(text, CryptoAlgorithm.CreateEncryptor(), outputFileStream);
    }

    public static async Task<byte[]> EncryptAsync(string plainText, byte[] key, byte[] iv)
    {
        byte[] encrypted;

        using (var aes = new AesManaged())
        {
            var encryptor = aes.CreateEncryptor(key, iv);

            encrypted = await EncryptAsync(plainText, encryptor);
        }

        return encrypted;
    }

    private static async Task<byte[]> EncryptAsync(string plainText, ICryptoTransform encryptor)
    {
        using var memoryStream = new MemoryStream();
        return await EncryptAsync(plainText, encryptor, memoryStream);
    }

    private static async Task<byte[]> EncryptAsync(
        string plainText,
        ICryptoTransform encryptor,
        Stream outputStream
    )
    {
        byte[] encrypted;
        MemoryStream memoryStream;

        using (var cryptoStream = new CryptoStream(outputStream, encryptor, CryptoStreamMode.Write))
        {
            using (var streamWriter = new StreamWriter(cryptoStream))
            {
                await streamWriter.WriteAsync(plainText);
                if (outputStream is MemoryStream stream)
                {
                    streamWriter.Close();
                    memoryStream = stream;
                }
                else
                {
                    using (memoryStream = new MemoryStream())
                    {
                        await outputStream.CopyToAsync(memoryStream);
                    }
                }

                encrypted = memoryStream.ToArray();
            }
        }

        return encrypted;
    }

    public string Decrypt(byte[] encryptedData)
    {
        return DecryptAsync(encryptedData).Result;
    }

    public async Task<string> DecryptAsync(byte[] encryptedData)
    {
        return await DecryptAsync(encryptedData, CryptoAlgorithm.CreateDecryptor());
    }

    public async Task DecryptAsync(byte[] encryptedData, Stream outputStream)
    {
        await DecryptAsync(encryptedData, CryptoAlgorithm.CreateDecryptor(), outputStream);
    }

    public static async Task<string> DecryptAsync(byte[] encryptedData, byte[] key, byte[] iv)
    {
        using (var aes = new AesManaged())
        {
            var decryptor = aes.CreateDecryptor(key, iv);
            var plaintext = await DecryptAsync(encryptedData, decryptor);

            return plaintext;
        }
    }

    private static async Task<string> DecryptAsync(byte[] encryptedData, ICryptoTransform decryptor)
    {
        using var encryptedStream = new MemoryStream(encryptedData);
        {
            return await DecryptAsync(encryptedStream, decryptor);
        }
    }

    private static async Task DecryptAsync(byte[] encryptedData, ICryptoTransform decryptor, Stream outputStream)
    {
        using (var encryptedStream = new MemoryStream(encryptedData))
        {
            await DecryptAsync(encryptedStream, decryptor, outputStream);
        }
    }

    private static async Task<string> DecryptAsync(Stream encryptedStream, ICryptoTransform decryptor)
    {
        using (var cryptoStream = new CryptoStream(encryptedStream, decryptor, CryptoStreamMode.Read))
        {
            using (var reader = new StreamReader(cryptoStream))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }

    private static async Task DecryptAsync(
        Stream encryptedStream,
        ICryptoTransform decryptor,
        Stream decryptedStream
    )
    {
        using (var cryptoStream = new CryptoStream(encryptedStream, decryptor, CryptoStreamMode.Read))
        {
            await cryptoStream.CopyToAsync(decryptedStream);
        }
    }

    private bool Disposed { get; set; }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (Disposed)
        {
            return;
        }

        if (disposing)
        {
            if (CryptoAlgorithm != null)
            {
                CryptoAlgorithm.Clear();
                CryptoAlgorithm.Dispose();
            }
        }

        Disposed = true;
    }
}
