using Data;
using System;


namespace Diagnostics
{
    public class DiagnosticsDatabase : IDiagnostics
    {
        private readonly IDiagnosticsRepository _diagnosticsRepo;

        public DiagnosticsDatabase(IDiagnosticsRepository diagnosticsRepo)
        {
            _diagnosticsRepo = diagnosticsRepo;
        }

        public void Log(string message)
        {
            try
            {
                _diagnosticsRepo.CreateLog(message);
            }
            catch(Exception e)
            {
                throw new Exception($"Unable to log value:{message}");
            }
        }
    }
}
