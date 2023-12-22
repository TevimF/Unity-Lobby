using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidade = 5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(horizontal, 0f, vertical);
        Vector3 velocidadeMovimento = movimento * velocidade * Time.deltaTime;

        transform.Translate(velocidadeMovimento);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Se houver uma colisão, ajuste a posição para evitar atravessar a parede
        if (collision.gameObject.CompareTag("Parede"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
