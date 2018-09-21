using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Critter : MonoBehaviour {

    public Vector2 lowerRange;
    public Vector2 upperRange;

    public Timer timer;
    public Score scoreDisplay;

    public int pointValue = 1; //How much is this critter worth?

    private Vector2 direction; //What direction

    // Use this for initialization
    void Start () {
        transform.position = new Vector3(Random.Range(lowerRange.x, upperRange.x),
            Random.Range(lowerRange.y, upperRange.y), 
            0);

        //Pick random direction for critter
        direction.x = Random.Range(-1.0f, 1.0f);
        direction.y = Random.Range(-1.0f, 1.0f);
        direction = direction.normalized;

        //Rotate our critter in this direction 
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }

	// Update is called once per frame
	void Update () {

        transform.Translate(Vector2.up * Time.deltaTime);

		if (timer.IsTimerRunning() == false)
        {
            Destroy(gameObject);
        }
	}

    //Unity calls this when critter is clicked
    private void OnMouseDown()
    {
        scoreDisplay.ChangeValue(pointValue);
        Destroy(gameObject);
    }
}
