# Morris.FastStrings

## Introduction
A C# proof of concept for the Boyer-Moore search algorithm.

Definitely not for production use, it's probably rubbish :)

## Benchmarks
| Method                               | Mean             | Error          | StdDev         | Median           | Gen0   | Allocated |
|------------------------------------- |-----------------:|---------------:|---------------:|-----------------:|-------:|----------:|
| IndexOfRareWordNearEndOfText         | 58,596,297.22 ns | 302,474.513 ns | 236,152.204 ns | 58,680,872.22 ns |      - |      60 B |
| FastIndexOfRareWordNearEndOfText     |  7,246,820.70 ns |  78,753.614 ns |  69,813.028 ns |  7,239,502.34 ns |      - |     197 B |
| IndexOfRareSentenceNearEndOfText     | 60,148,543.59 ns | 291,673.203 ns | 243,560.334 ns | 60,255,588.89 ns |      - |      60 B |
| FastIndexOfRareSentenceNearEndOfText |    493,675.06 ns |   7,141.818 ns |   6,331.036 ns |    491,012.43 ns |      - |    1568 B |
| IndexOfFirstWord                     |         34.64 ns |       0.090 ns |       0.084 ns |         34.66 ns |      - |         - |
| FastIndexOfFirstWord                 |         85.38 ns |       1.577 ns |       1.475 ns |         85.21 ns | 0.0305 |     384 B |
| IndexOfLastWord                      | 58,238,794.44 ns | 148,803.441 ns | 131,910.375 ns | 58,251,855.56 ns |      - |    1104 B |
| FastIndexOfLastWord                  |  6,508,958.46 ns |  47,361.820 ns |  44,302.275 ns |  6,509,921.48 ns |      - |     389 B |
| IndexOf10LeastCommonWords            | 10,610,773.22 ns | 211,941.438 ns | 465,216.595 ns | 10,794,485.94 ns |      - |       8 B |
| FastIndexOf10LeastCommonWords        |     18,961.16 ns |     368.121 ns |     423.928 ns |     19,036.60 ns | 0.4272 |    5408 B |
| IndexOf10MostCommonWords             | 10,226,015.14 ns | 204,060.530 ns | 500,563.957 ns | 10,464,567.19 ns |      - |       8 B |
| FastIndexOf10MostCommonWords         |      2,118.63 ns |      10.972 ns |       9.726 ns |      2,116.64 ns | 0.1411 |    1808 B |