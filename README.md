# Directory Size Calculator

This project is a simple console application written in C# that allows a user to specify up to three input directories. It then calculates the aggregate sum of all file sizes within the specified directories (recursively) and displays the size in a human-readable format (bytes, KB, MB, GB, TB).

## Features

- Allows a user to specify up to 3 input directories.
- Calculates the total size of all files within the specified directories.
- Displays the size in an appropriate unit (bytes, KB, MB, GB, TB).
- Handles each directory calculation on a separate thread for improved performance.
- Provides detailed error messages for any issues encountered during the calculation.

## Prerequisites

- .NET SDK (version 5.0 or higher recommended)
- Visual Studio 2019 or later (if using the Visual Studio IDE)

## Getting Started

### Clone the Repository

```bash
git clone https://github.com/GibranRaydan/SumDirectoriesSize.git
cd SumDirectoriesSize
```

## Using Visual Studio
Open the project in Visual Studio by double-clicking the .sln file.
Build the project by clicking on Build > Build Solution.
Run the project by clicking the Play button (or press F5).

```bash
cd path\to\SumDirectories
```

```bash
dotnet build
```

```bash
dotnet run --project SumDirectories
```
## Usage
When you run the application, you will be prompted to enter the paths for up to three directories. You can leave the input blank to skip any directory.

```bash
Enter path for directory 1 (leave blank to skip): C:\Users\example\directory
Enter path for directory 2 (leave blank to skip): C:\Users\example\directory
Enter path for directory 3 (leave blank to skip): C:\Users\example\directory
```
After entering the directory paths, the application will calculate and display the total size of all files within the specified directories.

Output Example:
```bash
The aggregate sum of all file sizes within the specified directories is: 8536123257 bytes.
The aggregate sum of all file sizes within the specified directories is: 8140.681511878967 Mb.
The aggregate sum of all file sizes within the specified directories is: 7.949884288944304 Gb.
The aggregate sum of all file sizes within the specified directories is: 0.007763558875922172 Tb.
```
## Notes
GetDirectorySize method:
  - Prompts the user up to three times for directory paths.
  - Validates if the entered path is a valid directory.
  - Re-prompts if an invalid directory is entered.
  - Stops prompting if the user enters a blank input.
  - Returns a list of valid directory paths.
    
GetDirectorySize method:
  - Recursively calculates the total size of all files in a specified directory.
  - Uses Directory.EnumerateFiles for efficient file enumeration.
  - Handles common errors like unauthorized access and missing directories gracefully.
  - Returns the total file size in bytes.
    
DataConverters methods
Each method takes a long value representing the number of bytes and returns a double value representing the size in the corresponding unit (MB, GB, TB).

Main method
  - Input Handling: Collects up to three valid directory paths from the user.
  - Parallel Processing: Uses tasks to calculate directory sizes concurrently.
  - Error Handling: Handles exceptions that occur during directory size calculations.
  - Result Aggregation: Aggregates the sizes from all tasks and converts the total size to various units.
  - Output: Displays the aggregate size in bytes, MB, GB, and TB.
