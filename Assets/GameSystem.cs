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
        public Message (String _command, dynamic _payload) {
            command = _command;
            payload = _payload;
        }
    }

    public GameObject FloorPlate;
    public GameObject Wall;
    public GameObject Stealth;
    public GameObject Ping;

    public String player = "Local Player";

    private WebSocket ws;

    void Awake () {
        UnityThread.initUnityThread ();

    }

    // Start is called before the first frame update
    void Start () {
        // todo could not connect warning
        ws = new WebSocket ("ws://localhost:25566/ws");
        ws.OnMessage += (sender, e) => {
            Debug.Log ("Received: " + e.Data);
            dynamic msg = JsonConvert.DeserializeObject<Message> (e.Data);
            messageHandler (msg);
        };

        ws.Connect ();
    }

    // Update is called once per frame
    void Update () {

    }

    class Position {
        public int x;
        public int y;
        public Position (int _x, int _y) {
            x = _x;
            y = _y;
        } 
    }

    class PingPayload {
        public Position position;
        public String type;
        public String player;
        public PingPayload (Position _position, String _type, String _player) {
            position = _position;
            type = _type;
            player = _player;
        }
    }

    // Sending
    void SendPing (Vector3 position) {
        Debug.Log ("send Ping Log");
        int x = (int) position.x;
        int z = (int) position.z;
        // String message = "Test";
        // String blueprint = $@"{{
        //      ""command"":""ping"",
        //      ""payload"":
        //      ""position"": {x},{z},
        //      ""type"":{message}
        //      }}";
        var message = new Message(
            "ping",
            new PingPayload(
                new Position(x, z),
                "ATTENTION",
                player
            )
        );
        ws.Send (JsonConvert.SerializeObject(message));
    }

    // Receiving
    void messageHandler (dynamic message) {
        switch (message.command) {
            case "set_world":
                this.InstantiateWorld (message.payload);
                break;
            case "ping":
                this.InstantiatePing (message.payload);
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

    void InstantiatePing (dynamic json) {
        Vector2 position = new Vector2((float) json.position.x, (float) json.position.y);
        // todo json.player
        // todo json.type
        Debug.Log("Player \"" + json.player + "\" pinged " + json.type + " at x=" + position.x + ", y=" + position.y);
        UnityThread.executeInUpdate (() => {
            Instantiate(
                Ping,
                new Vector3(position.x, 0, position.y),
                Quaternion.Euler(-90, 0, 0)
            );
        });
    }
}