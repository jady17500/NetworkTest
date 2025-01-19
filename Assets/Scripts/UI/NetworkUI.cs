using Unity.Netcode;
using UnityEngine;

public class NetworkUI : MonoBehaviour
{
    
    public GameObject canvas;

    public void HostGame()
    {
        NetworkManager.Singleton.StartHost();
        Destroy(canvas);
    }

    public void JoinGame()
    {
        NetworkManager.Singleton.StartClient();
        Destroy(canvas);
    }


    public void LeaveGame()
    {
        Application.Quit();
    }
    
}
