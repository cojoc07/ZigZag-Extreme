using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCounter : MonoBehaviour {

    private int framesPerSecond;
    private float frequency = 1.0f;
    private string fps;

    void Start()
    {
        StartCoroutine(FPS());
    }

    private IEnumerator FPS()
    {
        for (;;)
        {
            int lastFrameCount = Time.frameCount;
            float lastTime = Time.realtimeSinceStartup;
            yield return new WaitForSeconds(frequency);

            float timeSpan = Time.realtimeSinceStartup - lastTime;
            int framecount = Time.frameCount - lastFrameCount;

            fps = string.Format("FPS: {0}", Mathf.RoundToInt(framecount / timeSpan));

        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width - 100, 10, 350, 120), fps);
    }

}
