using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    [Header("Shadow Detection")] 
    public Transform lightSource;
    public LayerMask obstacleLayer;
    public SpriteRenderer sr;

    [Header("Auto Pathing")] 
    public Transform target;
    public float speed;
    public float deathTimer;
    private float timer;
    public float flashTimer;
    private bool inDanger = false;
    private float moveSpeed;
    private bool isFlashing = false;
    public bool isSafe = false;

    [Header("SFX")] 
    public AudioSource sfxDeath;
    public AudioSource sfxDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSafe)
        {
            return;
        }
        
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        transform.Translate(directionToTarget * moveSpeed * Time.deltaTime);

        if ((transform.position - target.position).magnitude <= 0.01f)
        {
            isSafe = true;
        }
        
        if (inDanger)
        {
            timer -= Time.deltaTime;
            if (!isFlashing)
            {
                StartCoroutine(FlashRed());
            }
            if (timer <= 0f)
            {
                // death animation
                sfxDeath.Play();
                sfxDamage.Stop();
                Destroy(this);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (isSafe) return;
        inDanger = true;
        sfxDamage.Play();
        timer = deathTimer;
        moveSpeed = speed * 0.1f;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (isSafe) return;
        inDanger = false;
        sfxDamage.Pause();
        moveSpeed = speed;
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (isSafe) return;
        inDanger = false;
        sfxDamage.Pause();
        moveSpeed = speed;
    }

    private IEnumerator FlashRed()
    {
        isFlashing = true;
        sr.color = Color.red;
        yield return new WaitForSeconds(flashTimer);
        sr.color = Color.white;
        isFlashing = false;
    }
}
