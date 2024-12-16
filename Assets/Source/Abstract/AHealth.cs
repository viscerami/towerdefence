using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class AHealth : MonoBehaviour
{
    [SerializeField] protected int maxHealth = 100;
    public int currentHealth;
    private SpriteRenderer _spriteRenderer;

    private readonly Color damageColor = new Color(1f, 0.5f, 0.5f, 1f);
    private readonly float colorChangeDuration = 0.5f;

    public virtual void Start()
    {
        currentHealth = maxHealth;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(ChangeColor(damageColor));
        }
    }

    private IEnumerator ChangeColor(Color targetColor)
    {
        Color originalColor = _spriteRenderer.color;
        float elapsedTime = 0f;

        while (elapsedTime < colorChangeDuration)
        {
            _spriteRenderer.color = Color.Lerp(originalColor, targetColor, elapsedTime / colorChangeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        elapsedTime = 0f;
        while (elapsedTime < colorChangeDuration)
        {
            _spriteRenderer.color = Color.Lerp(targetColor, originalColor, elapsedTime / colorChangeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _spriteRenderer.color = originalColor;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}

