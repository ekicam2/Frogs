using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsHandler : MonoBehaviour {

    public void onPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void onShop()
    {
        Debug.Log("TODO: implement shop");
    }

    public void onExit()
    {
        Application.Quit();
    }
}
