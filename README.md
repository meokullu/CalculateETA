## CalculateETA
[![CalculateETA](https://img.shields.io/nuget/v/CalculateETA.svg)](https://www.nuget.org/packages/CalculateETA/) [![CalculateETA](https://img.shields.io/nuget/dt/CalculateETA.svg)](https://www.nuget.org/packages/CalculateETA/) [![License](https://img.shields.io/github/license/meokullu/CalculateETA.svg)](https://github.com/meokullu/CalculateETA/blob/master/LICENSE)

CalculateETA is a project to calculate estimated time to arrive on loops whether it is in single-thread or multi-thread applicatons.

![CalculateETA](https://github.com/meokullu/CalculateETA/assets/4971757/006959d8-9736-4e67-a42a-1afd13e267a5)

[Download on NuGet gallery](https://www.nuget.org/packages/CalculateETA/)

### Description
CalculateETA has methods to calculate estimated time to finish on the loops. It calculates left count of the iteration and avarage passed time on the loop then multiply left count with avarage passed time. On multi-thread applications, it has internal counter that increases everytime methods are called. With using counter calculating left count of the loop and avarage passed time on the loop then multiply left count with avarage passed time.

CalculateETA is optimized for CPU-intense applications which methods are named Unsafe as suffix such as CalcUnsafe() and NameETAUnsafe().

### Example Usage

```
string CalcSTCPUIntense(int? index, int? totalIndex, double? totalElapsedTimeInMs)
{
    return NameETAUnsafe(CalcETAUnsafe(index, totalIndex, totalElapsedTimeInMs));
}
```
```
string CalcSTBetterVisual(int? index, int? totalIndex, double? totalElapsedTimeInMs)
{
    return NameETABetterVisual(CalcETA(index, totalIndex, totalElapsedTimeInMs));
}
```
```
string CalcMultiThread(uint? totalIndex, long? totalElapsedTicks)
{
    return NameETA(CalcETAHighDense(totalIndex, totalElapsedTicks));
}
```

To check listed methods, example of output visit wiki page. [CalculateETA Wiki](https://github.com/meokullu/CalculateETA/wiki)

### Version History
See [Changelog](https://github.com/meokullu/CalculateETA/blob/master/CHANGELOG.md)
  
### Task list
* Create an issue or check task list: [Issues](https://github.com/meokullu/CalculateETA/issues)

### Licence
This repository is licensed under the "MIT" license. See [MIT license](https://github.com/meokullu/CalculateETA/blob/master/LICENSE).

### Authors & Contributing
If you'd like to contribute, then contribute. [contributing guide](https://github.com/meokullu/CalculateETA/blob/master/CONTRIBUTING.md).

[![Contributors](https://contrib.rocks/image?repo=meokullu/CalculateETA)](https://github.com/meokullu/CalculateETA/graphs/contributors)

### Help
Twitter: Enes Okullu [@enesokullu](https://twitter.com/EnesOkullu)
