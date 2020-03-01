using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPlateScript : MonoBehaviour {
    // Start is called before the first frame update
    
    public GameObject gameSystem;

    void Start () {
        
    }

    // Update is called once per frame
    void Update () {

    }

    void OnMouseDown () {
        Vector3 CurrentPosition = this.transform.position;
        Debug.Log ("Object clicked:" + CurrentPosition[0] + ":" + CurrentPosition[2]);
        gameSystem = GameObject.Find("GameSystem");
        gameSystem.SendMessage("SendPing", CurrentPosition);
    }
}