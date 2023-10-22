using UnityEngine;

public class PLAYER : MonoBehaviour
{
    CharacterController characterController;
    public float movementSpeed = 5.0f;
    public float jumpSpeed = 1.0f;
    public float gravity = 5.0f;
    public float mouseSensitivity = 3.0f;
    public GameObject bulletImpactPrefab;
    public Transform gunEnd;
    private int currentAmmo = 6;
    private int maxAmmo = 6;
    public GameObject ammoRefill;
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Player movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * vertical * movementSpeed * Time.deltaTime +
                          transform.right * horizontal * movementSpeed * Time.deltaTime;

        // Jump
        if (characterController.isGrounded)
        {
            moveDirection.y = 0;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        movement.y = moveDirection.y;

        characterController.Move(movement);

        // Player rotation with mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(Vector3.up, mouseX);

        // Shooting
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(gunEnd.position, gunEnd.forward, out hit, Mathf.Infinity))
        {
            Instantiate(bulletImpactPrefab, hit.point, Quaternion.LookRotation(hit.normal));
        }
        currentAmmo--;
    }

    public void RefillAmmo()
    {
        currentAmmo = maxAmmo;
        ammoRefill.SetActive(false);
    }
}