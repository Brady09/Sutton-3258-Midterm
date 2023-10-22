using UnityEngine;

public class AmmoRefill : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PLAYER player = other.GetComponent<PLAYER>();
            if (player != null)
            {
                player.RefillAmmo();
                gameObject.SetActive(false);
            }
        }
    }
}