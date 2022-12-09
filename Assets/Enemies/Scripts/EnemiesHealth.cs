using UnityEngine;
using UnityEngine.UI;
using System;
public class EnemiesHealth : MonoBehaviour
{
    [SerializeField] private float maxEnemieHealth;
    [SerializeField] private int scoreDrop;
    [SerializeField] private Text scoreText;
    [SerializeField] private AudioSource hurtSound;
    [SerializeField] private AudioSource dieSound;
    private float currentEnemieHealth;
    public bool isDeath;
    private EnemiesAnimator enemiesAnim;
    private void Awake()
    {
        enemiesAnim = GetComponent<EnemiesAnimator>();
        currentEnemieHealth = maxEnemieHealth;
        isDeath = false;
    }
    private void CheckIsAlive()
    {
        if (currentEnemieHealth <= 0) 
        {
            dieSound.Play();
            isDeath = true;  
            gameObject.layer = 10; 
            scoreText.text = (Convert.ToInt32(scoreText.text) + scoreDrop).ToString(); 
        }
        enemiesAnim.EnemieDie(isDeath);
    }
    public void EnemieTakeDamage(float damage)
    {
        currentEnemieHealth -= damage;
        enemiesAnim.EnemieHurt();
        hurtSound.Play();
        CheckIsAlive();
    }   
}