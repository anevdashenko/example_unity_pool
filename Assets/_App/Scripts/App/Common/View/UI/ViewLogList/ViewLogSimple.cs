using System.Text;
using TMPro;
using UnityEngine;

namespace _App.Scripts.App.Common.View.UI.ViewLogList
{
    public sealed class ViewLogSimple : MonoBehaviour, IViewLogList
    {
        [SerializeField]
        private TextMeshProUGUI textLog;


        private string newLine = "\n"; 
        private readonly StringBuilder _logBuffer = new StringBuilder();
        
        public void AddMessage(string message)
        {
            _logBuffer.Append(message);
            _logBuffer.Append(newLine);
            UpdateView();
        }

        public void Clear()
        {
            _logBuffer.Clear();
            UpdateView();
        }

        private void UpdateView()
        {
            textLog.text = _logBuffer.ToString();
        }
    }
}