namespace PerformanceAssessment_1
{
    internal class Loggers
    {
        Utility utility = new Utility();
        FileHandler fileHandler = new FileHandler();

        public void Log(string message, int ErrorValue)
        {
            if (ErrorValue == 0)
            {
                utility.PrintMessageInGreen(message);
            }
            else if (ErrorValue == 1)
            {
                utility.PrintMessageInOrange(message);
            }
            else if (ErrorValue == -1)
            {
                utility.PrintMessageInOrangeBackground(message);
            }
            else
            {
                utility.PrintMessageInRed(message);
            }

            fileHandler.WriteData(Path.Combine(Program._docPath, "Logger.txt"), $"Error {ErrorValue}: {message}", true);
        }
    }
}