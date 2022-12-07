using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody rb;

    private float movementX;
    private float movementY;
    private float rotationX;

    [Space]
    public float shotSpeed = 10;
    public float cupcakeLifetime = 2;
    public float cooldown = 5;
    public GameObject cupcakeObject;
    public Transform spawnPoint;
    private bool shotFired = false;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void OnMove(InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void OnLook(InputValue lookValue) {
        Vector2 lookVector = lookValue.Get<Vector2>();
        rotationX = lookVector.x;
    }

    private void OnFire(InputValue fireValue) {
        if (!shotFired) {
            shotFired = true;
            GameObject cupcakeProjectile = Instantiate(cupcakeObject, spawnPoint.position, spawnPoint.rotation);
            cupcakeProjectile.GetComponent<Rigidbody>().velocity = spawnPoint.transform.up * shotSpeed * -1;
            Destroy(cupcakeProjectile, cupcakeLifetime);
            Invoke("EndCooldown", cooldown + cupcakeLifetime);

        }
    }

    private void EndCooldown() {
        shotFired = false;
    }

    private void FixedUpdate() {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        Vector3 movement = new Vector3(movementX, -movementY, 0);
        rb.AddRelativeForce(movement * speed);
        
        

        Vector3 rotation = new Vector3(0, 0, rotationX);
        Quaternion deltaRotation = Quaternion.Euler(rotation * 10.0f * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
