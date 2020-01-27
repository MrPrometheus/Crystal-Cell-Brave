using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingAudio : MonoBehaviour
{
    public AudioClip _audioClip;
    private AudioSource _audioSource;

    private ChangedTrackableEventHandler _trackableEvent;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _audioClip;

        _trackableEvent = GetComponentInParent<ChangedTrackableEventHandler>();
        _trackableEvent.NotifyOnTrackingFound += TrackableEvent_NotifyOnTrackingFound;
        _trackableEvent.NotifyOnTrackingLost += TrackableEvent_NotifyOnTrackingLost;
    }

    private void TrackableEvent_NotifyOnTrackingLost()
    {
        _audioSource.Stop();
    }

    private void TrackableEvent_NotifyOnTrackingFound()
    {
        _audioSource.Play();
    }
}
