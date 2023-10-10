# CalculateETA

CalculateETA is a project to calculate estimated time to arrive on loops whether it is in single-thread or multi-thread applicatons.

![CalcETA14](https://repository-images.githubusercontent.com/569852870/a32b2e3b-99a7-41ee-8dcc-9992adba35d0)

[Check out on NuGet gallery](https://www.nuget.org/packages/CalculateETA/)

## Description

CalculateETA has methods to calculate estimated time to finish on loops. It calculates left count of iteration and multiply it with avarage passed time on the loop. On multi-thread applications, it has internal counter that increases everytime methods works via using that calculating left count of loop and multiply it with avarage passed time on the loop.

CalculateETA is optimized for CPU-intense applications.

## Listed Methods

### Counter Process
```
ResetCounter()
```
```
ResetCounterUint()
```

Returns true (value was not zero and resetted) or false (value was zero already) value. (bool)

### Single-thread methods

<sup>1</sup>
```
CalcETA(int? index, int? totalIndex, long? totalElapsedTimeInMs)
```
```
CalcETAUnsafe(int? index, int? totalIndex, long? totalElapsedTimeInMs)
```
```
CalcETA(uint? index, uint? totalIndex, long? totalElapsedTimeInMs)
```
```
CalcETAUnsafe(uint? index, uint? totalIndex, long? totalElapsedTimeInMs)
```

Returns null if any of parameter is null or returns estimated left time in milliseconds (long?)

* int?/uint? index: Current index of loop. Index must not be zero.
 
* int?/uint? totalIndex: Total index of loop.

* long? totalElapsedTimeInMs: Passed time of loop in milliseconds.

<sup>2</sup>
```
CalcETA(int? index, int? totalIndex, long? totalElapsedTicks, long? frequency)
```
```
CalcETAUnsafe(int? index, int? totalIndex, long? totalElapsedTicks, long? frequency)
```
```
CalcETAHighDense(int? index, int? totalIndex, long? totalElapsedTicks, long? frequency)
```
```
CalcETAHighDenseUnsafe(int? index, int? totalIndex, long? totalElapsedTicks, long? frequency)
```
```
CalcETA(uint? index, uint? totalIndex, long? totalElapsedTicks, long? frequency)
```
```
CalcETAUnsafe(uint? index, uint? totalIndex, long? totalElapsedTicks, long? frequency)
```
```
CalcETAHighDense(uint? index, uint? totalIndex, long? totalElapsedTicks, long? frequency)
```
```
CalcETAHighDenseUnsafe(uint? index, uint? totalIndex, long? totalElapsedTicks, long? frequency)
```

Returns null if any of parameter is null or returns estimated left time in milliseconds (long?)

* int?/uint? index: Current index of loop. Index must not be zero.
 
* int?/uint? totalIndex: Total index of loop.

* long? totalElapsedTicks: Passed ticks of loop.

* long? frequency: Tick of frequency. Frequency must not be zero.

<sup>3</sup>
```
CalcETA(int? index, int? totalIndex, TimeSpan? timeSpan)
```
```
CalcETAUnsafe(int? index, int? totalIndex, TimeSpan? timeSpan)
```
```
CalcETA(uint? index, uint? totalIndex, TimeSpan? timeSpan)
```
```
CalcETAUnsafe(uint? index, uint? totalIndex, TimeSpan? timeSpan)
```

Returns null if any of parameter is null or returns estimated left time in milliseconds (double?)

* int?/uint? index: Current index of loop. Index must not be zero.
 
* int?/uint? totalIndex: Total index of loop.

* TimeSpan? timeSpan: Passed time of loop in TimeSpan format.

### Multi-thread methods

<sup>4</sup>
```
CalcETA(int? totalIndex, long? totalElapsedTimeInMs)
```
```
CalcETAUnsafe(int? totalIndex, long? totalElapsedTimeInMs)
```
```
CalcETA(uint? totalIndex, long? totalElapsedTimeInMs)
```
```
CalcETAUnsafe(uint? totalIndex, long? TotalElapsedTimeInMs)
```

Returns null if any of parameter is null or returns estimated left time in milliseconds (long?)

* int?/uint? index: Current index of loop. Index must not be zero.

* long? totalElapsedTimeInMs: Passed time of loop in milliseconds.

<sup>5</sup>
```
CalcETA(int? totalIndex, long? totalElapsedTicks, long? frequency)
```
```
CalcETAUnSafe(int? totalIndex, long? totalElapsedTicks, long? frequency)
```
```
CalcETAHighDense(int? totalIndex, long? totalElapsedTicks, long? frequency)
```
```
CalcETAHighDenseUnsafe(int? totalIndex, long? totalElapsedTicks, long? frequency)
```
```
CalcETA(uint? totalIndex, long? totalElapsedTicks, long? frequency)
```
```
CalcETAUnsafe(uint? totalIndex, long? totalElapsedTicks, long? frequency)
```
```
CalcETAHighDense(uint? totalIndex, long? totalElapsedTicks, long? frequency)
```
```
CalcETAHighDenseUnsafe(uint? totalIndex, long? totalElapsedTicks, long? frequency)
```

Returns null if any of parameter is null or returns estimated left time in milliseconds (long?)

* int?/uint? index: Current index of loop. Index must not be zero.

* long? totalElapsedTicks: Passed ticks of loop.

* long? frequency: Tick of frequency. Frequency must not be zero.

<sup>6</sup>
```
CalcETA(int? totalIndex, TimeSpan? timeSpan)
```
```
CalcETAUnsafe(int? totalIndex, TimeSpan? timeSpan)
```
```
CalcETA(uint? totalIndex, TimeSpan? timeSpan)
```
```
CalcETAUnsafe(uint? totalIndex, TimeSpan? timeSpan)
```

Returns null if any of parameter is null or returns estimated left time in milliseconds (double?)

* int?/uint? index: Current index of loop. Index must not be zero.

* TimeSpan? timeSpan: Passed time of loop in TimeSpan format.

### Visualization of output 

```
TimeSpanETA(long? eTATimeInMs)
```
```
TimeSpanETAUnsafe(long eTATimeInMs)
```

Returns null if eTATimeInMs is null. Returns TimeSpan.Zero if etaTimeInMs is negative. Returns left time. Unsafe method returns left time directly on same format. (TimeSpan)

* long?: Estimated time to finish in milliseconds.

```
NumberFormatETA(long? eTATimeInMs)
```
```
NumberFormatETAUnsafe(long? eTATimeInMs)
```

Returns "Uncalculatable" if eTATimeInMs is null, returns "Negative" if eTATimeInMs is negative, returns "Too long" if eTATimeInMs is for more than a day, returns left time in {hh:mm:ss}. Unsafe method returns left time on same format. (string)

* long?: Estimated time to finish in milliseconds.

```
NameETA(long? eTATimeInMs)
```
```
NameETAUnsafe(long? eTATimeInMs)
```

Returns "Uncalculatable" if eTATimeInMs is null, returns "Negative" if eTATimeInMs is negative (string)

Returns {} second(s), {} minute(s) and {} second(s), {} hour(s) and {} minute(s), or {} day(s) and {} hour(s). Unsafe method returns left time directly on same format. 

* long?: Estimated time to finish in milliseconds.

```
NameETABetterVisual(long? eTATimeInMs)
```
```
NameETABetterVisualUnsafe(long? eTATimeInMs)
```

Returns "Uncalculatable" if eTATimeInMs is null, returns "Negative" if eTATimeInMs is negative (string)

Returns {} second/seconds, {} minute/minutes and {} second/seconds, {} hour/hours and {} minute/minutes, or {} day/days and {} hour/hours. Unsafe method returns left time directly on same format.

* long?: Estimated time to finish in milliseconds.

## Example Usage
```
public string CalcSingleThread(int? index, int? totalIndex, double? totalElapsedTimeInMs)
{
    return NameETA(CalcETA(index: index, totalIndex: totalIndex, totalElapsedTimeInMs: totalElapsedTimeInMs));
}
```
```
public string CalcMultiThread(uint? totalIndex, long? totalElapsedTicks)
{
    return NameETA(CalcETAHighDense(totalIndex: totalIndex, totalElapsedTicks: totalElapsedTicks));
}
```

### Single-Thread

* CalcETA<sup>1</sup>(5, 10, 1000) => (long)1000
* CalcETA<sup>2</sup>(5, 20, 50000000, 10000000) => (long)15
* CalcETA<sup>3</sup>(5, 20, new TimeSpan(0, 0, 1, 5) => (double)195
  
### Multi-Thread

* CalcETA<sup>4</sup>(10, 1000) => (long)1000
* CalcETA<sup>5</sup>(20, 50000000, 10000000) => (long)15
* CalcETA<sup>6</sup>(20, new TimeSpan(0, 0, 1, 5) => (double)195

### Output

* TimeSpanETA(90000) => (TimeSpan)00:01:30
* NumberFormatETA(90000) => "0:1:30"
* NameETA(90000) => "1 minute(s) and 30 second(s)" (recommended for high-CPU-intense algorithm)
* NameETABetterVisual(90000) => "1 minute and 30 seconds"(recommended for low-CPU-intense algorithm in order to offer better visual output)

## Version History

See [Changelog](https://github.com/meokullu/CalculateETA/blob/master/CHANGELOG.md)
  
## Task list

## Licence
[MIT license](https://github.com/meokullu/CalculateETA/blob/master/LICENSE)

## Authors
Twitter: Enes Okullu [@enesokullu](https://twitter.com/EnesOkullu)

## Help
Twitter: Enes Okullu [@enesokullu](https://twitter.com/EnesOkullu)
