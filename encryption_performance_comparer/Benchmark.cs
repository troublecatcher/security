using System;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Attributes;
using System.Security.Cryptography;
using System.Text;

namespace EncryptionPerformanceComparer
{
	//[MemoryDiagnoser]
	//[Orderer(SummaryOrderPolicy.FastestToSlowest)]
	[RankColumn]

	public class Benchmark
	{

        public static SymmetricAlgorithm DES = System.Security.Cryptography.DES.Create();
        public static SymmetricAlgorithm TripleDES = System.Security.Cryptography.TripleDES.Create();
        public static SymmetricAlgorithm Rijndael = System.Security.Cryptography.Rijndael.Create();
        public static SymmetricAlgorithm RC2 = System.Security.Cryptography.RC2.Create();
        //DES.GenerateKey(); DES.GenerateIV();
        //TripleDES.GenerateKey(); TripleDES.GenerateIV();
        //Rijndael.GenerateKey(); Rijndael.GenerateIV();
        //RC2.GenerateKey(); RC2.GenerateIV();
        string output;
        string input = readFile("/Users/anton/Desktop/neuralnetwork.cs");

        public static string readFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer);
            string textFromFile = Encoding.Default.GetString(buffer);
            return textFromFile;
        }
        
        [Benchmark]
        public void DESencryptECB()
        {
            DES.Mode = CipherMode.ECB;
            var etor = new Encryptor(DES, DES.Mode);
            output = etor.Decrypt(etor.Encrypt(input));
        }

        [Benchmark]
        public void DESencryptCBC()
        {
            DES.Mode = CipherMode.CBC;
            var etor = new Encryptor(DES, DES.Mode);
            output = etor.Decrypt(etor.Encrypt(input));
        }

        [Benchmark]
        public void TripleDESencryptECB()
        {
            TripleDES.Mode = CipherMode.ECB;
            var etor = new Encryptor(TripleDES, TripleDES.Mode);
            output = etor.Decrypt(etor.Encrypt(input));
        }

        [Benchmark]
        public void TripleDESencryptCBC()
        {
            TripleDES.Mode = CipherMode.CBC;
            var etor = new Encryptor(TripleDES, TripleDES.Mode);
            output = etor.Decrypt(etor.Encrypt(input));
        }

        [Benchmark]
        public void RijndaelEncryptECB()
        {
            Rijndael.Mode = CipherMode.ECB;
            var etor = new Encryptor(Rijndael, Rijndael.Mode);
            output = etor.Decrypt(etor.Encrypt(input));
        }

        [Benchmark]
        public void RijndaelEncryptCBC()
        {
            Rijndael.Mode = CipherMode.CBC;
            var etor = new Encryptor(Rijndael, Rijndael.Mode);
            output = etor.Decrypt(etor.Encrypt(input));
        }

        [Benchmark]
        public void RC2encryptECB()
        {
            RC2.Mode = CipherMode.ECB;
            var etor = new Encryptor(RC2, RC2.Mode);
            output = etor.Decrypt(etor.Encrypt(input));
        }

        [Benchmark]
        public void RC2encryptCBC()
        {
            RC2.Mode = CipherMode.CBC;
            var etor = new Encryptor(RC2, RC2.Mode);
            output = etor.Decrypt(etor.Encrypt(input));
        }
    }
}

