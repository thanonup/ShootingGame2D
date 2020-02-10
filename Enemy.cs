using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public Image mask1;
    public GameObject Healthbar;

    [SerializeField] float longDistance;
    [SerializeField] float speed;
    [SerializeField] Transform player;
    float distanceToPlayer = Mathf.Infinity;


    public void TakeDamage (int damage)
    {
        health -= damage;
        mask1.fillAmount -= damage / 100f;
        if(health <= 0) { Die(); }
    }
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);    
    }
    private void Update()
    {
        _distanceToPlayer();
    }
    public void _distanceToPlayer()
    {
        distanceToPlayer = Vector3.Distance(player.position, transform.position);
        if (distanceToPlayer <= longDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);       
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, longDistance);
    }

}
