using FileOutputs;
using System;
using System.Collections.Generic;
using System.IO;

namespace Actividad6
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo(Outputs.getAllFiles());
            FileInfo[] Files = d.GetFiles("*.txt");

            string output_path6 = @"C:\Users\maple\Documents\9° Semester\CS13309_Archivos_HTML\a6_matricula.txt";
            string output;

            var watch = System.Diagnostics.Stopwatch.StartNew();
            List<string> sortedWords = new List<string>();
            Dictionary <String, Repetitions> repetitions = new Dictionary<string, Repetitions>();
            
            foreach (FileInfo file in Files)
            {
                output = "";
                var watchEach = System.Diagnostics.Stopwatch.StartNew();
                string htmlContent = File.ReadAllText(file.FullName);
                htmlContent.Trim();
                
                string[] eachWord = htmlContent.Split(' ');
                
                try
                {
                    foreach (string word in eachWord)
                    {
                        if (!string.IsNullOrEmpty(word))
                        {
                            if (!word.Equals(" "))
                            {
                                word.Replace(",", "")
                                    .Replace(".", "");

                                if (repetitions.ContainsKey(word))
                                {
                                    repetitions[word].addWord(file.Name);
                                }
                                else
                                {
                                    repetitions.Add(word, new Repetitions(word, file.Name));
                                }
                            }
                        }
                    }

                }
                catch (ArgumentNullException argExc)
                {
                    Console.WriteLine(argExc.StackTrace);
                }
                catch (KeyNotFoundException keyNotFoundExc)
                {
                    Console.WriteLine(keyNotFoundExc.StackTrace);
                }

                foreach (KeyValuePair<string, Repetitions> kvp in repetitions)
                {
                    output += "\n" + kvp.Value.printScore() + "\n";
                    Console.WriteLine(kvp.Value.printScore());
                }
                
                output += "\n" + file.Name + " finished in " + watchEach.Elapsed.TotalMilliseconds.ToString() + " ms";
                Console.WriteLine(output);
                watchEach.Stop();
                Outputs.output_print(output_path6, output);
            }

            output = "\nAll files sorted in\t" + watch.Elapsed.TotalMilliseconds.ToString() + " ms";
            Console.WriteLine(output);
            watch.Stop();
            Outputs.output_print(output_path6, output);

            Console.Read();
        }
    }
}
