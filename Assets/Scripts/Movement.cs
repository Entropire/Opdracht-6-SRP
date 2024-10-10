using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected float rotationSpeed = 25f;
    
    void Update()
    {
        Move(1);
        Rotate(1);
    }
    
    protected void Move(float i)
    {
        transform.position += transform.forward * (moveSpeed * i * Time.deltaTime); 
    }

    protected void Rotate(float i)
    {
        transform.Rotate(transform.up * (rotationSpeed * i * Time.deltaTime)); 
    }
}
