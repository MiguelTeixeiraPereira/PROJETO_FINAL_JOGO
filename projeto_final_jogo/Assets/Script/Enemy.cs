using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float attackDistance = 1.2f;
    public float attackCooldown = 1.5f;
    public int dano = 1;

    public int vidaMaxima = 100;
    private int vidaAtual;

    private Transform player;
    private Animator anim;
    private Rigidbody2D rb;
    private bool isAttacking;
    private float lastAttackTime;
    private bool isGrounded = false;

    public GameManager gameManager;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        vidaAtual = vidaMaxima;
    }

    void Update()
    {
        if (player == null || gameManager == null) return;
        if (vidaAtual <= 0) return; // inimigo morto, não faz nada

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > attackDistance && !isAttacking)
        {
            MoveTowardsPlayer();
        }
        else
        {
            StartCoroutine(Attack());
        }
    }

    void MoveTowardsPlayer()
    {
        if (!isGrounded) return;
        anim.SetInteger("transitions", 1);

        float direction = player.position.x - transform.position.x;
        rb.linearVelocity = new Vector2(Mathf.Sign(direction) * speed, rb.linearVelocity.y);

        if (direction > 0)
            transform.eulerAngles = new Vector2(0, 0);
        else
            transform.eulerAngles = new Vector2(0, 180);
    }

    IEnumerator Attack()
    {
        if (Time.time - lastAttackTime < attackCooldown)
            yield break;

        isAttacking = true;
        anim.SetInteger("transitions", 2);
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);

        yield return new WaitForSeconds(0.4f);

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= attackDistance + 0.2f)
        {
            gameManager.PerderVida(dano);
        }

        lastAttackTime = Time.time;
        isAttacking = false;
        anim.SetInteger("transitions", 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tagGround"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tagGround"))
        {
            isGrounded = false;
        }
    }

    // Recebe dano do player
    public void ReceberDano(int dano)
    {
        vidaAtual -= dano;
        Debug.Log("Inimigo levou dano! Vida atual: " + vidaAtual);

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        anim.SetInteger("transitions", 0);
        Debug.Log("Inimigo morreu!");
        // Desativar colisão e física
        rb.linearVelocity = Vector2.zero;
        rb.isKinematic = true;
        GetComponent<Collider2D>().enabled = false;

        // Pode adicionar animação de morte aqui, se quiser
        Destroy(gameObject, 1.2f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}