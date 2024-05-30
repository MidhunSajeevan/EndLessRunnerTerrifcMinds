using UnityEngine;

public class Collection : MonoBehaviour
{
    public CollectableObjectData PickableObject;
   
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            
            //Get playerdata and change score in it
            other.gameObject.GetComponent<PlayerMotor>().playerData._score += PickableObject.amount;
            //Invoke when Item is collected to display UI
            GameEvents.ItemCollected.Invoke();
            Destroy(this.gameObject);//Destroy this game object after use
      
        }
    }
}
