using System;
using System.Diagnostics;

namespace _App.Scripts.Libs.Debug.FuncAnalize
{
    public class PerfScanner : IDisposable
    {
        private readonly string _name;
        private readonly Stopwatch _stopwatch;
        
        public PerfScanner(string name)
        {
            _name = name;
            _stopwatch = Stopwatch.StartNew();    
        }
        
        public void Dispose()
        {
            _stopwatch.Stop();
            UnityEngine.Debug.Log($"#_name# Elapsed time {_stopwatch.ElapsedMilliseconds}");
        }
    }
}