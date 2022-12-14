# CalculateETA

CalculateETA is a project to calculate estimated time to arrive on loops whether it is in single-thread or multi-thread applicatons.

## Description

CalculateETA has methods to calculate estimated time to finish on loops. (Describe more)

CalculateETA is optimized for cpu-intense applications.

## Listed Methods

```
* ResetCounter()
```

Returns true (value was not zero and resetted) or false (value was zero already) value. (bool)

```
* CalcETA(int index, int totalIndex, long totalElapsedTimeInMs)
* CalcETA(int index, int totalIndex, long totalElapsedTicks, long tickFrequency)
* CalcETA(int index, int totalIndex, TimeSpan timeSpan)
```

Returns null or positive numerical values. (long? or double?)

* int index: Current index of loop.
 
* int totalIndex: Total index of loop.

* long totalElapsedTimeInMs:

* long totalElapsedTicks:

* long tickFrequency:

* TimeSpan timeSpan: 

```
* CalcETA(int totalIndex, long totalElapsedTimeInMs)
* CalcETA(int totalIndex, long totalElapsedTicks, long tickFrequency)
* CalcETA(int totalIndex, TimeSpan timeSpan)
```

Returns null or positive numerical values. (long? or double?)

* int index: Current index of loop.
 
* int totalIndex: Total index of loop.

* long totalElapsedTimeInMs:

* long totalElapsedTicks:

* long tickFrequency:

* TimeSpan timeSpan: 

```
* TimeSpanETA(long? eTATimeInMs)
```

Returns visualized time. (TimeSpan or string)

* long?: Estimated time to finish in milliseconds.

```
* NumberFormatETA(long? eTATimeInMs)
```

Returns visualized time. (TimeSpan or string)

* long?: Estimated time to finish in milliseconds.

```
* NameETA(long? eTATimeInMs)
```

Returns visualized time. (TimeSpan or string)

* long?: Estimated time to finish in milliseconds.

## Example Usage

###
 
## Version History

* 1.1.0
  * Added ResetCounter() method for reset counter that holds int variable to calculate ETA on multi-thread applications
  * See [commit change](https://github.com/meokullu/CalculateETA/commits/master) or See [release history](https://github.com/meokullu/CalculateETA/releases)
  * See CHANELOG.md

* 1.0.0 Initial Release
  * See [commit change](https://github.com/meokullu/CalculateETA/commits/master) or See [release history](https://github.com/meokullu/CalculateETA/releases)
  * See CHANGELOG.md
  
## Task list
- [ ] 
- [ ] 
- [ ]

## Licence
No licence is required.

## Authors
Twitter: [@enesokullu](https://twitter.com/EnesOkullu)

## Help
Twitter: [@enesokullu](https://twitter.com/EnesOkullu)
