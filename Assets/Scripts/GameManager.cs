using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private PlayableDirector director;
    private PlayerMotor playermotor;
    private Animator _Playeranimator;
    private Animator _DogAnimator;

    public bool IsGameStarted = false;
    void Awake()
    {
        director = FindAnyObjectByType<PlayableDirector>();
        playermotor = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>();
        _Playeranimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        _DogAnimator = GameObject.Find("Dog").GetComponent<Animator>();
    }

    public void StartGame()
    {
        IsGameStarted = true;
        _DogAnimator.SetBool("Run", true);
        director.Play();
        playermotor._isCutsceneComplete = true;
        _Playeranimator.SetBool("start",true);
        StartCoroutine(TurnOffCutSceneCam());
    }
    IEnumerator TurnOffCutSceneCam()
    {
        yield return new WaitForSeconds(3.5f);
        director.Pause();
      
    }
   
}
