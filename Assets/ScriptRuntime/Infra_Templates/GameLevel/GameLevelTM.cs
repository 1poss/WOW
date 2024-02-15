using UnityEngine;

namespace WOW {

    [CreateAssetMenu(fileName = "TM_GameLevel_", menuName = "WOW/GameLevelTM", order = 0)]
    public class GameLevelTM : ScriptableObject {

        public int chapter;
        public int level;

        public GameLevelSpawnerTM[] spawners;

    }

}