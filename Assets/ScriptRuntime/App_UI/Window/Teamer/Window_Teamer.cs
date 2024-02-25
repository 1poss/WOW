using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WOW.UI {

    public class Window_Teamer : MonoBehaviour {

        [SerializeField] Window_TeamerElement elePrefab;
        [SerializeField] Transform teamerGroup;

        List<Window_TeamerElement> elements;

        public void Ctor() {
            elements = new List<Window_TeamerElement>();
        }

        public void Add(int entityID, string name, Sprite spr) {
            var ele = Instantiate(elePrefab, teamerGroup);
            ele.Init(entityID, name, spr);
            elements.Add(ele);
        }

        public void UpdateHP(int entityID, float hp, float hpMax) {
            var ele = elements.Find(e => e.entityID == entityID);
            if (ele == null) {
                Debug.LogError($"Window_Teamer.UpdateHP: not found: {entityID}");
                return;
            }
            ele.SetHP(hp, hpMax);
        }

    }

}