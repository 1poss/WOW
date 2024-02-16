using UnityEngine;

namespace WOW.Business {

    public static class GameFactory {

        public static RoleEntity Role_Create(Templates templates, IDService idService, int typeID, AllyType allyType, Vector2 pos) {

            bool has = templates.Role_TryGet(typeID, out var roleTM);
            if (!has) {
                Debug.LogError($"GameFactory.Role_Create: RoleTM not found: {typeID}");
                return null;
            }

            var prefab = templates.Entity_GetRole();
            var go = GameObject.Instantiate(prefab);
            var role = go.GetComponent<RoleEntity>();
            role.Ctor();
            role.id = idService.roleID++;
            role.typeID = typeID;
            role.allyType = allyType;
            role.Pos_Set(pos);

            var skillPresets = roleTM.skillPresets;
            for (int i = 0; i < skillPresets.Length; i++) {
                var skillPreset = skillPresets[i];
                var skill = Skill_Create(templates, idService, skillPreset.typeID, pos);
                role.skillSlotComponent.Add(skill);
            }

            return role;

        }

        static SkillSubentity Skill_Create(Templates templates, IDService idService, int typeID, Vector2 pos) {
            var entity = new SkillSubentity();
            entity.id = idService.skillID++;
            entity.typeID = typeID;
            return entity;
        }

    }

}