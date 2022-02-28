using UnityEngine;

namespace _App.Scripts.Libs.AppRoot
{
    public abstract class InstallerMono : MonoBehaviour
    {
        public abstract void Install(AppRunner appRunner);
    }
}