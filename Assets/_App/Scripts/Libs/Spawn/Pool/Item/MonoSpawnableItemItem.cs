﻿using UnityEngine;

namespace _App.Scripts.Libs.Spawn.Pool
{
    public class MonoSpawnableItemItem : MonoBehaviour, ISpawnableItem
    {
        private IObjectPool _objectPool;

        public virtual void OnCreated(IObjectPool objectPool)
        {
            _objectPool = objectPool;
        }

        public virtual void OnSpawned()
        {
        }

        public virtual void OnDespawned()
        {
            
        }

        public virtual void OnRemoved()
        {
            Destroy(gameObject);
        }

        public virtual void Remove()
        {
            if (_objectPool is null)
            {
                OnRemoved();
                return;
            }
            
            _objectPool.Despawn(this);
        }
    }
}