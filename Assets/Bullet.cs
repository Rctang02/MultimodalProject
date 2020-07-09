using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfor) {
        if(hitInfor.name != "Earth" && hitInfor.name != "spaceship_1" && hitInfor.name != "Background"){
            Destroy(hitInfor.gameObject);
            Destroy(gameObject);
        }

    }
}
