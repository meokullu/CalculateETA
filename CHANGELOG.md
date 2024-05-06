## CalculateETA Changelog
[![CalculateETA](https://img.shields.io/nuget/v/CalculateETA.svg)](https://www.nuget.org/packages/CalculateETA/)

<!--
### [Unreleased]

#### Added

#### Changed

#### Removed
-->

### [3.0.0]
#### Added
* `SetTextMessageTurkish()` method added for setting all text messages that are used by naming ETA Turkish. [#78](https://github.com/meokullu/CalculateETA/issues/78)
* `SetTextMessageAbbrevations()` method added for setting all text messages thatare used by naming ETA English abbrevations. [#78](https://github.com/meokullu/CalculateETA/issues/78)
* `PreventSurgeByPercentage(long? eta, double discretePercentage)` method added into `Correction`
* `PreventSurgeByPercentage(double? eta, double discretePercentage)` method added into `Correction`
* `PreventSurgeByValueRepeatence(long? eta)` method added into `Correction`
* `PreventSurgeByValueRepeatence(double? eta)` method added into `Correction`
* `MultiThreading` and `Reporting` are added. Instance of each can be used repeatedly and simultaneously.

#### Changed
Following methods' parameter names are simplified. [#77](https://github.com/meokullu/CalculateETA/issues/77)
* On `CalcETAAsync(int? index, int totalIndex, long? totalElapsedTimeInMs)` method `totalElapsedTimeInMs` parameter is replaced with `elapsed`.
* On `CalcETAAsync(int totalIndex, long? totalElapsedTime)` method `totalElapsedTime` parameter is replaced with `elapsed`.
* On `NameETAAsync(long? etaTimeInMs)` method `etaTimeInMs` parameter is replaced with `eta`.

* On `NameETA(long? etaTimeInMs)` method `etaTimeInMs` parameter is replaced with `eta`.
* On `NameETA(double? etaTime)` method `etaTime` parameter is replaced with `eta`.
* On `NameETAUnsafe(long etaTimeInMs)` method `etaTimeInMs` parameter is replaced with `eta`.
* On `NameETAUnsafe(double etaTime)` method `etaTime` parameter is replaced with `eta`.
* On `NameETABetterVisual(long? etaTimeInMs)` method `etaTimeInMs` parameter is replaced with `eta`.
* On `NameETABetterVisual(double? etaTime)` method `etaTime` parameter is replaced with `eta`.
* On `NameETABetterVisualUnsafe(long etaTimeInMs)` method `ètaTimeInMs` is replaced with `eta`.
* On `NameETABetterVisualUnsafe(double etaTime)` method `etaTime` is replaced with `eta`.
* On `NumberFormatETA(long? etaTimeInMs)` method `etaTimeInMs` is replaced with `eta`.
* On `NumberFormatETA(double? etaTime)` method `etaTime` is replaced with `eta`.
* On `NumberFormatETAUnsafe(long etaTimeInMs)` method `etaTimeInMs` is replaced with `eta`.
* On `NumberFormatETAUnsafe(double etaTime)` method `etaTime` is replaced with `eta`.
* On `TimeSpanETA(long? etaTimeInMs)` method `etaTimeInMs` is replaced with `eta`.
* On `TimeSpanETA(double? etaTime)` method `etaTime` is replaced with `eta`.
* On `TimeSpanETAUnsafe(long etaTimeInMs)` method `etaTimeInMs` is replaced wtih `eta`.
* On `TimeSpanETAUnsafe(double etaTime)` method `etaTime` is replaced wìth `eta`.

* On `AddReport(this long? etaTime)` method `etaTime` is replaced with `eta`.
* On `AddReport(this double? etaTime)` method `etaTime` is replaced with `eta`.

* On `CalcETA(uint? totalIndex, long? totalElapsedTimeInMs)` method `totalElapsedTimeInMs` is replaced with `elapsed`.
* On `CalcETA(uint? totalIndex, long? totalElapsedTicks, long? frequency)` method `totalElapsedTicks` is replaced with `elapsedTicks`.
* On `CalcETA(int? totalIndex, long? totalElapsedTimeInMs)` method `totalElapsedTimeInMs` is replaced with `elapsed`.
* On `CalcETA(int? totalIndex, long? totalElapsedTicks, long? frequency)` method `totalElapsedTicks` is replaced with `elapsedTicks`.

* On `CalcETAUnsafe(uint? totalIndex, long? totalElapsedTimeInMs)` method `totalElapsedTimeInMs` is replaced with `elapsed`.
* On `CalcETAUnsafe(uint? totalIndex, long? totalElapsedTicks, long? frequency)` method `totalElapsedTicks` is replaced with `elapsedTicks`.
* On `CalcETAUnsafe(int? totalIndex, long? totalElapsedTimeInMs)` method `totalElapsedTimeInMs` is replaced with `elapsed`.
* On `CalcETAUnsafe(int? totalIndex, long? totalElapsedTicks, long? frequency)` method `totalElapsedTicks` is replaced `elapsedTicks`.

* On `CalcETA(uint? index, uint? totalIndex, long? totalElapsedTimeInMs)` method `totalElapsedTimeMs` is replaced with `elapsed`.
* On `CalcETA(uint? index, uint? totalIndex, long? totalElapsedTicks, long? frequency)` method `totalElapsedTicks` is replaced with `elapsedTicks`.
* On `CalcETA(int? index, int? totalIndex, long? totalElapsedTimeInMs)` method `totalElapsedTimeInMs` is replaced with `elapsed`.
* On `CalcETA(int? index, int? totalIndex, long? totalElapsedTicks, long? frequency)` method `totalElapsedTicks` is replaced with `elapsedTicks`.

* On `CalcETAUnsafe(uint? index, uint? totalIndex, long? totalElapsedTimeInMs)` method `totalElapsedTimeInMs` is replaced with `elapsed`.
* On `CalcETAUnsafe(uint? index, uint? totalIndex, long? totalElapsedTicks, long? frequency)` method `totalElapsedTicks` is replaced with `elapsedTicks`.
* On `CalcETAUnsafe(int? index, int? totalIndex, long? totalElapsedTimeInMs)` method `totalElapsedTimeInMs` is replaced with `elapsed`.
* On `CalcETAUnsafe(int? index, int? totalIndex, long? totalElapsedTicks, long? frequency)` method `totalElapsedTicks` is replaced with `elapsedTicks`.

* On `CalcETAHighDense(uint? index, uint? totalIndex, long? totalElapsedTicks, long? frequency)` method `totalElapsedTicks` is replaced with `elapsedTicks`.
* On `CalcETAHighDense(int? index, int? totalIndex, long? totalElapsedTicks, long? frequency)` method `totalElapsedTicks` is replaced with `elapsedTicks`.
* On `CalcETAHighDenseUnsafe(uint? index, uint? totalIndex, long? totalElapsedTicks, long? frequency)` method `totalElapsedTicks` is replaced with `elapsedTicks`.
* On `CalcETAHighDenseUnsafe(int? index, int? totalIndex, long? totalElapsedTicks, long? frequency)` method `totalElapsedTicks` is replaced with `elapsedTicks`.

* On `CalcETAHighDense(uint? totalIndex, long? totalElapsedTicks, long? frequency)` method `totalElapsedTicks` is replaced with `elapsedTicks`.
* On `CalcETAHighDense(int? totalIndex, long? totalElapsedTicks, long? frequency)` method `totalElapsedTicks` is replaced with `elapsedTicks`.
* On `CalcETAHighDenseUnsafe(uint? totalIndex, long? totalElapsedTicks, long? frequency)` method `totalElapsedTicks` is replaced with `elapsedTicks`
* On `CalcETAHighDenseUnsafe(int? totalIndex, long? totalElapsedTicks, long? frequency)` method `totalElapsedTicks` is replaced with `elapsedTicks`.

* `ResetCounterUint()` and `ResultCounter()` methods were unaccesible due to lack of marking them as static. Not they are marked as static.

#### Removed
* `NameETAUnSafe(double etaTime)` was marked as obsolote on version 2.4.0 with suggesting alternative as `NameETAUnsafe(double etaTime)` due to hypo. Now obsolote method is removed.

### [2.4.0]
#### Added
* `CalcMultiThread.cs` and `CalcSingleThread.cs` files are added.
* `ClearListInDouble()`, `ClearListInLong()`, `GetCountListInDouble()` and `GetCountListInLong()` method are added under `Report.cs`.
* `NameETA(double etaTime)`, `NameETAUnsafe(double etaTime)`, `NameETABetterVisual(double etaTime)`, `NameETABetterVisualUnsafe(double etaTime)` `NumberFormatETA(double etaTime)` and `NumberFormatETAUnsafe(double etaTime)` methods are added under `Visualization.cs`.

#### Changed
* `NameETAUnSafe(double etaTime)` renamed as `NameETAUnsafe(double etaTime)`.
* `NameETABetterVisual(long? etaTimeInMs)`, `NameETABetterVisual(double? etaTime)`, `NameETABetterVisualUnsafe(long etaTimeInMs)` and `NameETABetterVisualUnsafe(double etaTime)` was adding additional space.

### [2.3.0]
#### Added
* Under `Visualisation.cs` `TextMessage` class is added. `TextSecondOptionalPlural`, `TextMinuteOptionalPlural`, `TextHourOptionalPlural`, `TextDayOptionalPlural`, `TextSecond`, `TextMinute`, `TextHour`, `TextDay`, `TextMinutes`, `TextHours`, `TextDays`, `TextUncalculatable`, `TextNegative`, `TextTooLong`, `TextAnd` and `TextNumberFormatSeperator` can be set to choose what `NameETA(long? etaTimeInMs)`, `NameETAUnsafe(long etaTimeInMs)`, `NameETABetterVisual(long? etaTimeInMs)`, `NameETABetterVisualUnsafe(long etaTimeInMs)`, `NumberFormatETA(long? etaTimeInMs)` and `NumberFormatETAUnsafe(long etaTimeInMs)` methods create string to return.

### [2.2.0]
#### Added
* Created reporting extension module. Following methods are added. `AddReport(long? eta)`, `AddReport(double? eta)`, `GetDoubleListReport()`, `GetLongListReport()` [#35](https://github.com/meokullu/CalculateETA/issues/35)
* Following `async` methods are added. `CalcETAAsync(int? index, int? totalIndex, long? totalElapsedTimeInMs)`, `CalcETAAsync(int? totalIndex, long? totalElapsedTimeInMs)` [#38](https://github.com/meokullu/CalculateETA/issues/38)

#### Changed
* `Counter.cs`, `HighDense.cs`, `Visualization.cs` are added and certain methods are moved.
* New design README.
* New design CHANGELOG.

### [2.1.2]
#### Changed
* Methods are sorted.

### [2.1.1]
#### Added
* Wiki pages are added. Wiki link is under example of use section.

#### Changed
* Update README with cleaner view. Changelog link is added under task list section.
* Task list section is removed under README.
* Update CHANGELOG with cleaner view.
* LICENCE.md file renamed as LICENCE.
* Package tags are added.

### [2.1.0]
#### Added
* Multi-target frameworks support. (net6.0; net7.0; net461; netcoreapp3.1; netstandard2.0)

#### Removed
* `OutputDLL` folder is removed.

### [2.0.1]
#### Removed
* Unnecessary casting removed.

### [2.0.0]
#### Changed
* Framework is changed from .Net Core 3.1 to .Net 7.0

### [1.7.1]
#### Changed
* Methods are sorted and splited into three (Single-thread, multi-thread and common visual formatting).
* Internal parameters naming fixed to avoid confusion.
* Comments are improved to describe reason of usage better.

### [1.7.0]
#### Added
* `CalcETAHighDense(int, uint)`, `CalcETAHighDenseUnsafe(int, uint)` methods are added. Among available methods for CPU-intense applications, new four methods can be used for precision on fast iterations.

### [1.6.2]
#### Changed
* `NumberFormatETA()` and `NumberFormatETAUnsafe()` methods no longer return milliseconds as a part of return string.
* `NumberFormatETA()` now returns `"Too long"` if input parameter value causes calculations for more than a day.

### [1.6.1]
#### Changed
* Fixed calculations on `CalcETA(int, int, TimeSpan)`, `CalcETA(uint, uint, TimeSpan)`, `CalcETAUnsafe(int, int, TimeSpan)` and `CalcETAUnsafe(uint, uint, TimeSpan)`.
* Fixed wrong parameter name on methods that use `totalElapsedTicks` and `frequency` as parameters.
* Added missing return summaries.
* Added warning for `frequency` parameter should be provided with `ticksPerMilliseconds`.

### [1.6.0]
#### Added
* Added `TimeSpanETAUnsafe()`, `NumberFormatETAUnsafe()`, `NameETAUnsafe()` and `NameETABetterVisualUnsafe()` methods.

#### Changed
* `totalSeconds` variables renamed into `elapsedSeconds`.
* Additional checking is added for value check of `index` and `frequency` on available safe methods.

### [1.5.0]
#### Added
* Added comments to every lines of code.
* Added `DivideByZeroException` to methods when input parameter `index` is not longer being checkes for it was `zero`.

#### Changed
* `CalcETA()` and `CalcETAUnsafe()` methods, now using nullable parameters.
* `CalcETA()` methods checks if given parameters are `null` instead of `zero` value.
* `CalcETA(..., long tickFrequency)` method is now using `CalcETA(..., long? frequency)`
* `avarageElapsedTime` variable is renamed into `avarageElapsedTimeInMs`.
* `seconds` variable is renamed into `elapsedSeconds`.
* `TimeSpanETA()` now returns `null` instead of `TimeSpan.Zero` when input parameter is `null` instead of it is `zero` value.
* `TimeSpanETA()`, `NumberFormatETA()`, `NameETA()`, `NameETABetterVisual()` now uses new `TimeSpan(ticks: )` instead of `new TimeSpan(0,0,0,0, milliseconds: (int)eTATimeInMs)`

#### Removed
  * `NameETA()` and `NameETABetterVisual()` are no longer returning result as `$"{etaTimeInMs:0} ms"` if input parameters is shorter then a second.

### [1.4.0]
#### Added
 * Added `NameETABetterVisual()` for better reability on algorithms.

### [1.3.0]
#### Added
 * Added `ReserCounterUint()` for multi-threaded iterations that use `uint` as `index` or `totalindex`.
 * Added Unsafe methods for all methods to increase performance.
 * Added methods uses `uint` data type rather than `int` to increase range.

### [1.2.1]
#### Changed
* Output folder is renamed as OutputDLL
* Ready-to-use CalculateETA.dll and CalcualteETA.xml updated.
  
### [1.2.0]
#### Changed
 * `NameETA()` now returns left hour data while left time is more than one day.

#### Fixed
 * Bug on left time measurement is fixed.

### [1.1.0]
#### Added
 * Added `ResetCounter()` method for reset the counter that hold int variable to calculate ETA on multi-thread applications.

### [1.0.0]
Initial version.
