using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private Player player;

    public Mission mission;
    public string nextScene;

    public Texture2D mousePointer, mouseHand;

    public AudioClip victorySound;
    public AudioSource soundEffectSource;
    private AudioSource backgroundMusicSource;
    
    public GameObject congratulationsPanel;
    public Text messageText;

    public float minX, maxX, minY, maxY;

    // Start is called before the first frame update
    void Start() {
        mission.Init();
        player = FindObjectOfType<Player>();
        backgroundMusicSource = GetComponent<AudioSource>();
        Cursor.SetCursor(mousePointer, Vector2.zero, CursorMode.Auto);
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
        player.Stop();
    }

    public void GoToNextMission() {
        SceneManager.LoadScene(nextScene);
    }

    public void PlaySoundEffect(AudioClip clip) {
        soundEffectSource.PlayOneShot(clip);
    }
}
