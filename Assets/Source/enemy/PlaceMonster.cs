using UnityEngine;

namespace enemy
{
    public class PlaceMonster : MonoBehaviour
    {
        [SerializeField] private GameObject monsterPrefab;
        private GameObject _monster;
        private bool CanPlaceMonster()
        {
            return _monster == null;
        }
        void OnMouseUp()
        {
            //2
            if (CanPlaceMonster())
            {
                //3
                _monster = (GameObject)
                    Instantiate(monsterPrefab, transform.position, Quaternion.identity);
                //4
                AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                audioSource.PlayOneShot(audioSource.clip);

                // TODO: �������� ������
            }
        }
    }
}
