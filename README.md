# CalculateETA

CalculateETA is a project to calculate estimated time to arrive on loops whether it is in single-thread or multi-thread applicatons.

![CalcETA14](https://repository-images.githubusercontent.com/569852870/a32b2e3b-99a7-41ee-8dcc-9992adba35d0)

[Check out on NuGet gallery](https://www.nuget.org/packages/CalculateETA/)

## Description

CalculateETA has methods to calculate estimated time to finish on loops. It calculates left count of iteration and multiply it with avarage passed time on the loop. On multi-thread applications, it has internal counter that increases everytime methods works via using that calculating left count of loop and multiply it with avarage passed time on the loop.

CalculateETA is optimized for CPU-intense applications.

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

To check listed methods, example of output visit wiki page. [Listed Methods](https://github.com/meokullu/CalculateETA/wiki/Listed-Methods)

## Version History

See [Changelog](https://github.com/meokullu/CalculateETA/blob/master/CHANGELOG.md)
  
## Task list

## Licence
[MIT license](https://github.com/meokullu/CalculateETA/blob/master/LICENSE)

## Authors
Twitter: Enes Okullu [@enesokullu](https://twitter.com/EnesOkullu)

## Help
Twitter: Enes Okullu [@enesokullu](https://twitter.com/EnesOkullu)
