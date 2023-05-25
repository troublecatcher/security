``` ini

BenchmarkDotNet=v0.13.5, OS=macOS Ventura 13.2.1 (22D68) [Darwin 22.3.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 7.0.4 (7.0.423.11508), Arm64 RyuJIT AdvSIMD [AttachedDebugger]
  DefaultJob : .NET 7.0.4 (7.0.423.11508), Arm64 RyuJIT AdvSIMD


```
|              Method |        Mean |    Error |    StdDev |      Median | Rank |
|-------------------- |------------:|---------:|----------:|------------:|-----:|
|       DESencryptECB |   365.34 μs | 1.519 μs |  1.347 μs |   364.74 μs |    3 |
|       DESencryptCBC |   462.79 μs | 1.843 μs |  1.724 μs |   462.68 μs |    4 |
| TripleDESencryptECB | 1,081.58 μs | 8.151 μs |  7.226 μs | 1,081.28 μs |    6 |
| TripleDESencryptCBC | 1,173.99 μs | 6.998 μs |  6.546 μs | 1,170.98 μs |    7 |
|  RijndaelEncryptECB |    27.01 μs | 0.071 μs |  0.060 μs |    27.01 μs |    1 |
|  RijndaelEncryptCBC |    45.11 μs | 0.060 μs |  0.054 μs |    45.10 μs |    2 |
|       RC2encryptECB |   478.36 μs | 9.480 μs | 24.302 μs |   464.14 μs |    4 |
|       RC2encryptCBC |   513.78 μs | 1.432 μs |  1.340 μs |   513.57 μs |    5 |
