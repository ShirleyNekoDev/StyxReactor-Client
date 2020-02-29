using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using WebSocketSharp;

public class GameSystem : MonoBehaviour {

    private class Message {
        public String command;
        public dynamic payload;
    }

    // private String sample_world1 = @"{""width"":10,""height"":10,""grid"":[{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""}]}";
    public GameObject FloorPlate;
    public GameObject Wall;
    public GameObject Stealth;
    private WebSocket ws;

    void Awake () {
        UnityThread.initUnityThread ();

    }

    // Start is called before the first frame update
    void Start () {
        ws = new WebSocket ("ws://localhost:25566/ws");
        ws.OnMessage += (sender, e) => {
            Debug.Log ("Received: " + e.Data);
            dynamic msg = JsonConvert.DeserializeObject<Message> (e.Data);
            if (msg.command == "set_world") {
                this.InstantiateWorld (msg.payload);
            }
        };

        ws.Connect ();
        /*  ws.Send (
             @"{
             ""command"":""echo"",
             ""payload"":""hello world""
              }");        */
    }

    // Update is called once per frame
    void Update () {

    }

    void InstantiateWorld (dynamic json) {
        int width = json.width;
        int height = json.height;
        int i = 0;
        // Instantiate at position (0, 0, 0) and zero rotation.
        foreach (dynamic field in json.grid) {
            int x = i % width;
            int y = (i / width);
            Debug.Log ("X: " + x + " Y: " + y);
            UnityThread.executeInUpdate (() => {
                InstantiateField (field, x, y);
            });
            i++;
        }
    }

    void InstantiateField (dynamic field, int x, int y) {
        Instantiate (
            FloorPlate,
            new Vector3 ((float) x, -0.05f, (float) y),
            Quaternion.identity
        );
        if (field.type == "WALL") {
            Instantiate (
                Wall,
                new Vector3 ((float) x, 0.5f, (float) y),
                Quaternion.identity
            );
        }
        if (field.type == "ACCESSIBLE" && field.isStealth == true) {
            Instantiate (
                Stealth,
                new Vector3 ((float) x, 0.5f, (float) y),
                Quaternion.identity
            );
        }
    }
}