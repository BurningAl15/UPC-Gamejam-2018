using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public string name;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        Time.timeScale = 1f;
        if (maxCatCounter <= 0)
            maxCatCounter = 1;
    }

    private int counter = 0;
    public GameObject pauseMenu;
    public Text kittenCounter;
    bool isPaused;
    public int maxCatCounter;

    #region //States and stuff
    //public enum GameState { alive, playing, destroyedShip, dead};
    //GameState state;

    //PlayerBehaviour player;

    //public void OnEnterState()
    //{
    //    switch (state)
    //    {
    //        case GameState.alive:

    //            break;

    //        case GameState.playing:

    //            break;

    //        case GameState.destroyedShip:

    //            break;

    //        case GameState.dead:

    //            break;

    //    }
    //}

    //private void SetState(GameState _state)
    //{
    //    state = _state;
    //}

    //public void Alive()
    //{
    //    SetState(GameState.alive);
    //}

    //public void Playing()
    //{
    //    SetState(GameState.playing);
    //}

    //public void DestroyedShip()
    //{
    //    SetState(GameState.destroyedShip);
    //}

    //public void Dead()
    //{
    //    SetState(GameState.dead);
    //}
    #endregion

    public int GetCounter()
    {
        return counter;
    }

    public void AddCount()
    {
        counter++;
    }

    void Start() {
        isPaused = false;
        pauseMenu.SetActive(isPaused);
    }

    void Update() {
        if (counter >= maxCatCounter)
        {
            SceneManager.LoadScene(name);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("Boss");
        }
        kittenCounter.text = ""+ counter+"/"+maxCatCounter;
    }

    public void Pause()
    {
        isPaused = !isPaused;

        if(isPaused)
        {
            Time.timeScale = 0f;
        }
        else if (!isPaused)
        {
            Time.timeScale = 1f;
        }
        pauseMenu.SetActive(isPaused);
    }

    public void Restart(string name)
    {
        if(name=="0" || name=="")
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else
            SceneManager.LoadScene(name);
        Time.timeScale = 1f;
    }

}
