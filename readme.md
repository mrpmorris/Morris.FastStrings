# Morris.FastStrings

## Introduction
A C# proof of concept for the Boyer-Moore search algorithm.

Definitely not for production use, it's probably rubbish :)

## Benchmarks
| Method                               | Mean             | Error          | StdDev         | Median           | Gen0   | Allocated |
|------------------------------------- |-----------------:|---------------:|---------------:|-----------------:|-------:|----------:|
| IndexOfRareWordNearEndOfText         | 58,692,473.02 ns | 350,167.079 ns | 310,413.995 ns | 58,686,016.67 ns |      - |      60 B |
| FastIndexOfRareWordNearEndOfText     |  7,078,617.58 ns |  42,843.561 ns |  37,979.700 ns |  7,072,994.92 ns |      - |     197 B |
| IndexOfRareSentenceNearEndOfText     | 59,139,880.74 ns | 956,386.473 ns | 894,604.500 ns | 58,632,566.67 ns |      - |      60 B |
| FastIndexOfRareSentenceNearEndOfText |    586,954.06 ns |   8,492.786 ns |   7,528.634 ns |    585,051.95 ns |      - |    1569 B |
| IndexOfFirstWord                     |         33.14 ns |       0.202 ns |       0.189 ns |         33.16 ns |      - |         - |
| FastIndexOfFirstWord                 |         83.74 ns |       0.550 ns |       0.515 ns |         83.65 ns | 0.0305 |     384 B |
| IndexOfLastWord                      | 58,420,711.90 ns | 201,299.569 ns | 178,446.824 ns | 58,459,088.89 ns |      - |    1104 B |
| FastIndexOfLastWord                  |  6,438,596.72 ns |  20,346.089 ns |  19,031.745 ns |  6,445,930.47 ns |      - |     389 B |
| IndexOf10LeastCommonWords            | 10,525,765.98 ns | 208,513.392 ns | 470,649.474 ns | 10,771,901.56 ns |      - |       8 B |
| FastIndexOf10LeastCommonWords        |     17,125.74 ns |     321.483 ns |     330.139 ns |     17,143.10 ns | 0.4272 |    5408 B |
| IndexOf10MostCommonWords             | 10,207,043.16 ns | 204,135.238 ns | 481,170.772 ns | 10,515,960.94 ns |      - |       8 B |
| FastIndexOf10MostCommonWords         |      2,081.59 ns |      20.993 ns |      17.530 ns |      2,077.24 ns | 0.1411 |    1808 B |