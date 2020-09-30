using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ClickMonitor : Interactable
{
    // Start is called before the first frame update
    public override void Interact()
    {
        base.Interact();
        playVideo();
    }

    // Update is called once per frame
    void playVideo()
    {
        VideoPlayer vp = this.gameObject.GetComponent<VideoPlayer>();
        if (vp.isPlaying)
        {
            vp.Pause();
        }
        else
        {
            vp.Play();
        }
    }
}
