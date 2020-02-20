using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.EntityFramework
{
    public interface IDiagnosticsRepository
    {
        void CreateLog(string message);
    }
}
