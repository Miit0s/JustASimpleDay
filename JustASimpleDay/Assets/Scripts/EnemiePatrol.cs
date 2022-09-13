using UnityEngine;

public class EnemiePatrol : MonoBehaviour
{

    public float speed;
    public Transform[] waypoint;
    public SpriteRenderer graphics;

    public int damageOnCollision = 1;

    private Transform target;
    private int destPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoint[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //Si l'ennemie est quasiment arrivé à sa destination, il change de waypoint
        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoint.Length; //Donner le prochain point au l'ennemie doit aller
            target = waypoint[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }
}
