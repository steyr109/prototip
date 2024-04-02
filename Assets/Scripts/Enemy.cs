using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    private int currentHealth;
    public Quest quest;

    private PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerStats = new PlayerStats();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        /*if (quest.isActive)
        {
            Debug.Log("norm");
            quest.questProgress.IncreaseCurrentAmount();
            Debug.Log("norm");
            if (quest.questProgress.IsReached())
            {
                Debug.Log("Задание выполнено!");
                quest.Complete();
            }
        }*/
        quest.questProgress.IncreaseCurrentAmount();
        if (quest.questProgress.IsReached())
        {
            Debug.Log("Задание выполнено!");
            quest.Complete();
        }
        Debug.Log("Противник убит!");
        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        playerStats.GainEXP(10);
    }
}
