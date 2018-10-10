### Overview

This adds a `jint` (javascript) transform to Transformalize using [Jint](https://github.com/sebastienros/jint).  It is a plug-in compatible with Transformalize 0.3.5-beta.

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

BenchmarkDotNet=v0.11.1, OS=Windows 10.0.16299.251 (1709/FallCreatorsUpdate/Redstone3)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
Frequency=2742189 Hz, Resolution=364.6722 ns, Timer=TSC
  [Host]       : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.2633.0
  LegacyJitX64 : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit LegacyJIT/clrjit-v4.7.2633.0;compatjit-v4.7.2633.0

Job=LegacyJitX64  Jit=LegacyJit  Platform=X64  
Runtime=Clr  

```
|             Method |     Mean |    Error |   StdDev | Scaled | ScaledSD |
|------------------- |---------:|---------:|---------:|-------:|---------:|
|        &#39;5000 rows&#39; | 467.2 ms | 6.908 ms | 6.124 ms |   1.00 |     0.00 |
| &#39;5000 rows 1 jint&#39; | 544.8 ms | 8.322 ms | 7.784 ms |   1.17 |     0.02 |
