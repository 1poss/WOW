using UnityEngine;
using UnityEngine.UI;

namespace WOW.UI {

    public class HUD_HpBar : MonoBehaviour {

        [SerializeField] Image barImg;

        public void SetHp(float hp, float maxHp) {
            barImg.fillAmount = hp / maxHp;
        }

    }

}