using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserLibrary.Entities
{
    public interface IParseable
    {
        void Inflate(String[] inputs);
    }
}
