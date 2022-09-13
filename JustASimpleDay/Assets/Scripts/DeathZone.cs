using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour
{
    private Transform playerSpawn;
    private Animator fadeSystem;
    private GameObject player;
    private Rigidbody2D collisionPlayer;
    private SpriteRenderer spritePlayer;

    private void Awake()
    {
        //Optimisation
        playerSpawn = GameObject.FindGameObjectWithTag("Respawn").transform;
        //Transition
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
        //Joueur
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnLevelWasLoaded()
    {
        //Change le playerSpawn car les précédant à été détruit
        playerSpawn = GameObject.FindGameObjectWithTag("Respawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AnimationNoyade(player);
            //Démarre la transition
            StartCoroutine(ReplacePlayer(collision));
        }
    }

    private void AnimationNoyade (GameObject player)
    {
        //Bloque la chute
        collisionPlayer = player.GetComponent<Rigidbody2D>();
        collisionPlayer.constraints = RigidbodyConstraints2D.FreezeAll;
        //Effet de noyade
        spritePlayer = player.GetComponent<SpriteRenderer>();
        StartCoroutine(AnimationNoyade(spritePlayer,collisionPlayer));
    }

    private IEnumerator ReplacePlayer(Collider2D player)
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        //Téléporte au début
        player.transform.position = playerSpawn.position;
        yield return new WaitForSeconds(0.8f);
        //Enlève une vie
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.TakeDamage(1);

    }

    private IEnumerator AnimationNoyade(SpriteRenderer spritePlayer, Rigidbody2D playerCollision)
    {
        for (int i = 0; i < 8; i++)
        {
            spritePlayer.flipX = true;
            yield return new WaitForSeconds(0.1f);
            spritePlayer.flipX = false;
            yield return new WaitForSeconds(0.1f);
        }
        playerCollision.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
