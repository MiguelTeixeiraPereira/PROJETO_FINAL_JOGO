using UnityEngine;

using UnityEngine.Audio;

public class Player : MonoBehaviour

{

    public Vector2 posicaoInicial;

    public GameManager gameManager;

    public Animator anim;

    private Rigidbody2D rigd;

    private PlayerAudio playerAudio;

    public float speed;

    public float jumpForce = 5;

    public bool isground;

    public Transform attackPoint;

    public float attackRange = 0.8f;

    public int danoAtaque = 15;

    public LayerMask inimigoLayer;

    private bool isAttacking = false;

    [Header("Sons do Player")]

    public AudioClip attackSound;  // <-- SOM DE ATAQUE

    void Start()

    {

        anim = GetComponent<Animator>();

        rigd = GetComponent<Rigidbody2D>();

        posicaoInicial = transform.position;

        playerAudio = GetComponent<PlayerAudio>();

    }

    void Update()

    {

        if (!isAttacking)

        {

            Move();

            Jump();

        }

        Attack();

    }

    void Move()

    {

        float teclas = Input.GetAxis("Horizontal");

        rigd.linearVelocity = new Vector2(teclas * speed, rigd.linearVelocity.y);

        if (isAttacking) return;

        if (teclas > 0 && isground)

        {

            transform.eulerAngles = new Vector2(0, 0);

            anim.SetInteger("transitions", 1);

        }

        else if (teclas < 0 && isground)

        {

            transform.eulerAngles = new Vector2(0, 180);

            anim.SetInteger("transitions", 1);

        }

        else if (teclas == 0 && isground)

        {

            anim.SetInteger("transitions", 0);

        }

    }

    void Jump()

    {

        if (Input.GetKeyDown(KeyCode.W) && isground)

        {

            rigd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            anim.SetInteger("transitions", 4);

            isground = false;

            // Som de pulo

            playerAudio.PlaySFX(playerAudio.jumpSound);

        }

    }

    void Attack()

    {

        if (Input.GetMouseButtonDown(1) && isground && !isAttacking)

        {

            StartCoroutine(Ataque());

        }

    }

    System.Collections.IEnumerator Ataque()

    {

        isAttacking = true;

        anim.SetInteger("transitions", 2);

        rigd.linearVelocity = Vector2.zero;

        // 🔊 Som de ataque

        if (attackSound != null)

            playerAudio.PlaySFX(attackSound);

        // Dano nos inimigos próximos

        Collider2D[] inimigos = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, inimigoLayer);

        foreach (Collider2D inimigo in inimigos)

        {

            inimigo.GetComponent<Enemy>().ReceberDano(danoAtaque);

        }

        yield return new WaitForSeconds(0.6f);

        isAttacking = false;

        anim.SetInteger("transitions", 0);

    }

    private void OnCollisionEnter2D(Collision2D collision)

    {

        if (collision.gameObject.tag == "tagGround")

        {

            isground = true;

            if (!isAttacking)

                anim.SetInteger("transitions", 0);

        }

    }

    public void Reiniciar_posicao()

    {

        transform.position = posicaoInicial;

    }

    private void OnDrawGizmosSelected()

    {

        if (attackPoint == null) return;

        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }

}

