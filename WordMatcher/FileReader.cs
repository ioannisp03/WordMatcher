using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class FileReader
    {
        public string[] Read(string filename)
        {

            try
            {
                // Read all lines inside the files
                return File.ReadAllLines(filename);
            }

            //Catch any input/output errors
            catch (IOException e)
            {
                
                Console.WriteLine("Error reading file: " + e.Message);

            }


            return null;
        }
    }
}
