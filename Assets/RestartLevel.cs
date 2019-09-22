using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class RestartLevel : MonoBehaviour
{
    public void RestartLevelLaunch()
    {
        SteamVR_Fade.Start(Color.black, 1f);
        StartCoroutine(FadeAndRestart());
    }

    private IEnumerator FadeAndRestart()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        yield return new WaitForSeconds(0.5f);
        SteamVR_Fade.Start(Color.clear, 1f);
    }
}
