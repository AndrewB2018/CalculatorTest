using Data.Context;
using Entities.Models;
using System;

namespace Data
{
    public class DiagnosticsRepository : IDiagnosticsRepository
    {
        private DiagnosticsContext db = new DiagnosticsContext();

        public void CreateLog(string message)
        {
            try
            {
                db.DiagnosticsLog.Add(new DiagnosticsLog {Message = message });
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Error creating a new log", e);
            }

        }

    }
}
