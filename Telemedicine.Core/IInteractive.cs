using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemedicine
{
    /// <summary>
    /// 互動介面
    /// </summary>
    public interface IInteractive
    {
        T SingleSelection<T>(IEnumerable<T> options, Func<T, string> textResolver);
    }
}
