using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Net.Http;
using System.Net.Http.Headers;
using UnityEngine.XR;
using System.Linq;

public class VRControl : MonoBehaviour
{
    string url = "http://192.168.0.110:8000/run/?action=";
    public string leftControllerName = "Oculus Touch Controller - Left";
    public string rightControllerName = "Oculus Touch Controller - Right";
    private InputDevice leftController;
    private InputDevice rightController;

    // Start is called before the first frame update
    void Start()
    {
        SendCommands("http://192.168.0.110:8000/run/?");
        SendCommands(url + "setup");
        SendCommands(url + "bwready");
        SendCommands(url + "fwready");
        SendCommands(url + "camready");

        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);

        foreach (InputDevice device in devices)
        {
            if (device.name.Contains(leftControllerName))
            {
                leftController = device;
            }
            else if (device.name.Contains(rightControllerName))
            {
                rightController = device;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, devices);

        InputDevice leftController = devices.FirstOrDefault();
        if (leftController.isValid)
        {
            if (leftController.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 leftThumbstick))
            {
                float moveDirection = leftThumbstick.y;

                if (moveDirection > 0.5)
                {
                    SendCommands(url + "forward");
                }
                else if (moveDirection < -0.5)
                {
                    SendCommands(url + "backward");
                }
                else
                {
                    SendCommands(url + "stop");
                }

                float turnDirection = leftThumbstick.x;

                if (turnDirection > 0.5)
                {
                    SendCommands(url + "fwright");
                }
                else if (turnDirection < -0.5)
                {
                    SendCommands(url + "fwleft");
                }
                else
                {
                    SendCommands(url + "fwstraight");
                }
            }
        }

        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        InputDevice rightController = devices.FirstOrDefault();
        if (rightController.isValid)
        {
            if (rightController.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 rightThumbstick))
            {
                float camVerticalDirection = rightThumbstick.y;

                if (camVerticalDirection > 0.5)
                {
                    SendCommands(url + "camup");
                }
                else if (camVerticalDirection < -0.5)
                {
                    SendCommands(url + "camdown");
                }
                else
                {
                    SendCommands(url + "camready");
                }

                float camHorizontalDirection = rightThumbstick.x;

                if (camHorizontalDirection > 0.5)
                {
                    SendCommands(url + "camright");
                }
                else if (camHorizontalDirection < -0.5)
                {
                    SendCommands(url + "camleft");
                }
                else
                {
                    SendCommands(url + "camready");
                }
            }
        }
    }


    async void SendCommands(string url)
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