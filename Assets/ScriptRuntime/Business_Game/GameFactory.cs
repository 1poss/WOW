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
            role.typeName = roleTM.typeName;
            role.allyType = allyType;
            role.Pos_Set(pos);

            var attrCom = role.attrComponent;
            attrCom.hp = roleTM.hp;
            attrCom.hpMax = roleTM.hp;

            var skillPresets = roleTM.skillPresets;
            for (int i = 0; i < skillPresets.Length; i++) {
                var skillPreset = skillPresets[i];
                var skill = Skill_Create(templates, idService, skillPreset.typeID, pos);
                role.skillSlotComponent.Add(skill);
            }

            var mod = roleTM.mod;
            mod = GameObject.Instantiate(mod, role.body);
            role.mod = mod.GetComponent<RoleMod>();

            return role;

        }

        static SkillSubentity Skill_Create(Templates templates, IDService idService, int typeID, Vector2 pos) {
            bool has = templates.Skill_TryGet(typeID, out var tm);
            if (!has) {
                Debug.LogError($"GameFactory.Skill_Create: SkillTM not found: {typeID}");
                return null;
            }
            var skill = new SkillSubentity();
            skill.id = idService.skillID++;
            skill.typeID = typeID;
            skill.typeName = tm.typeName;

            skill.castDirection = tm.castDirection;
            skill.indicateType = tm.indicateType;

            skill.cdSec = tm.cdSec;
            skill.cdTimer = 0;

            skill.stage = SkillStage.Pre;

            skill.preSec = tm.preSec;
            skill.preTimer = tm.preSec;
            skill.actSec = tm.actSec;
            skill.actTimer = tm.actSec;
            skill.actInterval = tm.actInterval;
            skill.actIntervalTimer = tm.actInterval;
            skill.postSec = tm.postSec;
            skill.postTimer = tm.postSec;

            skill.hasSpawnBullet = tm.hasSpawnBullet;
            skill.spawnPositionType = tm.spawnPositionType;

            return skill;

        }

    }

}