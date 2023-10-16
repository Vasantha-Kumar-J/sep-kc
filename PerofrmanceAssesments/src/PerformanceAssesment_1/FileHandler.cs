// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PerformanceAssessment_1
{
    /// <summary>
    /// Class to handle the files.
    /// </summary>
    internal class FileHandler : IDisposable
    {
        private bool _disposedValue;

        /// <summary>
        /// Method to read the data from the file.
        /// </summary>
        /// <param name="filePath">Path of the file.</param>
        /// <returns>Returns the content in the file.</returns>
        public string ReadData(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Method to write data into the file.
        /// </summary>
        /// <param name="filePath">Path of the file.</param>
        /// <param name="content">Content to be written.</param>
        public void WriteData(string filePath, string content, bool append)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append))
            {
                writer.WriteLine(content);
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Method to dispose the objects.
        /// </summary>
        /// <param name="disposing">True if dispose called by the program.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                }

                _disposedValue = true;
            }
        }
    }
}