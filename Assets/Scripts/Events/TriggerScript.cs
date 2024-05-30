using UnityEngine;

public class TriggerScript : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
      
            //Invoke Game over Event when the player collided with an obstacle
            GameEvents.GameOver.Invoke();
        }
    }
}
