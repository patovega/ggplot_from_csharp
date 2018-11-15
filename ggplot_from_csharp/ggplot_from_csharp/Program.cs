using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ggplot_from_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("load data...");
            var data = CreateDataClass();
            string path = @"C:\Users\patricio\Desktop\ggplot_from_csharp\";
            string filename = "example";
            string extension = ".csv";
            Console.WriteLine("Creatin CSV...");
            WriteCSV(data, path + filename + extension);
            Console.WriteLine("Csv create in " + path  + " ...");
            Console.WriteLine("Execute cmd for create plot...");
            CreatePlot(filename);
            Console.WriteLine("Plot create!!");
            Console.WriteLine("Press any key for close the program.");
            Console.ReadLine();
        }

        /// <summary>
        /// This method use CMD for call Rscript.exe and execute the file ggplot_from_csharp.R
        /// The file received by ARGS the name of the csv file and create a plot with the same name.
        /// </summary>
        /// <param name="filename">string name of csv create in x folder for create a png file with the same name.</param>
        private static void CreatePlot(string filename)
        {
            try
            {
                var processStartInfo = new ProcessStartInfo();

                processStartInfo.WorkingDirectory = @"C:\\Program Files\\R\\R-3.5.1\\bin\\x64\\";
                processStartInfo.FileName = "cmd.exe";
                //the file ggplot_from_csharp.r must be exist in the WorkingDirectory
                //"C:\\Program Files\\R\\R-3.5.1\\bin\\x64\\"
                processStartInfo.Arguments = "/C Rscript.exe ggplot_from_csharp.R " + filename;

                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process proc = Process.Start(processStartInfo);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        /// <summary>
        /// Wrike a CSV delimited by ; from a list.
        /// </summary>
        /// <typeparam name="T">List<dataclass></typeparam>
        /// <param name="items">list<object></param>
        /// <param name="path">string,with path/filename</param>
        private static void WriteCSV<T>(IEnumerable<T> items, string path)
        {
            Type itemType = typeof(T);
            var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                .OrderBy(p => p.Name);

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(string.Join(";", props.Select(p => p.Name)));

                foreach (var item in items)
                {
                    writer.WriteLine(string.Join(";", props.Select(p => p.GetValue(item, null))));
                }
            }
        }

        /// <summary>
        /// Create a data for the class DataClass
        /// </summary>
        /// <returns> List<DataClass> </returns>
        private static List<DataClass> CreateDataClass()
        {
            var listOfData = new List<DataClass>();

            try
            {
                int i = 0;

                for(i = 0; i <= 10; i++ )
                {
                    var dataClass = new DataClass();

                    if (i % 2 == 0)
                    {
                        dataClass.name = "A" ;
                    }
                    else
                    {
                        dataClass.name = "B";
                    }
                   
                    dataClass.value = i;
                    dataClass.timestamp = DateTime.Now;
                    listOfData.Add(dataClass);
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return listOfData;
        } 
    }
}
