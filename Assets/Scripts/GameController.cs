using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static int missionIndex;
    private static Mission[] missions;
    public static bool finishedMission;

    public AudioClip victorySound;
    public AudioSource soundEffectSource;
    private AudioSource backgroundMusicSource;
    public GameObject congratulationsPanel;

    void Awake() {
        missionIndex = 0;
        finishedMission = false;
        backgroundMusicSource = GetComponent<AudioSource>();

        missions = Resources.LoadAll<Mission>("Missions");
        missions[0].Init();
    }

    public static Mission GetMission() {
        return missions[missionIndex];
    }

    public static void NextMission() {
        missionIndex++;
        finishedMission = true;

        if (missionIndex < missions.Length) {
            missions[missionIndex].Init();
        }

        GameController gameController = FindObjectOfType<GameController>();
        gameController.backgroundMusicSource.Stop();
        gameController.soundEffectSource.PlayOneShot(gameController.victorySound);
        gameController.StartCoroutine(ShowCongratulationsPanel(gameController));
    }

    public static IEnumerator ShowCongratulationsPanel(GameController gameController) {
        yield return new WaitForSeconds(1f);
        gameController.congratulationsPanel.SetActive(true);
    }

    public void GoToNextMission() {
        finishedMission = false;
        congratulationsPanel.SetActive(false);
    }
}
