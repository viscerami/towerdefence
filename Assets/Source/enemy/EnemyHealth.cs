using Money;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace enemy
{
    public class EnemyHealth : AHealth
    {
        [SerializeField] private CoinManager _coin;
        [SerializeField] private int award;
        [SerializeField] private WaveSystem waveSystem;
        [SerializeField] AudioSource audioSourcePref;

        public override void Start()
        {
            waveSystem = FindObjectOfType<WaveSystem>();
            _coin = FindObjectOfType<CoinManager>();
            base.Start();
        }

        protected override void Die()
        {
            Instantiate(audioSourcePref);
            waveSystem.waveState.value--;
            _coin.AddCoins(award);
            Destroy(gameObject);
        }
    }
}