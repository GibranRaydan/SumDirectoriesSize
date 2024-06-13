namespace SumOfDirectories.Utils
{
    public class InputDirectories
    {
        public List<string> GetInputDirectories()
        {
            List<string> directories = new List<string>();

            for (int i = 1; i <= 3; i++)
            {
                Console.Write($"Enter path for directory {i} (leave blank to skip): ");

                // The @ symbol marks the string as a Verbatim string Literal
                // It would make sure that these two strings are treated as the same:
                // @"D:\Example\example" = "D:\\Example\\example" 

                string dirPath = @"" + Console.ReadLine().Trim();

                if (!string.IsNullOrEmpty(dirPath))
                {
                    if (Directory.Exists(dirPath))
                    {
                        directories.Add(dirPath);
                    }
                    else
                    {
                        Console.WriteLine($"The path '{dirPath}' is not a valid directory. Please try again.");
                        i--; // Stay on the same iteration to re-prompt for the directory
                    }
                }
                else
                {
                    break; // Stop asking if the input is blank
                }
            }

            return directories;
        }

        public long GetDirectorySize(string dirPath)
        {
            long totalSize = 0;

            try
            {
                string[] files = Directory.GetFiles(dirPath, "*", SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    totalSize += fileInfo.Length;
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Error: Unauthorized access to the directory '{dirPath}'. {ex.Message}");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"Error: Directory '{dirPath}' not found. {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calculating size for directory '{dirPath}': {ex.Message}");
            }

            return totalSize;
        }
    }
}