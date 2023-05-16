using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Net.Http;
using System.Net.Http.Headers;

public class Car : MonoBehaviour
{

    string url = "http://192.168.0.110:8000/run/?action=";
    // Start is called before the first frame update
    void Start()
    {
        SendCommand("http://192.168.0.110:8000/run/?");
        SendCommand(url + "setup");
        SendCommand(url + "bwready");
        SendCommand(url + "fwready");
        SendCommand(url + "camready");
    }

    // Update is called once per frame
    void Update()
    {
        // forward
        if (Input.GetKeyDown(KeyCode.W))
        {
            SendCommand(url + "forward");

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            SendCommand(url + "stop");
        }

        // backward
        if (Input.GetKeyDown(KeyCode.S))
        {
            SendCommand(url + "backward");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            SendCommand(url + "stop");
        }


        // left
        if (Input.GetKeyDown(KeyCode.A))
        {
            SendCommand(url + "fwleft");
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            SendCommand(url + "fwstraight");
        }

        // right
        if (Input.GetKeyDown(KeyCode.D))
        {
            SendCommand(url + "fwright");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            SendCommand(url + "fwstraight");
        }

        //Camera:

        // up
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SendCommand(url + "camup");
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            SendCommand(url + "camready");
        }
        // down
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SendCommand(url + "camdown");
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            SendCommand(url + "camready");
        }
        // left
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SendCommand(url + "camleft");
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            SendCommand(url + "camready");
        }
        // right
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SendCommand(url + "camright");
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            SendCommand(url + "camready");
        }
    }

    async void SendCommand(string url)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            Debug.Log(result);
        }
        else
        {
            Debug.Log("Error: " + response.StatusCode);
        }
    }
}