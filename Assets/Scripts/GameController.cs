using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int missionIndex;
    public Mission[] missions;

    // Start is called before the first frame update
    void Start()
    {
        missionIndex = 0;
        foreach (Mission mission in missions) {
            mission.Create(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Mission GetMission() {
        return missions[missionIndex];
    }

    public void NextMission() {
        missionIndex++;
    }
}
