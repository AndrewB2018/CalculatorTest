using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IDiagnosticsRepository
    {
        void CreateLog(string message);
    }
}
