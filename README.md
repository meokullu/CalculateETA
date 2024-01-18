## CalculateETA
[![CalculateETA](https://img.shields.io/nuget/v/CalculateETA.svg)](https://www.nuget.org/packages/CalculateETA/) [![CalculateETA](https://img.shields.io/nuget/dt/CalculateETA.svg)](https://www.nuget.org/packages/CalculateETA/) [![License](https://img.shields.io/github/license/meokullu/CalculateETA.svg)](https://github.com/meokullu/CalculateETA/blob/master/LICENSE)

CalculateETA is a project to calculate estimated time to arrive on loops whether it is in single-thread or multi-thread applicatons.

![CalculateETA](https://repository-images.githubusercontent.com/569852870/a32b2e3b-99a7-41ee-8dcc-9992adba35d0)

[Download on NuGet gallery](https://www.nuget.org/packages/CalculateETA/)

### Description

CalculateETA has methods to calculate estimated time to finish on loops. It calculates left count of iteration and multiply it with avarage passed time on the loop. On multi-thread applications, it has internal counter that increases everytime methods works via using that calculating left count of loop and multiply it with avarage passed time on the loop.

CalculateETA is optimized for CPU-intense applications.

### Example Usage
```
public string CalcSingleThread(int? index, int? totalIndex, double? totalElapsedTimeInMs)
{
    return NameETA(CalcETA(index, totalIndex, totalElapsedTimeInMs));
}
```
```
public string CalcMultiThread(uint? totalIndex, long? totalElapsedTicks)
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