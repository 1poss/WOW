using UnityEngine;

namespace WOW {

    public class RoleMod : MonoBehaviour {

        [SerializeField] Animator animator;

        public void Param_SetMagnitude(float magnitude) {
            animator.SetFloat("Magnitude", magnitude);
        }

        public void Play_Idle() {
            animator.Play("Idle");
        }

        public void Param_TriggerCast() {
            animator.SetTrigger("Cast");
        }

    }

}