using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<GameObject> critterPrefabs;
    public float critterSpawnFrequency = 1.0f;
    private float lastCritterSpawn = 0;
    public Score scoreDisplay;
    public Timer timer;
    public SpriteRenderer button;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Check if it's time to spawn critter
        float nextSpawnTime = lastCritterSpawn + critterSpawnFrequency;

        if (Time.time >= nextSpawnTime  && timer.IsTimerRunning() == true)

        {
            //It is time!
            //Choose a random critter to spawn
            int critterIndex = Random.Range(0, critterPrefabs.Count);
            GameObject prefabToSpawn = critterPrefabs[critterIndex];

            //Spawn the critter
            GameObject spawnedCritter = Instantiate(prefabToSpawn);

            //Get access to critter script
            Critter critterScript = spawnedCritter.GetComponent<Critter>();

            //Tell critter script score object
            critterScript.scoreDisplay = scoreDisplay;
            critterScript.timer = timer;

            //Update most recent spawn time to now
            lastCritterSpawn = Time.time;
        }

        //Update button visibility 
        if (timer.IsTimerRunning() == true)
        {
            button.enabled = false;
        }
        else //Game not running
        {
            button.enabled = true; 
        }
	}
    //Did they click button?
    private void OnMouseDown()
    {
        if (timer.IsTimerRunning() == false)
        {
            timer.StartTimer();
            scoreDisplay.ResetScore();
        }
    }
}
