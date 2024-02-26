using System;
using System.Collections.Generic;
using UnityEngine;

namespace WOW {

    public class InputEntity {

        public bool isLeftDown;

        public bool isRightDown;

        public Vector2 downScreenPos;
        public Vector2 downWorldPos;

        public bool isSkillDown;
        public InputEnum chosenSkillKey;

        public bool isChooseDown;
        public InputEnum chosenChoose;

        public bool isCancelDown;

        Dictionary<InputEnum, KeyCode[]> keybindings;
        readonly InputEnum[] skillKeys;
        readonly InputEnum[] chooseKeys;

        public InputEntity() {
            keybindings = new Dictionary<InputEnum, KeyCode[]>();
            skillKeys = new InputEnum[] {
                InputEnum.Melee,
                InputEnum.Skill1,
                InputEnum.Skill2,
                InputEnum.Skill3,
                InputEnum.Skill4,
                InputEnum.Skill5,
            };
            chooseKeys = new InputEnum[] {
                InputEnum.ChooseTeamer1,
                InputEnum.ChooseTeamer2,
                InputEnum.ChooseTeamer3,
                InputEnum.ChooseTeamer4,
            };
        }

        public void Process() {

            // Mouse Down
            {
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
                    downScreenPos = Input.mousePosition;
                }

                isLeftDown = Input.GetMouseButtonDown(0);
                isRightDown = Input.GetMouseButtonDown(1);
            }

            // Cancel Down
            {
                isCancelDown = false;
                bool has = keybindings.TryGetValue(InputEnum.CancelChose, out var cancelKeys);
                if (has) {
                    foreach (var key in cancelKeys) {
                        if (Input.GetKeyDown(key)) {
                            isCancelDown = true;
                            break;
                        }
                    }
                }
            }

            // Skill Down
            {
                isSkillDown = false;
                foreach (InputEnum kv in skillKeys) {
                    bool has = keybindings.TryGetValue(kv, out var keys);
                    if (!has) {
                        continue;
                    }
                    foreach (var key in keys) {
                        if (Input.GetKeyDown(key)) {
                            chosenSkillKey = kv;
                            isSkillDown = true;
                            break;
                        }
                    }
                }
                if (!isSkillDown) {
                    chosenSkillKey = InputEnum.None;
                }
            }

            // Choose Down
            {
                isChooseDown = false;
                foreach (InputEnum kv in chooseKeys) {
                    bool has = keybindings.TryGetValue(kv, out var keys);
                    if (!has) {
                        continue;
                    }
                    foreach (var key in keys) {
                        if (Input.GetKeyDown(key)) {
                            chosenChoose = kv;
                            isChooseDown = true;
                            break;
                        }
                    }
                }
                if (!isChooseDown) {
                    chosenChoose = InputEnum.None;
                }
            }

        }

        public void Bind(InputEnum input, KeyCode[] keys) {
            keybindings.Add(input, keys);
        }

    }

}