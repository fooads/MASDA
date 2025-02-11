# MASDA - Mirae Asset Securities Demo Application
This repository contains the source code and working executables for
MASDA Client and MASDA Server.
## How to run
In order to run MASDA Client and MASDA Server applications, you can either:
1. Run the already working .exe files
2. Build the applications yourself

To run MASDA Client, download `win-publish.zip` archive, unzip it, and run
`MASDA Client.exe`.
Alternatively, download `MASDA Client` folder, cd into it, and run
`dotnet publish -c Release -r win-x64 --self-contained true -o win-publish`,
which will produce the `win-publish` folder containing the executable.

To run MASDA Server, download `publish.zip` archive, unzip it, and run
`MASDA Server.exe`.
Alternatively, download `MASDA Server` folder, cd into it, and run
`dotnet publish -c Release -o publish`,
which will produce the `publish` folder containing the executable.
