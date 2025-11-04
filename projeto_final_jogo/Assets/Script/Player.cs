using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 posicaoInicial;
    public GameManager gameManager;

    public Animator anim;
    private Rigidbody2D rigd;
    public float speed;
    public float jumpForce = 5;
    public bool isground;

  
    void Start()
    {
        anim = GetComponent<Animator>();
        rigd = GetComponent<Rigidbody2D>();
        posicaoInicial = transform.position;
    }


    void Update()
    {
        Move();
        Jump();

    }
    void Move()
    {
        float teclas = Input.GetAxis("Horizontal");
        rigd.linearVelocity = new Vector2(teclas * speed, rigd.linearVelocity.y);

        if (teclas > 0 && isground == true)
        {
            transform.eulerAngles = new Vector2(0, 0);
            anim.SetInteger("transitions", 1);
        }
        if (teclas < 0 && isground == true)
        {
            transform.eulerAngles = new Vector2(0, 180);
            anim.SetInteger("transitions", 1);
        }
        if (teclas == 0 && isground == true)
        {
            anim.SetInteger("transitions", 0);
        }
    }

   
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isground == true)
        {
           rigd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetInteger("transitions", 4);
            isground = false;
       }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "tagGround")
        {
            isground = true;
            anim.SetInteger("transitions", 0);
            Debug.Log("esta no chão");
        }
    }

    public void Reiniciar_posicao()
    {
        transform.position = posicaoInicial;
    }
}
