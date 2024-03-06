using System;
using System.Collections.Generic;

namespace WOW {

    public class RoleSkillSlotComponent {

        // q w e r
        Dictionary<InputEnum, SkillSubentity> skillSlots;

        SkillSubentity melee;

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
            if (skill.skillType == SkillType.Melee) {
                melee = skill;
                return;
            }
            for (int i = 0; i < skillSlotKeys.Length; i++) {
                if (!skillSlots.ContainsKey(skillSlotKeys[i])) {
                    skillSlots.Add(skillSlotKeys[i], skill);
                    return;
                }
            }
        }

        public SkillSubentity GetMelee() {
            return melee;
        }

        public bool TryGet(InputEnum input, out SkillSubentity skill) {
            return skillSlots.TryGetValue(input, out skill);
        }

        public bool TryGetByTypeID(int typeID, out SkillSubentity skill) {
            foreach (var kv in skillSlots) {
                if (kv.Value.typeID == typeID) {
                    skill = kv.Value;
                    return true;
                }
            }
            skill = null;
            return false;
        }

    }

}