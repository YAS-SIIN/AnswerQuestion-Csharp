using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGMGroupTask_Csharp.Models;

public class QuestionAnswer
{
    public string Question { get; set; }
    public List<string> Answers { get; set; } = new List<string>();

}
