using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private PlayableDirector director;
    private PlayerMotor playermotor;
    private Animator _Playeranimator;
   

    public CinemachineVirtualCamera _VirtualCam;

    public bool IsGameStarted = false;
    void Awake()
    {
        //Ininitalize all References
        References();
    }

    public void StartGame()
    {
        //Execute Intial logics
        IntialLogics();
    }
    IEnumerator TurnOffCutSceneCam()
    {
        yield return new WaitForSeconds(4f);
        _VirtualCam.Priority = 12;
    }
   
    public void OnGameOver()
    {
        Time.timeScale = 0;
    }


    #region INITIAL_LOGICS

    void IntialLogics()
    {
        GameEvents.GameOver += OnGameOver;
        IsGameStarted = true;
        director.Play();
        playermotor._isCutsceneComplete = true;
        _Playeranimator.SetBool("start", true);
        StartCoroutine(TurnOffCutSceneCam());
    }
    #endregion

    #region REFERENCES

    void References()
    {
        director = FindAnyObjectByType<PlayableDirector>();
        playermotor = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>();
        _Playeranimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    #endregion
}
