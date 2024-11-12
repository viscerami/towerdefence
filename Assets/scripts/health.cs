using UnityEngine;
using System.Collections; 

public class Health : MonoBehaviour
{
    public int maxHealth = 100; 
    private int currentHealth; 
    private SpriteRenderer spriteRenderer; 

   
    public Color damageColor = new Color(1f, 0.5f, 0.5f, 1f); 
    public float colorChangeDuration = 0.5f; 

    void Start()
    {
        currentHealth = maxHealth; 
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    
    public void TakeDamage(int damage)
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
        Color originalColor = spriteRenderer.color; 
        float elapsedTime = 0f;

       
        while (elapsedTime < colorChangeDuration)
        {
            spriteRenderer.color = Color.Lerp(originalColor, targetColor, elapsedTime / colorChangeDuration);
            elapsedTime += Time.deltaTime;
            yield return null; 
        }

       
        elapsedTime = 0f;
        while (elapsedTime < colorChangeDuration)
        {
            spriteRenderer.color = Color.Lerp(targetColor, originalColor, elapsedTime / colorChangeDuration);
            elapsedTime += Time.deltaTime;
            yield return null; 
        }

        spriteRenderer.color = originalColor;
    }

    
    private void Die()
    {
        Destroy(gameObject); 
    }
}