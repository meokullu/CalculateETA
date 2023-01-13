# CalculateETA

CalculateETA is a project to calculate estimated time to arrive on loops whether it is in single-thread or multi-thread applicatons.

## Description

CalculateETA has methods to calculate estimated time to finish on loops. It calculates left count of iteration and multiply it with avarage passed time on the loop. On multi-thread applications, it has internal counter that increases everytime methods works via using that calculating left count of loop and multiply it with avarage passed time on the loop.

CalculateETA is optimized for cpu-intense applications.

## Listed Methods

### Counter Process
```
ResetCounter()
```

Returns true (value was not zero and resetted) or false (value was zero already) value. (bool)

### Single-thread methods

<sup>1</sup>
```
CalcETA(int index, int totalIndex, long totalElapsedTimeInMs)
```

Returns null if any of parameter is zero or returns estimated left time in milliseconds (long?)

* int index: Current index of loop.
 
* int totalIndex: Total index of loop.

* long totalElapsedTimeInMs: Passed time of loop in milliseconds.

<sup>2</sup>
```
CalcETA(int index, int totalIndex, long totalElapsedTicks, long tickFrequency)
```

Returns null if any of parameter is zero or returns estimated left time in milliseconds (long?)

* int index: Current index of loop.
 
* int totalIndex: Total index of loop.

* long totalElapsedTicks: Passed ticks of loop.

* long tickFrequency: Tick of frequency.

<sup>3</sup>
```
CalcETA(int index, int totalIndex, TimeSpan timeSpan)
```

Returns null if any of parameter is zero or returns estimated left time in milliseconds (double?)

* int index: Current index of loop.
 
* int totalIndex: Total index of loop.

* TimeSpan timeSpan: Passed time of loop in TimeSpan format.

### Multi-thread methods

<sup>4</sup>
```
CalcETA(int totalIndex, long totalElapsedTimeInMs)
```

Returns null if any of parameter is zero or returns estimated left time in milliseconds (long?)

* int index: Current index of loop.

* long totalElapsedTimeInMs: Passed time of loop in milliseconds.

<sup>5</sup>
```
CalcETA(int totalIndex, long totalElapsedTicks, long tickFrequency)
```

Returns null if any of parameter is zero or returns estimated left time in milliseconds (long?)

* int index: Current index of loop.

* long totalElapsedTicks: Passed ticks of loop.

* long tickFrequency: Tick of frequency.

<sup>6</sup>
```
CalcETA(int totalIndex, TimeSpan timeSpan)
```

Returns null if any of parameter is zero or returns estimated left time in milliseconds (double?)

* int index: Current index of loop.

* TimeSpan timeSpan: Passed time of loop in TimeSpan format.

### Visualization of output 

```
TimeSpanETA(long? eTATimeInMs)
```

Returns Time.Zero if eTATimeInMs is null or negative or left time. (TimeSpan)

* long?: Estimated time to finish in milliseconds.

```
NumberFormatETA(long? eTATimeInMs)
```

Returns "Uncalculatable" if eTATimeInMs is null, returns "Negative" if eTATimeInMs is negative, returns left time in {hh:mm:ss:msms}. (string)

* long?: Estimated time to finish in milliseconds.

```
NameETA(long? eTATimeInMs)
```

Returns "Uncalculatable" if eTATimeInMs is null, returns "Negative" if eTATimeInMs is negative (string)

Returns {} ms, {} second(s), {} minute(s) and {} second(s), {} hour(s) and {} minute(s), or {} day(s) and {} hour(s)

* long?: Estimated time to finish in milliseconds.

## Example Usage

### Single-Thread

<sup>1</sup>
```
CalcETA(5, 10, 1000) => (long)1000 
```
<sup>2</sup>
```
CalcETA(5, 20, 50000000, 10000000) => (long)15
```
<sup>3</sup>
```
CalcETA(5, 20, new TimeSpan(0, 0, 1, 5) => (double)195
```
### Multi-Thread

<sup>4</sup>
```
CalcETA(10, 1000) => (long)1000 
```
<sup>5</sup>
```
CalcETA(20, 50000000, 10000000) => (long)15
```
<sup>6</sup>
```
CalcETA(20, new TimeSpan(0, 0, 1, 5) => (double)195
```
### Output

```
TimeSpanETA(90000) => (TimeSpan)00:01:30
```
```
NumberFormatETA(90000) => "0:1:30:0"
```
```
NameETA(90000) => "1 minute(s) and 30 second(s)"
```
## Version History

* 1.2.1
  * Output folder is renamed as OutputDLL
  * Ready-to-use CalculateETA.dll and CalculateETA.xml are updated.

* 1.2.0
  * Fixed left time measurement bug.
  * When calculation left time TimeSpan is being used instead of conventional mathematical operations.

* 1.1.0
  * Added ResetCounter() method for reset counter that holds int variable to calculate ETA on multi-thread applications
  * See [commit change](https://github.com/meokullu/CalculateETA/commits/master) or See [release history](https://github.com/meokullu/CalculateETA/releases)
  * See [changelog](https://github.com/meokullu/CalculateETA/blob/master/CHANGELOG.MD)
  
* 1.0.0 Initial Release
  * See [commit change](https://github.com/meokullu/CalculateETA/commits/master) or See [release history](https://github.com/meokullu/CalculateETA/releases)
  * See [changelog](https://github.com/meokullu/CalculateETA/blob/master/CHANGELOG.MD)
  
## Task list
- [ ] Support Int64 (UInt) data type on CalcETA methods individually.

## Licence
No licence is required.

## Authors
Twitter: Enes Okullu [@enesokullu](https://twitter.com/EnesOkullu)

## Help
Twitter: Enes Okullu [@enesokullu](https://twitter.com/EnesOkullu)
