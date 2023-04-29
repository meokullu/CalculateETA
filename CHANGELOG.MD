# Changelog

## [Unreleased]

### Added

### Changed

### Removed

## [1.5.0]

### Added
* Added comments to every lines of code.
* Added DivideByZeroException to methods when input parameter index is not longer being checkes for it was zero.

### Changed
* CalcETA() and CalcETAUnsafe() methods, now using nullable parameters.
* CalcETA() methods checks if given parameters are null instead of 0 value.
* CalcETA(..., long tickFrequency) method is now using CalcETA(..., long? frequency)
* avarageElapsedTime variable is renamed into avarageElapsedTimeInMs.
* seconds variable is renamed into elapsedSeconds.
* TimeSpanETA() now returns null instead of TimeSpan.Zero when input parameter is null instead of it is zero value.
* TimeSpanETA(), NumberFormatETA(), NameETA(), NameETABetterVisual() now uses new TimeSpan(ticks: ) instead of new TimeSpan(0,0,0,0, milliseconds: (int)eTATimeInMs)

### Removed
  * NameETA() and NameETABetterVisual() are no longer returning result as $"{etaTimeInMs:0} ms" if input parameters is shorter then a second.

## [1.4.0]

### Added
 * Added NameETABetterVisual() for better reability on algorithms.

## [1.3.0]

### Added
 * Added ReserCounterUint() for multi-threaded iterations that use uint as index or totalindex.
 * Added [Unsafe] methods for all methods to increase performance.
 * Added methods uses uint data type rather than int to increase range.

## [1.2.0]

### Changed
 * NameETA() now returns left hour data while left time is more than one day.
### Fixed
 * Bug on left time measurement is fixed.

## [1.1.0]

### Added
 * Added ResetCounter() method for reset the counter that hold int variable to calculate ETA on multi thread applications.

## [1.0.0]
Initial version
