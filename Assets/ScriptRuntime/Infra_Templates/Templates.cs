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
        }

        public void Release() {
            if (entitiesOP.IsValid()) {
                Addressables.Release(entitiesOP);
            }
        }

        public bool Entity_TryGet(string name, out GameObject entity) {
            return entities.TryGetValue(name, out entity);
        }

        public bool UI_TryGet(string name, out GameObject ui) {
            return uis.TryGetValue(name, out ui);
        }

    }

}
