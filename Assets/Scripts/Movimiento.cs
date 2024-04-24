using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento de la esfera

    private Rigidbody rb;
    private Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener el componente Rigidbody de la esfera
        mainCamera = Camera.main; // Obtener la cámara principal
        if (rb == null)
        {
            Debug.LogError("No se encontró un componente Rigidbody adjunto a la esfera.");
        }
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            // Movimiento horizontal de la esfera
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(movement * moveSpeed);
        }

        // Posicionar la cámara a la altura de la esfera
        if (mainCamera != null)
        {
            mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z - 5f);
        }
    }
}
