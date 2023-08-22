using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Naninovel;

public class EndStory : MonoBehaviour
{
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        AsyncStart();
    }

    public void Click()
    {
        AsyncClick();
    }

    async void AsyncStart()
    {
        await RuntimeInitializer.InitializeAsync();
        canvas.worldCamera = GameObject.Find("UICamera").GetComponent<Camera>();
    }

    async void AsyncClick()
    {
        var player = Engine.GetService<IScriptPlayer>();
        
        // await player.PreloadAndPlayAsync("StartStory");
        await player.PreloadAndPlayAsync("EndStory");
        canvas.gameObject.SetActive(false);
    }
}
