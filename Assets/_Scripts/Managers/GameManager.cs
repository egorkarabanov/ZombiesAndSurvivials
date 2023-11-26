using System;
using UnityEngine;

namespace _Scripts.Managers {
    public class GameManager : MonoBehaviour {
        public static GameManager Instance;
        public GameState GameState;

        void Awake() {
            Instance = this;
        }

        public void ChangeState(GameState newState) {
            GameState = newState;
            switch (newState) {
                case GameState.GenerateGrid:
                    GridManager.Instance.GenerateGrid();
                    break;
                case GameState.SpawnSurvivials:
                    ItemManager.Instance.SpawnSurvivials();
                    PostGameManager.Instance._canvas.SetActive(false);
                    break;
                case GameState.SpawnZombie:
                    ItemManager.Instance.SpawnZombie();
                    break;
                case GameState.SpawnWeapon:
                    ItemManager.Instance.SpawnWeapon();
                    break;
                case GameState.SpawnArmor:
                    ItemManager.Instance.SpawnArmor();
                    break;
                case GameState.Turns:
                    if (ItemManager.Instance._zombieFactCount == 0) {
                        PostGameManager.Instance.setWinText("Survivials");
                    } else if (ItemManager.Instance._survivialsCount == 0) {
                        PostGameManager.Instance.setWinText("Zombie");
                    } else {
                        MoveManager.Instance.UnitMove();
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }
        }
    }

    public enum GameState {
        GenerateGrid = 0,
        SpawnSurvivials = 1,
        SpawnZombie = 2,
        SpawnWeapon = 3,
        SpawnArmor = 4,
        Turns = 5,
    }
}