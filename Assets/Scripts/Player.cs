using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float playerSpeed = 1f;
    [SerializeField] float boundariesXPadding = 1f;
    [SerializeField] float boundariesYPadding = 1f;
    [field: SerializeField] public int Health { get; private set; } = 300;
    [SerializeField] AudioClip deathSFX;
    [Range(0, 1)] [SerializeField] float deathSFXVolume = 0.7f;
    [SerializeField] AudioClip projectileSFX;
    [Range(0, 1)] [SerializeField] float projectileSFXVolume = 0.3f;

    [Header("Projectile")]
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] float attackSpeed = 1f;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    Coroutine fireCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        InitializeGameBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if(!damageDealer) { return; }
        TakeTheHit(damageDealer);
    }

    private void TakeTheHit(DamageDealer damageDealer)
    {
        Health -= damageDealer.Damage;
        damageDealer.Hit();
        if (Health <= 0)
            Die();
    }

    private void Die()
    {
        //Sounds and animation
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
        FindObjectOfType<Level>().LoadGameOver();
    }

    private void Fire()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            fireCoroutine = StartCoroutine(FireCoroutine());
        }
        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireCoroutine);
        }
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }

    private void InitializeGameBoundaries()
    {
        Camera camera = Camera.main;
        xMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + boundariesXPadding;
        xMax = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - boundariesXPadding;
        yMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + boundariesYPadding;
        yMax = camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - boundariesYPadding;
    }

    IEnumerator FireCoroutine()
    {
        while(true)
        {
            GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity);
            proj.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            AudioSource.PlayClipAtPoint(projectileSFX, Camera.main.transform.position, projectileSFXVolume);
            yield return new WaitForSeconds(1 / attackSpeed);
        }
    }
}
