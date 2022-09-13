using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public bool isInvincible = false;
    public bool isLowLife = false;

    public SpriteRenderer graphics;
    public HealthBar healthBar;
    public Image heart;

    public int[] levelnumber;

    // 
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth();
    }

    private void OnLevelWasLoaded(int level)
    {
        foreach (var element in levelnumber)
        {
            if (level == element)
            {
                currentHealth = maxHealth;
                healthBar.SetMaxHealth();
                isLowLife = false;
            }
        }
    }

    // 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(1);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Regen(1);
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            isInvincible = true;
            StartCoroutine(InvisiblityFlash());
            StartCoroutine(HandleInvicibilityDealy());
        }

        if (currentHealth == 1)
        {
            isLowLife = true;
            StartCoroutine(Clignotement());
        }else
        {
            isLowLife = false;
        }
    }

    public void Regen(int damage)
    {
        currentHealth += damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth == 1)
        {
            isLowLife = true;
            StartCoroutine(Clignotement());
        }
        else
        {
            isLowLife = false;
        }
    }

    public IEnumerator InvisiblityFlash()
    {
        while(isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(0.15f); //Temps de flash
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.15f); //Temps de flash
        }
    }

    public IEnumerator HandleInvicibilityDealy()
    {
        yield return new WaitForSeconds(3f); //Temps d'invincibilité
        isInvincible = false;
    }

    public IEnumerator Clignotement()
    {
        while (isLowLife)
        {
            yield return new WaitForSeconds(0.5f);
            heart.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(0.5f); //Temps de flash
            heart.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}