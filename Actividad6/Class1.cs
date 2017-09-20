using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad6
{
    class Repetitions
    {
        private string word;
        private int repetitions;
        private HashSet<string> repeatsPerFile = new HashSet<string>();

        public Repetitions(string w, string fileName)
        {
            word = w;
            repetitions = 1;
            repeatsPerFile.Add(fileName);
        }

        public void addWord(string fileName)
        {
            repetitions++;
            repeatsPerFile.Add(fileName);
        }

        public override bool Equals(object rc)
        {
            return Equals(rc as Repetitions);
        }

        public string printScore()
        {
            return word + "  ;  " + repetitions + " repeticiones  ;  " + repeatsPerFile.Count + " archivos";
        }
    }
}
