using System;
using System.Collections.Generic;
using UnityEngine;

namespace WOW.Business {

    public class RoleRepository {

        Dictionary<int, RoleEntity> all;

        RoleEntity[] playerTeamers;
        int playerTeamersCount;

        RoleEntity[] tempArray;

        public RoleRepository() {
            all = new Dictionary<int, RoleEntity>();
            playerTeamers = new RoleEntity[10];
            playerTeamersCount = 0;
            tempArray = new RoleEntity[1000];
        }

        public void Add(RoleEntity entity) {
            all.Add(entity.id, entity);
            if (entity.allyType == AllyType.Player) {
                playerTeamers[playerTeamersCount++] = entity;
            }
        }

        public void Remove(RoleEntity entity) {
            all.Remove(entity.id);
        }

        public RoleEntity GetPlayerTeamer(int index) {
            if (index < 0 || index >= playerTeamersCount) {
                return null;
            }
            return playerTeamers[index];
        }

        public int GetPlayerTeamer(out RoleEntity[] result) {
            result = playerTeamers;
            return playerTeamersCount;
        }

        public bool TryGet(int id, out RoleEntity entity) {
            return all.TryGetValue(id, out entity);
        }

        public int TakeAll(out RoleEntity[] result) {
            var count = all.Count;
            if (count > tempArray.Length) {
                tempArray = new RoleEntity[count * 2];
            }
            all.Values.CopyTo(tempArray, 0);
            result = tempArray;
            return count;
        }

    }
}