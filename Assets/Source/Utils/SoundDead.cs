using System;
using System.Collections;
using UnityEngine;

namespace Utils
{
  public class SoundDead : MonoBehaviour
  {
    private AudioSource _audioSource;
    
    private void Start()
    {
      _audioSource = GetComponent<AudioSource>();
      StartCoroutine(DestroyAfterAudio());
    }
    private IEnumerator DestroyAfterAudio()
    {
      _audioSource.Play();
      yield return new WaitForSeconds(_audioSource.clip.length);
      Destroy(gameObject);
    }
  }
}
