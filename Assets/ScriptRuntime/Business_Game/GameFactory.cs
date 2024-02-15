using UnityEngine;

namespace WOW.Business {

    public static class GameFactory {

        public static RoleEntity Role_Create(Templates templates, IDService idService, int typeID, AllyType allyType, Vector2 pos) {
            var prefab = templates.Entity_GetRole();
            var go = GameObject.Instantiate(prefab);
            var entity = go.GetComponent<RoleEntity>();
            entity.Ctor();
            entity.id = idService.roleID++;
            entity.typeID = typeID;
            entity.allyType = allyType;
            entity.Pos_Set(pos);
            return entity;
        }

    }

}