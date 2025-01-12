### Overview

This adds a `jint` (javascript) transform to Transformalize using [Jint](https://github.com/sebastienros/jint) and [Esprima Dotnet](https://github.com/sebastienros/esprima-dotnet).

Documentation will be written in the near future by AI 👌.  For now, see [Tests](src/Test.Integration.Core).

### Usage

```xml
<cfg name="Test">
    <entities>
        <add name="Test">
            <rows>
                <add text="SomethingWonderful" number="2" />
            </rows>
            <fields>
                <add name="text" />
                <add name="number" type="int" />
            </fields>
            <calculated-fields>
                <add name="evaluated" t='jint(text + " " + number)' />
            </calculated-fields>
        </add>
    </entities>
</cfg>
```

This produces `SomethingWonderful 2`

### Benchmark

```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4602/23H2/2023Update/SunValley3)
AMD Ryzen 7 5800X, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.101
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2
```
| Method                        | Mean     | Error   | StdDev  | Ratio | RatioSD |
|------------------------------ |---------:|--------:|--------:|------:|--------:|
| &#39;5000 rows&#39;                   | 108.8 ms | 1.08 ms | 0.90 ms |  1.00 |    0.01 |
| &#39;5000 rows 1 jint&#39;            | 130.6 ms | 0.98 ms | 0.92 ms |  1.20 |    0.01 |
| &#39;5000 rows 1 jint with dates&#39; | 139.8 ms | 1.70 ms | 1.59 ms |  1.28 |    0.02 |
