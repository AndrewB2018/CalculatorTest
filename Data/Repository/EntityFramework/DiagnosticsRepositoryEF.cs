using Data.Context;
using Data.Repository.Interface;
using Entities.Models;
using System;

namespace Data.Repository.EntityFramework
{
    public class DiagnosticsRepositoryEF : IDiagnosticsRepository
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
