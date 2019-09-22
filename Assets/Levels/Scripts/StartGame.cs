using UnityEngine;
using UnityEditor;
using System.Collections;

public class StartGame : MonoBehaviour
{
    private void Awake()
    {
        // StartCoroutine(MusicStart());
    }

    private IEnumerator MusicStart()
    {
        WaitForSeconds wait = new WaitForSeconds(1.0f);
        yield return wait;
        AudioManager.instance.Play("Music1");
    }


}
