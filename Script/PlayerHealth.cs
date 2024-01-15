using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Text healthText;

    public GameObject pausemenu;
    public AudioSource soundDie;
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            pausemenu.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            soundDie.Play();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        healthText.text = "Vida: " + currentHealth.ToString();
    }
}

