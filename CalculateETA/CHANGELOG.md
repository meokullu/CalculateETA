## CalculateETA Changelog

<!--
## [Unreleased]

### Added

### Changed

### Removed
-->

## [2.x.y] (Upcoming)
*

## [2.1.0]

### Added
* Multi-target frameworks support. (net6.0; net7.0; net461; netcoreapp3.1; netstandard2.0)

### Removed
* `OutputDLL` folder is removed.

## [2.0.1]

### Removed
* Unnecessary casting removed.

## [2.0.0]

### Changed
* Framework is changed from .Net Core 3.1 to .Net 7.0

## [1.7.1]

### Changed
* Methods are sorted and splited into three (Single-thread, multi-thread and common visual formatting).
* Internal parameters naming fixed to avoid confusion.
* Comments are improved to describe reason of usage better.

## [1.7.0]

### Added
* `CalcETAHighDense(int, uint)`, `CalcETAHighDenseUnsafe(int, uint)` methods are added. Among available methods for CPU-intense applications, new four methods can be used for precision on fast iterations.

## [1.6.2]

### Changed
* `NumberFormatETA()` and `NumberFormatETAUnsafe()` methods no longer return milliseconds as a part of return string.
* `NumberFormatETA()` now returns `"Too long"` if input parameter value causes calculations for more than a day.

## [1.6.1]

### Changed
* Fixed calculations on `CalcETA(int, int, TimeSpan)`, `CalcETA(uint, uint, TimeSpan)`, `CalcETAUnsafe(int, int, TimeSpan)` and `CalcETAUnsafe(uint, uint, TimeSpan)`.
* Fixed wrong parameter name on methods that use `totalElapsedTicks` and `frequency` as parameters.
* Added missing return summaries.
* Added warning for `frequency` parameter should be provided with `ticksPerMilliseconds`.

## [1.6.0]

### Added
* Added `TimeSpanETAUnsafe()`, `NumberFormatETAUnsafe()`, `NameETAUnsafe()` and `NameETABetterVisualUnsafe()` methods.

### Changed
* `totalSeconds` variables renamed into `elapsedSeconds`.
* Additional checking is added for value check of `index` and `frequency` on available safe methods.

## [1.5.0]

### Added
* Added comments to every lines of code.
* Added `DivideByZeroException` to methods when input parameter `index` is not longer being checkes for it was `zero`.

### Changed
* `CalcETA()` and `CalcETAUnsafe()` methods, now using nullable parameters.
* `CalcETA()` methods checks if given parameters are `null` instead of `zero` value.
* `CalcETA(..., long tickFrequency)` method is now using `CalcETA(..., long? frequency)`
* `avarageElapsedTime` variable is renamed into `avarageElapsedTimeInMs`.
* `seconds` variable is renamed into `elapsedSeconds`.
* `TimeSpanETA()` now returns `null` instead of `TimeSpan.Zero` when input parameter is `null` instead of it is `zero` value.
* `TimeSpanETA()`, `NumberFormatETA()`, `NameETA()`, `NameETABetterVisual()` now uses new `TimeSpan(ticks: )` instead of `new TimeSpan(0,0,0,0, milliseconds: (int)eTATimeInMs)`

### Removed
  * `NameETA()` and `NameETABetterVisual()` are no longer returning result as `$"{etaTimeInMs:0} ms"` if input parameters is shorter then a second.

## [1.4.0]

### Added
 * Added `NameETABetterVisual()` for better reability on algorithms.

## [1.3.0]

### Added
 * Added `ReserCounterUint()` for multi-threaded iterations that use `uint` as `index` or `totalindex`.
 * Added Unsafe methods for all methods to increase performance.
 * Added methods uses `uint` data type rather than `int` to increase range.

## [1.2.1]

### Changed
* Output folder is renamed as OutputDLL
* Ready-to-use CalculateETA.dll and CalcualteETA.xml updated.
  
## [1.2.0]

### Changed
 * `NameETA()` now returns left hour data while left time is more than one day.

### Fixed
 * Bug on left time measurement is fixed.

## [1.1.0]

### Added
 * Added `ResetCounter()` method for reset the counter that hold int variable to calculate ETA on multi-thread applications.

## [1.0.0]
Initial version
