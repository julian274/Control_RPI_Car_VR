
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class SnapshotStreamViewer : MonoBehaviour
{
    public string snapshotUrl = "http://192.168.0.110:8080/?action=snapshot";
    public Renderer targetRenderer;
    public float interval = 1f / 30f; // Fetch 30 snapshots per second (30 FPS)
    public float retryDelay = 1f; // Retry after 5 seconds if there's an error

    private void Start()
    {
        if (targetRenderer == null)
        {
            targetRenderer = GetComponent<Renderer>();
        }

        if (targetRenderer != null)
        {
            StartCoroutine(GetSnapshotStream());
        }
    }

    private IEnumerator GetSnapshotStream()
    {
        while (true)
        {
            bool isError = false;
            using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(snapshotUrl))
            {
                Debug.Log("Sending request to: " + snapshotUrl);
                yield return request.SendWebRequest();

                try
                {
                    if (request.result == UnityWebRequest.Result.Success)
                    {
                        Texture2D texture = DownloadHandlerTexture.GetContent(request);
                        targetRenderer.material.mainTexture = texture;
                    }
                    else
                    {
                        Debug.LogError("Error while fetching snapshot: " + request.error);
                        isError = true;
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError("Error: " + e.Message);
                    isError = true;
                }
            }

            if (isError)
            {
                yield return new WaitForSeconds(retryDelay);
            }
            else
            {
                yield return new WaitForSeconds(interval);
            }
        }
    }
}