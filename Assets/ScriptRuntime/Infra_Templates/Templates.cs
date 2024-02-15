using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace WOW {

    public class Templates {

        Dictionary<Bit64, GameLevelTM> gameLevels;
        AsyncOperationHandle gameLevelsOP;

        Dictionary<string, GameObject> entities;
        AsyncOperationHandle entitiesOP;

        Dictionary<string, GameObject> uis;
        AsyncOperationHandle uisOP;

        Dictionary<int, RoleTM> roleTMs;
        AsyncOperationHandle roleTMsOP;

        Dictionary<int, SkillTM> skillTMs;
        AsyncOperationHandle skillTMsOP;

        Dictionary<int, BulletTM> bulletTMs;
        AsyncOperationHandle bulletTMsOP;

        public Templates() {
            gameLevels = new Dictionary<Bit64, GameLevelTM>();
            entities = new Dictionary<string, GameObject>();
            uis = new Dictionary<string, GameObject>();
            roleTMs = new Dictionary<int, RoleTM>();
            skillTMs = new Dictionary<int, SkillTM>();
            bulletTMs = new Dictionary<int, BulletTM>();
        }

        public void Init() {
            {
                AssetLabelReference labelReference = new AssetLabelReference();
                labelReference.labelString = "TM_GameLevel";
                var op = Addressables.LoadAssetsAsync<GameLevelTM>(labelReference, null);
                var list = op.WaitForCompletion();
                foreach (var gameLevel in list) {
                    gameLevels.Add(new Bit64(gameLevel.chapter, gameLevel.level), gameLevel);
                }
                gameLevelsOP = op;
            }
            {
                AssetLabelReference labelReference = new AssetLabelReference();
                labelReference.labelString = "Entities";
                var op = Addressables.LoadAssetsAsync<GameObject>(labelReference, null);
                var list = op.WaitForCompletion();
                foreach (var entity in list) {
                    entities.Add(entity.name, entity);
                }
                entitiesOP = op;
            }
            {
                AssetLabelReference labelReference = new AssetLabelReference();
                labelReference.labelString = "UI";
                var op = Addressables.LoadAssetsAsync<GameObject>(labelReference, null);
                var list = op.WaitForCompletion();
                foreach (var ui in list) {
                    uis.Add(ui.name, ui);
                }
                uisOP = op;
            }
            {
                AssetLabelReference labelReference = new AssetLabelReference();
                labelReference.labelString = "TM_Role";
                var op = Addressables.LoadAssetsAsync<RoleTM>(labelReference, null);
                var list = op.WaitForCompletion();
                foreach (var roleTM in list) {
                    roleTMs.Add(roleTM.typeID, roleTM);
                }
                roleTMsOP = op;
            }
            {
                AssetLabelReference labelReference = new AssetLabelReference();
                labelReference.labelString = "TM_Skill";
                var op = Addressables.LoadAssetsAsync<SkillTM>(labelReference, null);
                var list = op.WaitForCompletion();
                foreach (var skillTM in list) {
                    skillTMs.Add(skillTM.typeID, skillTM);
                }
                skillTMsOP = op;
            }
            {
                AssetLabelReference labelReference = new AssetLabelReference();
                labelReference.labelString = "TM_Bullet";
                var op = Addressables.LoadAssetsAsync<BulletTM>(labelReference, null);
                var list = op.WaitForCompletion();
                foreach (var bulletTM in list) {
                    bulletTMs.Add(bulletTM.typeID, bulletTM);
                }
                bulletTMsOP = op;
            }
        }

        public void Release() {
            if (gameLevelsOP.IsValid()) {
                Addressables.Release(gameLevelsOP);
            }
            if (entitiesOP.IsValid()) {
                Addressables.Release(entitiesOP);
            }
            if (uisOP.IsValid()) {
                Addressables.Release(uisOP);
            }
            if (roleTMsOP.IsValid()) {
                Addressables.Release(roleTMsOP);
            }
            if (skillTMsOP.IsValid()) {
                Addressables.Release(skillTMsOP);
            }
            if (bulletTMsOP.IsValid()) {
                Addressables.Release(bulletTMsOP);
            }
        }

        bool Entity_TryGet(string name, out GameObject entity) {
            return entities.TryGetValue(name, out entity);
        }

        public GameObject Entity_GetRole() {
            Entity_TryGet("Entity_Role", out var entity);
            return entity;
        }

        public bool UI_TryGet(string name, out GameObject ui) {
            return uis.TryGetValue(name, out ui);
        }

        public bool GameLevel_TryGet(int chapter, int level, out GameLevelTM gameLevel) {
            return gameLevels.TryGetValue(new Bit64(chapter, level), out gameLevel);
        }

    }

}
