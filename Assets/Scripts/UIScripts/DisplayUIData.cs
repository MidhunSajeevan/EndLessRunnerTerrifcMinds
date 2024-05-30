using TMPro;
using UnityEngine;

public class DisplayUIData : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Score;

    private DataScriptableObject playerdata;
    private void OnEnable()
    {
        //Find the Player game object and Player data inside it
        playerdata = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>().playerData;

        //Display the player data when starting
        Score.text = playerdata._score.ToString();
        //Listen for the event when the item is collected chang score value
        GameEvents.ItemCollected += DisplayData;
    }

    public void DisplayData()
    {
        //Display Player data changed
        Score.text = playerdata._score.ToString();
    }
}
