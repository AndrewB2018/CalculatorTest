using System;


namespace Common
{
    public class DiagnosticsConsole : IDiagnostics
    {

        public DiagnosticsConsole()
        {
            
        }

        public void Log(string message)
        {
            try
            {
                Console.WriteLine(message);
            }
            catch(Exception e)
            {
                throw new Exception($"Unable to log value:{message}");
            }
        }
    }
}
