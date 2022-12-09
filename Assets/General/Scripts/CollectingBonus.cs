using UnityEngine;
using UnityEngine.UI;
using System;
public class CollectingBonus : MonoBehaviour
{
    [SerializeField] private int point;
    public Text score;
    [SerializeField] private AudioSource collectSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBody"))
        {
            collectSound.Play();
            Destroy(gameObject);           
            score.text = (Convert.ToInt32(score.text) + point).ToString();
        }
    }
}