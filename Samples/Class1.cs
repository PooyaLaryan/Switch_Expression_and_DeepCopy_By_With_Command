using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples
{
    internal class Class1
    {
        public void Test()
        {
            var list = Enumerable.Range(1,10).Select(x => new ToDo { Number = x}).ToList();

            var todoResult = list.FirstOrDefault(x=> x.Number == 2) is { } todo1 ? todo1 : new ToDo {  Number = 1};

            var todo2 = list.FirstOrDefault(x => x.Number == 2);
            var todoResult2 = todo2 != null ? todo2 : new ToDo {Number = -1};
        }
    }
}
