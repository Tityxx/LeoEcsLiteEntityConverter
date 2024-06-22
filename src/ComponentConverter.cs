using System;

using Leopotam.EcsLite;

using UnityEngine;

namespace AB_Utility.FromSceneToEntityConverter
{
    [DisallowMultipleComponent]
    public class ComponentConverter<T> : BaseConverter where T : struct
    {
        [SerializeField] protected T _component;

        private int _entity;

        public int Entity => _entity;
        
        public override void Convert(EcsPackedEntityWithWorld entityWithWorld)
        {
            if (entityWithWorld.Unpack(out var world, out var _entity))
            {
                ref var component = ref world.GetPool<T>().Add(_entity);
                component = _component;
            }
        }

        private void Reset()
        {
            var container = GetComponent<ComponentsContainer>();
            container.GetConverters();
        }
    }
}
