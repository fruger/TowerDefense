using UnityEngine;

namespace TowerDefense
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        [field: SerializeField]
        public int CurrentCoins { get; private set; }

        [field: SerializeField]
        public float CurrentHealth { get; private set; }

        [field: SerializeField]
        private int MaxCoins { get; set; }

        [field: SerializeField]
        private float MaxHealth { get; set; }


        public void TakeDamage(int damageValue)
        {
            CurrentHealth -= damageValue;

            if (CurrentHealth <= 0)
            {
                OnGameLost();
            }
        }

        public void AddCoins(int amount)
        {
            CurrentCoins += amount;
            Debug.Log($"{amount} coins gained! You have {CurrentCoins} coins left");
        }

        public bool TryBuyTower(TowerController tower)
        {
            // if (CurrentCoins >= tower.Cost)
            // {
            //     SpendCoins(tower.Cost);
            //     return true;
            // }

            return true;
        }

        protected override void Awake()
        {
            base.Awake();

            CurrentHealth = MaxHealth;
            CurrentCoins = MaxCoins;
        }

        private void SpendCoins(int amount)
        {
            CurrentCoins -= amount;
            Debug.Log($"{amount} coins spent! You have {CurrentCoins} coins left");
        }

        private void OnGameLost()
        {
            Debug.Log("You have lost");
        }
    }
}
