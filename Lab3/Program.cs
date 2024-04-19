namespace Lab3
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    class MatrixMultiplier
    {
        private volatile int[,] result;
        private readonly int[,] matrix1;
        private readonly int[,] matrix2;
        private readonly int numThreads;

        public MatrixMultiplier(int[,] matrix1, int[,] matrix2, int numThreads)
        {
            if (matrix1.GetLength(1) != matrix2.GetLength(0))
                throw new ArgumentException("Number of columns in first matrix must equal number of rows in second matrix");

            this.matrix1 = matrix1;
            this.matrix2 = matrix2;
            this.numThreads = numThreads;
            result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
        }

        public int[,] Multiply()
        {
            Thread[] threads = new Thread[numThreads];
            int rowsPerThread = result.GetLength(0) / numThreads;

            for (int i = 0; i < numThreads; i++)
            {
                int startRow = i * rowsPerThread;
                int endRow = (i == numThreads - 1) ? result.GetLength(0) : (i + 1) * rowsPerThread;

                threads[i] = new Thread(() => MultiplyRows(startRow, endRow));
                threads[i].Start();
            }

            foreach (Thread thread in threads)
                thread.Join();

            return result;
        }

        public int[,] ParallelMultiply()
        {
            ParallelOptions options = new ParallelOptions() { MaxDegreeOfParallelism = this.numThreads };
            Parallel.For(0, result.GetLength(0), options, x =>
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    int sum = 0;
                    for (int k = 0; k < matrix1.GetLength(1); k++)
                    {
                        sum += matrix1[x, k] * matrix2[k, j];
                    }
                    result[x, j] = sum;
                }
            });

            return result;
        }

        private void MultiplyRows(int startRow, int endRow)
        {
            for (int i = startRow; i < endRow; i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    int sum = 0;
                    for (int k = 0; k < matrix1.GetLength(1); k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }
                    result[i, j] = sum;
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = 1000;
            int[,] matrix1 = GenerateRandomMatrix(matrixSize, matrixSize);
            int[,] matrix2 = GenerateRandomMatrix(matrixSize, matrixSize);
            //Console.WriteLine("Matrix 1:");
            //PrintMatrix(matrix1);
            //Console.WriteLine("Matrix 2:");
            //PrintMatrix(matrix2);

            int numThreads = 4;

            MatrixMultiplier matrixMultiplier = new MatrixMultiplier(matrix1, matrix2, numThreads);
            
            // Threads
            Stopwatch stopwatch = Stopwatch.StartNew();
            int[,] result = matrixMultiplier.Multiply();
            stopwatch.Stop();

            TimeSpan timeElapsed = stopwatch.Elapsed;
            Console.WriteLine($"Time taken to multiply matrices with Threads: {timeElapsed.TotalMilliseconds} milliseconds");

            // Parallel.For
            stopwatch = Stopwatch.StartNew();
            result = matrixMultiplier.Multiply();
            stopwatch.Stop();

            timeElapsed = stopwatch.Elapsed;
            Console.WriteLine($"Time taken to multiply matrices with Parallel.For: {timeElapsed.TotalMilliseconds} milliseconds");

            //Console.WriteLine("Resulting Matrix:");
            //PrintMatrix(result);
        }

        static int[,] GenerateRandomMatrix(int rows, int cols)
        {
            Random random = new Random();
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = random.Next(10); // Max generated number
                }
            }
            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
