using System;
using UnityEngine;
using UnityEngine.UI;

namespace WOW {

    public class Window_Login : MonoBehaviour {

        [SerializeField] Button startBtn;

        public Action OnStartHandle;

        public void Ctor() {
            startBtn.onClick.AddListener(() => {
                OnStartHandle.Invoke();
            });
        }

    }

}