using Leopotam.EcsLite;
using UnityEngine;

namespace AB_Utility.FromSceneToEntityConverter
{
    [DisallowMultipleComponent]
    public class ComponentsContainer : MonoBehaviour
    {
        [SerializeField] private BaseConverter[] _converters;
        [SerializeField] private bool _destroyAfterConversion;
        [SerializeField] private bool _deleteEntityOnDestroy = true;

        private EcsWorld _world;
        private int _entity;

        public BaseConverter[] Converters => _converters;
        public bool DestroyAfterConversion => _destroyAfterConversion;
        public int Entity => _entity;

        private void OnDestroy()
        {
            if (_deleteEntityOnDestroy)
                _world?.DelEntity(_entity);
        }

        internal void GetConverters()
        {
            _converters = GetComponents<BaseConverter>();
        }

        internal void SetWorld(EcsWorld world)
        {
            _world = world;
        }

        internal void SetEntity(int entity)
        {
            _entity = entity;
        }
    }
}