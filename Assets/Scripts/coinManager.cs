using UnityEngine;

public class coinManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance != null)  // Ensure the instance exists before calling
            {
                GameManager.Instance.AddScore(1);
            }
            Destroy(gameObject);
        }
    }
}