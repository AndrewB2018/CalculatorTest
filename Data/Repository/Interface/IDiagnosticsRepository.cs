using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.Interface
{
    public interface IDiagnosticsRepository
    {
        void CreateLog(string message);
    }
}
