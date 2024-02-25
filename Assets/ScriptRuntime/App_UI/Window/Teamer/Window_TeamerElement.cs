using System;
using UnityEngine;
using UnityEngine.UI;

namespace WOW.UI {

    public class Window_TeamerElement : MonoBehaviour {

        public int entityID;
        [SerializeField] Image icon;
        [SerializeField] Text nameTxt;
        [SerializeField] Image hpBar;

        public void Init(int entityID, string name, Sprite spr) {
            this.entityID = entityID;
            nameTxt.text = name;
            icon.sprite = spr;
        }

        public void SetHP(float hp, float hpMax) {
            hpBar.fillAmount = hp / hpMax;
        }

    }

}