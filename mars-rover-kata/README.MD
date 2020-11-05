# Mars Rover Kata

## Referencias

<https://kata-log.rocks/mars-rover-kata>

## Project Setup

```bash
dotnet new nunit --name MarsRover.Test -f netcoreapp3.1
dotnet new classlib --name MarsRover -f netcoreapp3.1
dotnet add MarsRover.Test reference MarsRover
dotnet new sln
dotnet sln add MarsRover.Test MarsRover
```
