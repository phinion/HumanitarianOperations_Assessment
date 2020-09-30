using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ClickMonitor : Interactable
{
    public override void Interact()
    {
        base.Interact();
        playVideo();
    }

    // play video
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
