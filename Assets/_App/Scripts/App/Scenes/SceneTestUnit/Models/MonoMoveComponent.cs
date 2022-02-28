using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace _App.Scripts.App.Scenes.SceneTestUnit.Models
{
    public class MonoMoveComponent : MonoBehaviour
    {
        [SerializeField]
        private float Speed = 10f;
        
        [SerializeField]
        private Vector3 Direction = Vector3.back;

        [SerializeField]
        private List<Vector3> points = new List<Vector3>();

        [SerializeField]
        private string name = "anas";
        
        public Vector3 Position { get; set; }
    }
}