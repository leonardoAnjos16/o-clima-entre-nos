using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static int missionIndex;
    private static Mission[] missions;

    public GameObject congratulationsPanel;

    void Awake() {
        missionIndex = 0;
        missions = Resources.LoadAll<Mission>("Missions");
        missions[0].Init();
    }

    public static Mission GetMission() {
        return missions[missionIndex];
    }

    public static void NextMission() {
        // GameController gameController = FindObjectOfType<GameController>();
        // gameController.congratulationsPanel.SetActive(true);

        missionIndex++;
        if (missionIndex < missions.Length) {
            missions[missionIndex].Init();
        }
    }
}
