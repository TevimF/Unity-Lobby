using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public float velocidade = 5f;
    public Animator player_animation;
    private Rigidbody rb;
    int ataques=0;
    bool atacando = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        player_animation = GetComponent<Animator>();
    }

    void  Update()   
    {
        MovimentarJogador();
        CombateJogador();
        Debug.Log(player_animation.GetInteger("ataque"));
    }

    void MovimentarJogador()
    {
        if (atacando==false)
        {
        velocidade= 0;
        }
        else velocidade= 5;
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //Debug.Log("Horizontal: " + horizontal + " Vertical: " + vertical);
        // Chama a função para animar o jogador
        AnimarJogador(); 
        // Criar um vetor de movimento para ele andar
        Vector3 movimento = new Vector3(horizontal, 0f, vertical);
        Vector3 velocidadeMovimento = movimento * velocidade;

        // Configurar a velocidade do Rigidbody
        rb.velocity = new Vector3(velocidadeMovimento.x, rb.velocity.y, velocidadeMovimento.z);   
       
    }
    void AnimarJogador()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            player_animation.SetBool("esta_andando", true);
            //Debug.Log("Andando");
            if (Input.GetAxis("Horizontal") > 0) // Se o jogador estiver indo para a direita
            {
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (Input.GetAxis("Horizontal") < 0) // Se o jogador estiver indo para a esquerda
            {
                player.transform.rotation = Quaternion.Euler(0, -180, 0);
            }
        }
        else
        {
            //Debug.Log("Parado");
            player_animation.SetBool("esta_andando", false);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Ataquei");
            player_animation.SetInteger("ataque", 1);
            atacando=true;
        }
        else
        {
            player_animation.SetInteger("ataque", 0);
        }
    }
    void CombateJogador() // vai ficar os codigo de atk
    {
        AnimarJogador();
    }
}