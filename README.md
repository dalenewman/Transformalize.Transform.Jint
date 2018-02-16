### Overview

This adds js, javascript, and jint transforms to Transformalize using [Jint](https://github.com/sebastienros/jint).  It is a plug-in compatible with Transformalize 0.3.3-beta.

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
                <add name="evaluated" t='js(text + " " + number)' />
            </calculated-fields>
        </add>
    </entities>
</cfg>
```

This produces `SomethingWonderful 2`

### Benchmark

``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.125)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2742187 Hz, Resolution=364.6724 ns, Timer=TSC
  [Host]       : .NET Framework 4.6.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.2600.0
  LegacyJitX64 : .NET Framework 4.6.2 (CLR 4.0.30319.42000), 64bit LegacyJIT/clrjit-v4.7.2600.0;compatjit-v4.7.2600.0
  LegacyJitX86 : .NET Framework 4.6.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.2600.0

Jit=LegacyJit  Runtime=Clr  

```
|                       Method |          Job | Platform |     Mean |     Error |    StdDev | Scaled | ScaledSD |
|----------------------------- |------------- |--------- |---------:|----------:|----------:|-------:|---------:|
|              &#39;500 test rows&#39; | LegacyJitX64 |      X64 | 71.56 ms | 1.4203 ms | 1.5786 ms |   1.00 |     0.00 |
| &#39;500 rows with 3 transforms&#39; | LegacyJitX64 |      X64 | 90.41 ms | 0.6649 ms | 0.5894 ms |   1.26 |     0.03 |
|                              |              |          |          |           |           |        |          |
|              &#39;500 test rows&#39; | LegacyJitX86 |      X86 | 76.07 ms | 1.2432 ms | 1.1629 ms |   1.00 |     0.00 |
| &#39;500 rows with 3 transforms&#39; | LegacyJitX86 |      X86 | 93.41 ms | 0.5980 ms | 0.5594 ms |   1.23 |     0.02 |
