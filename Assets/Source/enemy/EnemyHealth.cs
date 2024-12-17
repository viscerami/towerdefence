using Money;
using System.Collections;
using UnityEngine;

namespace enemy
{
    public class EnemyHealth : AHealth
    {
        [SerializeField] private CoinManager _coin;
        [SerializeField] private int award;

        public override void Start()
        {
            _coin = FindObjectOfType<CoinManager>();
            base.Start();
        }

        protected override void Die()
        {
            _coin.AddCoins(award);
            base.Die();
        }
    }
}