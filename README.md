### Overview

This adds a `jint` (javascript) transform to Transformalize using [Jint](https://github.com/sebastienros/jint).  

It comes with the Transformalize CLI plugins folder.

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

``` ini
BenchmarkDotNet=v0.11.4, OS=Windows 10.0.17134.407 (1803/April2018Update/Redstone4)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
Frequency=2742192 Hz, Resolution=364.6718 ns, Timer=TSC
  [Host]       : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3221.0
  LegacyJitX64 : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit LegacyJIT/clrjit-v4.7.3221.0;compatjit-v4.7.3221.0

Job=LegacyJitX64  Jit=LegacyJit  Platform=X64  
Runtime=Clr  
```

|                        Method |     Mean |    Error |   StdDev | Ratio | RatioSD |
|------------------------------ |---------:|---------:|---------:|------:|--------:|
|                   &#39;5000 rows&#39; | 517.1 ms | 10.29 ms | 20.31 ms |  1.00 |    0.00 |
|            &#39;5000 rows 1 jint&#39; | 602.5 ms | 12.05 ms | 23.78 ms |  1.17 |    0.06 |
| &#39;5000 rows 1 jint with dates&#39; | 623.8 ms | 10.90 ms | 10.20 ms |  1.17 |    0.04 |
