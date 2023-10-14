using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRAF
{
    public record Task(string name, string description,int requiredHours,int priority,List<string>skills);
    
}