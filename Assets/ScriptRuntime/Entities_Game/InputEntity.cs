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
        public InputEnum chosenSkill;

        public bool isChooseDown;
        public InputEnum chosenChoose;

        Dictionary<InputEnum, KeyCode[]> keybindings;
        readonly InputEnum[] skillKeys;
        readonly InputEnum[] chooseKeys;

        public InputEntity() {
            keybindings = new Dictionary<InputEnum, KeyCode[]>();
            skillKeys = new InputEnum[] {
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

            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
                downScreenPos = Input.mousePosition;
            }

            isLeftDown = Input.GetMouseButtonDown(0);
            isRightDown = Input.GetMouseButtonDown(1);

            // Skill Down
            isSkillDown = false;
            foreach (InputEnum kv in skillKeys) {
                bool has = keybindings.TryGetValue(kv, out var keys);
                if (!has) {
                    continue;
                }
                foreach (var key in keys) {
                    if (Input.GetKeyDown(key)) {
                        chosenSkill = kv;
                        isSkillDown = true;
                        break;
                    }
                }
            }
            if (!isSkillDown) {
                chosenSkill = InputEnum.None;
            }

            // Choose Down
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

        public void Bind(InputEnum input, KeyCode[] keys) {
            keybindings.Add(input, keys);
        }

    }

}