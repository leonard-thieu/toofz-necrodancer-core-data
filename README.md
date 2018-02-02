# toofz Data

[![Build status](https://ci.appveyor.com/api/projects/status/cowbksjnikl2928m/branch/master?svg=true)](https://ci.appveyor.com/project/leonard-thieu/toofz-necrodancer-entityframework/branch/master)
[![codecov](https://codecov.io/gh/leonard-thieu/toofz-data/branch/master/graph/badge.svg)](https://codecov.io/gh/leonard-thieu/toofz-data)
[![MyGet](https://img.shields.io/myget/toofz/v/toofz.Data.svg)](https://www.myget.org/feed/toofz/package/nuget/toofz.Data)

## Overview

**toofz Data** serves as the data access layer (DAL) for **toofz**. Retrieving data is done through an Entity Framework Core Code First model. 
Modifying data uses a combination of `SqlBulkCopy` and raw SQL for performant bulk inserting and upserting.

---

**toofz Data** is a component of **toofz**. 
Information about other projects that support **toofz** can be found in the [meta-repository](https://github.com/leonard-thieu/toofz-necrodancer).

## Installing via NuGet

Add a NuGet.Config to your solution directory with the following content:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="toofz" value="https://www.myget.org/F/toofz/api/v3/index.json" />
  </packageSources>
</configuration>
```

```powershell
Install-Package 'toofz.Data'
```

### Dependents

* [toofz API](https://github.com/leonard-thieu/api.toofz.com)
* [toofz Leaderboards Service](https://github.com/leonard-thieu/leaderboards-service)
* [toofz Daily Leaderboards Service](https://github.com/leonard-thieu/daily-leaderboards-service)
* [toofz Players Service](https://github.com/leonard-thieu/players-service)
* [toofz Replays Service](https://github.com/leonard-thieu/replays-service)

### Dependencies

* [toofz NecroDancer Core](https://github.com/leonard-thieu/toofz-necrodancer-core)
* [toofz Build](https://github.com/leonard-thieu/toofz-build)

## Requirements

* .NET Framework 4.6.1
* SQL Server

## Contributing

Contributions are welcome for toofz Data.

* Want to report a bug or request a feature? [File a new issue](https://github.com/leonard-thieu/toofz-steam/issues).
* Join in design conversations.
* Fix an issue or add a new feature.
  * Aside from trivial issues, please raise a discussion before submitting a pull request.

### Development

#### Requirements

* Visual Studio 2017

#### Getting started

Open the solution file and build. Use Test Explorer to run tests.

## License

**toofz Data** is released under the [MIT License](LICENSE).
