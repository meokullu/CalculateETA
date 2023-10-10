# CalculateETA

CalculateETA is a project to calculate estimated time to arrive on loops whether it is in single-thread or multi-thread applicatons.

![CalcETA14](https://repository-images.githubusercontent.com/569852870/a32b2e3b-99a7-41ee-8dcc-9992adba35d0)

[Check out on NuGet gallery](https://www.nuget.org/packages/CalculateETA/)

## Description

CalculateETA has methods to calculate estimated time to finish on loops. It calculates left count of iteration and multiply it with avarage passed time on the loop. On multi-thread applications, it has internal counter that increases everytime methods works via using that calculating left count of loop and multiply it with avarage passed time on the loop.

CalculateETA is optimized for CPU-intense applications.

## Listed Methods

See wiki page. [Listed Methods](https://github.com/meokullu/CalculateETA/wiki/Listed-Methods)

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
