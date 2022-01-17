using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private int bulletDamage;

    [SerializeField] private PlayerHealth _playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Damage();
        }
    }
    void Damage()
    {
        _playerHealth.playerHealth = _playerHealth.playerHealth - bulletDamage;
        _playerHealth.UpdateHealth();
        gameObject.SetActive(false);
    }
}
