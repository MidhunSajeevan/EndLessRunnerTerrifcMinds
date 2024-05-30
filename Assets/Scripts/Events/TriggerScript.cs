using UnityEngine;

public class TriggerScript : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Collided");
            GameEvents.GameOver.Invoke();
        }
    }
}
