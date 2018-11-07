### Overview

This adds a `jint` (javascript) transform to Transformalize using [Jint](https://github.com/sebastienros/jint).  It is a plug-in compatible with Transformalize 0.3.12-beta.

Build the Autofac project and put it's output into Transformalize's *plugins* folder.

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

BenchmarkDotNet=v0.11.2, OS=Windows 10.0.16299.251 (1709/FallCreatorsUpdate/Redstone3)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
Frequency=2742183 Hz, Resolution=364.6730 ns, Timer=TSC
  [Host]       : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.2633.0
  LegacyJitX64 : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit LegacyJIT/clrjit-v4.7.2633.0;compatjit-v4.7.2633.0

Job=LegacyJitX64  Jit=LegacyJit  Platform=X64  
Runtime=Clr  

```
|                        Method |     Mean |     Error |   StdDev | Ratio | RatioSD |
|------------------------------ |---------:|----------:|---------:|------:|--------:|
|                   &#39;5000 rows&#39; | 500.7 ms |  9.947 ms | 14.27 ms |  1.00 |    0.00 |
|            &#39;5000 rows 1 jint&#39; | 591.5 ms | 11.760 ms | 21.80 ms |  1.19 |    0.06 |
| &#39;5000 rows 1 jint with dates&#39; | 599.3 ms | 11.970 ms | 21.89 ms |  1.20 |    0.06 |
