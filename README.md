### Overview

This adds a `jint` (javascript) transform to Transformalize using [Jint](https://github.com/sebastienros/jint).  

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

```ini
BenchmarkDotNet v0.13.12, Windows 11 (10.0.22621.3007/22H2/2022Update/SunValley2)
AMD Ryzen 7 5800X, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```
| Method                        | Mean     | Error   | StdDev  | Ratio | RatioSD |
|------------------------------ |---------:|--------:|--------:|------:|--------:|
| &#39;5000 rows&#39;                   | 108.4 ms | 1.13 ms | 1.06 ms |  1.00 |    0.00 |
| &#39;5000 rows 1 jint&#39;            | 132.5 ms | 1.19 ms | 1.11 ms |  1.22 |    0.02 |
| &#39;5000 rows 1 jint with dates&#39; | 141.1 ms | 2.10 ms | 1.86 ms |  1.30 |    0.02 |
