using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace WOW {

    public class Templates {

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
            entities = new Dictionary<string, GameObject>();
            uis = new Dictionary<string, GameObject>();
        }

        public void Init() {
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
                roleTMs = new Dictionary<int, RoleTM>();
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
                skillTMs = new Dictionary<int, SkillTM>();
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
                bulletTMs = new Dictionary<int, BulletTM>();
                foreach (var bulletTM in list) {
                    bulletTMs.Add(bulletTM.typeID, bulletTM);
                }
                bulletTMsOP = op;
            }
        }

        public void Release() {
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

    }

}
