using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameUtilities;

[System.Serializable]
public struct PointData {
    public float[] position { get; private set; }
    public float[] rotation { get; private set; }

    public PointData (float[] position, float[] rotation) {
        this.position = position;
        this.rotation = rotation;
    }
}

[System.Serializable]
public class ScenePlayerData {
    public int itemCount { get; private set; }
    public PointData pointData;

    public void SetAllData (int itemCount, PointData pointData) {
        this.itemCount = itemCount;
        this.pointData = pointData;
    }
    public void SetAllData (int itemCount, float[] position, float[] rotation) {
        this.itemCount = itemCount;
        this.pointData = new PointData (position, rotation);
    }
}

public class SceneControl : MonoBehaviour {

    TransitionPanel panel;
    MovScript player;
    static public ScenePlayerData persistentPlayerData;
    Vector3 startPoint = new Vector3 (3, 1, 8);

    // Start is called before the first frame update
    void Start () {
        if (persistentPlayerData == null) {
            object readData = DataManagement.ReadDataFromFile ();
            if (readData != null) {
                persistentPlayerData = (ScenePlayerData)readData;
            } else {
                persistentPlayerData = new ScenePlayerData ();
                persistentPlayerData.SetAllData (0, startPoint.UnityToFloatArray (), Quaternion.identity.UnityToFloatArray ());
                DataManagement.WriteDataToFile (persistentPlayerData);
            }
        }
        player = GameObject.FindGameObjectWithTag ("Player").GetComponent<MovScript> ();
        player.activeControl = true;
        panel = TransitionPanel.instance;
        panel.Initialize ();
        player.GetComponent<PlayerAtributes> ().Initialize ();
    }

    void OnGUI () {
        GUI.Label (new Rect (10, 10, 120, 30), "Items collected: " + player.GetComponent<PlayerAtributes> ().itemCount);
    }

    public void LoadScene (int index) {
        if (index < SceneManager.sceneCount && index >= 0) {
            SceneManager.LoadScene (index);
        }
    }

    void OnTriggerExit (Collider other) {
        if (other.CompareTag("Player")) {
            player.activeControl = false;
            panel.StartCoroutine (RespawnRoutine ());
        }
    }

    IEnumerator RespawnRoutine () {
        yield return new WaitForSeconds (0.75f);
        yield return panel.FadeAlpha (1);
        LoadScene (SceneManager.GetActiveScene ().buildIndex);
        yield return new WaitForSeconds (1);
        yield return panel.FadeAlpha (0);
    }
}
