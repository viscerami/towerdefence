using Money;
using System.Collections;
using UnityEngine;

namespace enemy
{
    public class EnemyHealth : AHealth
    {
        [SerializeField] private CoinManager _coin;
        [SerializeField] private int award;
        [SerializeField] private WaveSystem waveSystem;

        public override void Start()
        {
            waveSystem = FindObjectOfType<WaveSystem>();
            _coin = FindObjectOfType<CoinManager>();
            base.Start();
        }

        protected override void Die()
        {
            waveSystem.waveState.value--;
            _coin.AddCoins(award);
            base.Die();
        }
    }
}