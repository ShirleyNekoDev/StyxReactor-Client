using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class GameSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        using (var ws = new WebSocket ("ws://localhost:25566/ws")) {
            ws.OnMessage += (sender, e) =>
                Debug.Log("Received: " + e.Data);

            ws.Connect ();
            ws.Send ("WS Connected");
            Debug.Log("WS Connected");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
