using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using Newtonsoft.Json;

public class GameSystem : MonoBehaviour
{

    private class Field{
        public String type;
        public String textureId;
        public bool isStealth = false;
    }

    private class World {
        public int width;
        public int height;
        public Field[] grid;
    }

    private String sample_world1 = @"{""width"":10,""height"":10,""grid"":[{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""ACCESSIBLE"",""isStealth"":false,""textureId"":""empty""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""},{""type"":""WALL"",""textureId"":""wall""}]}";
    public GameObject FloorPlate;
    public GameObject Wall;

    private World world;
    // Start is called before the first frame update
    void Start()
    {
        using (var ws = new WebSocket ("ws://localhost:25566/ws")) {
            ws.OnMessage += (sender, e) =>
                Debug.Log("Received: " + e.Data);

            ws.Connect ();
            ws.Send (
                @"{
                ""command"":""echo"",
                ""payload"":""hello world""
                }");
            Debug.Log("WS Connected");
        
        }

        world = JsonConvert.DeserializeObject<World>(sample_world1);

        // Instantiate at position (0, 0, 0) and zero rotation.
        for(int i = 0 ; i < world.grid.Length ; i++)
        {
            Instantiate(FloorPlate, new Vector3(i % world.width, -0.05f, (float)Math.Floor((double)i / world.width)), Quaternion.identity);
            if(world.grid[i].type == "WALL") Instantiate(Wall, new Vector3(i% world.width, 0.5f, (float)Math.Floor((double)i / world.width)), Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
