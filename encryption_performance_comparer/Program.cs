using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using EncryptionPerformanceComparer;

var summary = BenchmarkRunner.Run<Benchmark>();
//File.OpenRead(summary.ResultsDirectoryPath);

//var etor = new Encryptor(System.Security.Cryptography.DES.Create());
//Console.Write(etor.Decrypt(etor.Encrypt("1231k2l3kjm")));