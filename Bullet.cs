using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public Rigidbody2D rb;
    public GameObject impactFX;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if(enemy != null) { enemy.TakeDamage(damage); }
        Instantiate(impactFX, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
    
}
