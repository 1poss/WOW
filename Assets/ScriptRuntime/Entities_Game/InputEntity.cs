using System;
using UnityEngine;

namespace WOW {

    public class InputEntity {

        public bool isLeftDown;

        public bool isRightDown;

        public Vector2 downScreenPos;
        public Vector2 downWorldPos;

        public InputEntity() { }

        public void Process() {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
                downScreenPos = Input.mousePosition;
            }
            isLeftDown = Input.GetMouseButtonDown(0);
            isRightDown = Input.GetMouseButtonDown(1);
        }

    }

}