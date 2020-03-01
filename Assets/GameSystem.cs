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
    public GameObject Ping;

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
            messageHandler (msg);
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

    // Sending

    void SendPing (Vector3 position) {
        Debug.Log ("send Ping Log");
        int x = (int) position.x;
        int z = (int) position.z;
        String message = "Test";
        String blueprint = $@"{{
             ""command"":""ping"",
             ""payload"":
             ""position"": {x},{z},
             ""type"":{message}
             }}";
        //string sending = string.Format(blueprint, x.ToString(), y.ToString(), message);
        Debug.Log("Gotthisfar");
        Debug.Log(blueprint); 
        ws.Send (blueprint);
        InstantiatePing (new Vector3(x, 0, z));
    }

    // Receiving
    void messageHandler (dynamic message) {
        switch (message.command) {
            case "set_world":
                this.InstantiateWorld (message.payload);
                break;
            default:
                break;
        }
    }

    void InstantiateWorld (dynamic json) {
        int width = json.width;
        int height = json.height;
        int i = 0;
        // Instantiate at position (0, 0, 0) and zero rotation.
        foreach (dynamic field in json.grid) {
            int x = -width / 2 + i % width;
            int y = height / 2 - (i / width);
            UnityThread.executeInUpdate (() => {
                InstantiateField (field, x, y);
            });
            i++;
        }
    }

    void InstantiateField (dynamic field, int x, int y) {
        if (field.type != "HOLE") {
            Instantiate (
                FloorPlate,
                new Vector3 ((float) x, -0.05f, (float) y),
                Quaternion.identity
            );
        }
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

    void InstantiatePing (Vector3 position) {
        Instantiate(
            Ping,
            position,
            Quaternion.identity
        );
    }
}