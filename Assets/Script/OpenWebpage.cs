using UnityEngine;

public class OpenWebpage : MonoBehaviour
{
    private string instagramUrl = "https://www.instagram.com/paintomary/";

    public void OpenPage()
    {
        Application.OpenURL(instagramUrl);
    }

}
