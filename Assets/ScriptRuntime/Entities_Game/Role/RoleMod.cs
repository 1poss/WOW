using UnityEngine;

namespace WOW {

    public class RoleMod : MonoBehaviour {

        [SerializeField] Animator animator;

        public void Param_SetMagnitude(float magnitude) {
            animator.SetFloat("Magnitude", magnitude);
        }

    }

}