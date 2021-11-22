using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 200f;//Player'ın ileri yöndeki hızı,
    [SerializeField] private float speedX = 10f;
    public GameManager gameManager;
    public Vector3 initialPos;

    float distanceCameraZ = 20f;///Kameranın platforma uzaklığı


    
    private Vector3 tempMousePos;
    Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if (!gameManager.isPaintStage || !gameManager.isFinish)
        {
            //Player'ı ileri yönde hareket ettir
            body.velocity = new Vector3(body.velocity.x, body.velocity.y, playerSpeed);
            
            //Player'ı sağa sola hareket ettir
            if (Input.GetMouseButton(0))
            {
                tempMousePos = Input.mousePosition;
                tempMousePos.z = distanceCameraZ;
                tempMousePos = Camera.main.ScreenToWorldPoint(tempMousePos);
                body.velocity = new Vector3((tempMousePos.x - transform.position.x) * speedX, body.velocity.y, body.velocity.z);
            }
        }
    }
}
