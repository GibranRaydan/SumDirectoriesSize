namespace SumOfDirectories.Utils
{
    internal class DataConverters
    {
        public double ConvertBytesToMegabytes(long bytes)
        {
            return bytes / (1024.0 * 1024.0);
        }

        public double ConvertBytesToGigabytes(long bytes)
        {
            return bytes / (1024.0 * 1024.0 * 1024.0);
        }

        public double ConvertBytesToTerabytes(long bytes)
        {
            return bytes / (1024.0 * 1024.0 * 1024.0 * 1024.0);
        }
    }
}
