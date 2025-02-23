
using System.Collections.Generic;
using System.Diagnostics;

namespace ALM.Screens.Mission
{
    public class EntityService
    {
        int _iter = 0;

        public Dictionary<IEntityId, IEntity> Entities { get; private set; } = new();

        public EntityService() { }

        public T Add<T>(T e) where T : IEntity
        {
            _Add(e);
            return e;
        }

        public IEntity Add(IEntity e)
        {
            _Add(e);
            return e;
        }

        void _Add(IEntity e)
        {
            if (e.Id is null)
                e.Id = NewId();

            if (!Entities.TryAdd(e.Id, e))
                $"[Entity Service] Id {e.Id} conflict!".Dbg();
        }

        IEntityId NewId() => new EntityId { Value = ++_iter };

        public void Rm(IEntityId id) =>
            Entities.Remove(id);

        public bool TryGet<T>(int id, out T e) where T : IEntity
        {
            e = default;

            if (!Entities.TryGetValue(new EntityId { Value = id }, out var entity) ||
                !(entity is T))
                return false;


            e = (T)entity;
            return true;
        }

        struct EntityId : IEntityId
        {
            public int Value { get; init; }
        }
    }
}