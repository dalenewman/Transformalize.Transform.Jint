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

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.251)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2742192 Hz, Resolution=364.6718 ns, Timer=TSC
  [Host]       : .NET Framework 4.6.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.2633.0  [AttachedDebugger]
  LegacyJitX64 : .NET Framework 4.6.2 (CLR 4.0.30319.42000), 64bit LegacyJIT/clrjit-v4.7.2633.0;compatjit-v4.7.2633.0
  LegacyJitX86 : .NET Framework 4.6.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.2633.0

Jit=LegacyJit  Runtime=Clr  

```
|                       Method |          Job | Platform |     Mean |     Error |    StdDev | Scaled | ScaledSD |
|----------------------------- |------------- |--------- |---------:|----------:|----------:|-------:|---------:|
|              &#39;500 test rows&#39; | LegacyJitX64 |      X64 | 53.88 ms | 0.8055 ms | 0.7535 ms |   1.00 |     0.00 |
| &#39;500 rows with 3 transforms&#39; | LegacyJitX64 |      X64 | 76.89 ms | 1.6512 ms | 1.3788 ms |   1.43 |     0.03 |
|                              |              |          |          |           |           |        |          |
|              &#39;500 test rows&#39; | LegacyJitX86 |      X86 | 59.45 ms | 1.1400 ms | 1.3571 ms |   1.00 |     0.00 |
| &#39;500 rows with 3 transforms&#39; | LegacyJitX86 |      X86 | 80.10 ms | 1.7117 ms | 1.9712 ms |   1.35 |     0.04 |
