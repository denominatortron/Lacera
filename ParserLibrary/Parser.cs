using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParserLibrary.Entities;

namespace ParserLibrary
{

    public class Parser<T> 
        where T : IParseable, new()
    {
        public List<T> ParseCSV(string fileName) 
        {
            List<T> ret = new List<T>();
            using (StreamReader file = File.OpenText(fileName))
            {
                //read the first line and ignore it, it's just the header
                string line;
                line = file.ReadLine();
                if (String.IsNullOrEmpty(line))
                {
                    return ret;
                }

                //read and parse in the actual values now
                while ((line = file.ReadLine()) != null)
                {
                    T entity = ParseLine(line);
                    ret.Add(entity);
                }
            }

            return ret;
        }

        private T ParseLine(String line)
        {
            String[] inputs = line.Split(new char[] { ',' });
            T entity = new T();
            entity.Inflate(inputs);
            return entity;
        }
    }
}