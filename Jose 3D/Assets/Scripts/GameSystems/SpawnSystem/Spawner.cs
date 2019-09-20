using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public TextAsset spawnData;
    Queue<SpawnWave> spawnWaves;

    Queue<string> spawnQueue;
    int activeEntityLimit;
    public float spawnDelay;
    float currentTimer;
    float currentDelta;
    float variantTimer;

    // Start is called before the first frame update
    void Start () {
        spawnQueue = new Queue<string> ();
        spawnWaves = new Queue<SpawnWave> ();

        if (spawnData) {
            ParseData (spawnData.text);
        }

        Debug.Log (spawnWaves.Count + " Waves were created");
        Debug.Log ("First wave has " + spawnWaves.Peek ().enemies.Length + " enemies");
        Debug.Log ("First enemy is " + spawnWaves.Peek ().enemies[0]);

        FillQueue ();
    }

    // Update is called once per frame
    void Update () {
        currentTimer += Time.deltaTime;
        ResetTimer (SpawnEntity);
    }

    void ResetTimer (Action action) {
        if (currentTimer >= spawnDelay) {
            action.Invoke ();
            currentTimer = 0;
        }
    }

    void FillQueue () {
        SpawnWave wave = spawnWaves.Dequeue ();
        foreach (string enemy in wave.enemies) {
            spawnQueue.Enqueue (enemy);
        }
        spawnDelay = wave.startTime;
        currentDelta = wave.timeDelta;
        variantTimer = wave.timer;
    }

    void ParseData (string textData) {
        XDocument xmlData = XDocument.Parse (textData);

        foreach (XElement element in xmlData.Root.Elements ()) {
            float startTime = float.Parse (element.Attribute ("startTime").Value);
            float timer = float.Parse (element.Attribute ("timer").Value);
            float timeDelta = float.Parse (element.Attribute ("timeDelta").Value);
            SpawnWave wave = new SpawnWave (startTime, timer, timeDelta);

            List<string> enemies = new List<string> ();
            foreach (XElement enemy in element.Element ("enemies").Elements ()) {
                enemies.Add (enemy.Value);
            }

            wave.Populate (enemies.ToArray ());

            spawnWaves.Enqueue (wave);
        }
    }

    void SpawnEntity () {
        if (spawnQueue.Count > 0) {
            SpawnableEntity next = SpawnManager.instance.Search (spawnQueue.Dequeue ());
            next.Create (transform.position, Quaternion.identity);
            variantTimer += currentDelta;
            spawnDelay = variantTimer;

            if (spawnQueue.Count <= 0 && spawnWaves.Count > 0) {
                FillQueue ();
            }
        } else {
            Debug.LogWarning ("No more waves");
        }
    }

    void OnDrawGizmos () {
        Gizmos.DrawWireSphere (transform.position, 1);
    }
}
