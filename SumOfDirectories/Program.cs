using SumOfDirectories.Utils;

class Program
{
    static void Main()
    {
        InputDirectories inputDirectories = new InputDirectories();
        List<string> directories = inputDirectories.GetInputDirectories();

        if (directories.Count > 0)
        {
            List<Task<long>> tasks = new List<Task<long>>();

            foreach (string directory in directories)
            {
                Task<long> task = Task.Run(() => inputDirectories.GetDirectorySize(directory));
                task.ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        // Handle exception
                        Console.WriteLine($"An error occurred: {t.Exception}");
                    }
                });

                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            long totalSize = 0;
            foreach (var task in tasks)
            {
                totalSize += task.Result;
            }

            DataConverters converters = new DataConverters();
            double totalSizeMb = converters.ConvertBytesToMegabytes(totalSize);
            double totalSizeGb = converters.ConvertBytesToGigabytes(totalSize);
            double totalSizeTb = converters.ConvertBytesToTerabytes(totalSize);

            Console.WriteLine($"The aggregate sum of all file sizes within the specified directories is: {totalSize} bytes.");
            Console.WriteLine($"The aggregate sum of all file sizes within the specified directories is: {totalSizeMb} Mb.");
            Console.WriteLine($"The aggregate sum of all file sizes within the specified directories is: {totalSizeGb} Gb.");
            Console.WriteLine($"The aggregate sum of all file sizes within the specified directories is: {totalSizeTb} Tb.");
        }
        else
        {
            Console.WriteLine("No directories were entered.");
        }
    }
}