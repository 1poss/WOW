using System;
using System.Collections.Generic;

namespace WOW {

    public class RoleSkillSlotComponent {

        // q w e r
        Dictionary<InputEnum, SkillSubentity> skillSlots;

        readonly static InputEnum[] skillSlotKeys = new InputEnum[] {
            InputEnum.Skill1,
            InputEnum.Skill2,
            InputEnum.Skill3,
            InputEnum.Skill4,
            InputEnum.Skill5,
        };

        public RoleSkillSlotComponent() {
            skillSlots = new Dictionary<InputEnum, SkillSubentity>();
        }

        public void Add(SkillSubentity skill) {
            for (int i = 0; i < skillSlotKeys.Length; i++) {
                if (!skillSlots.ContainsKey(skillSlotKeys[i])) {
                    skillSlots.Add(skillSlotKeys[i], skill);
                    return;
                }
            }
        }

        public bool TryGet(InputEnum input, out SkillSubentity skill) {
            return skillSlots.TryGetValue(input, out skill);
        }

    }

}