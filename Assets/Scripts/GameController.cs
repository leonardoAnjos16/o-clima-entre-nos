using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Mission mission;
    public string nextScene;

    public AudioClip victorySound;
    public AudioSource soundEffectSource;
    private AudioSource backgroundMusicSource;
    
    public GameObject congratulationsPanel;
    public Text messageText;

    public float minX, maxX, minY, maxY;

    // Start is called before the first frame update
    void Start() {
        mission.Init();
        backgroundMusicSource = GetComponent<AudioSource>();
    }

    public void NextMission() {
        backgroundMusicSource.Stop();
        soundEffectSource.PlayOneShot(victorySound);
        StartCoroutine(ShowCongratulationsPanel());
    }

    private IEnumerator ShowCongratulationsPanel() {
        yield return new WaitForSeconds(1f);
        messageText.text = mission.message;
        congratulationsPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GoToNextMission() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextScene);
    }
}
