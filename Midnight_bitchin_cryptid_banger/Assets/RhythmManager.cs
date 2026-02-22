using UnityEngine;

public class RhythmManager : MonoBehaviour
{
    public AudioSource audioSource;
    public float bpm = 110f;

    private float secondsPerBeat;
    private float songStartDspTime;

    public int CurrentBeat {get; private set;}

    void Start()
    {
        secondsPerBeat = 60f / bpm;
        songStartDspTime = (float)AudioSettings.dspTime;
        audioSource.PlayScheduled(songStartDspTime);
    }

    void update()
    {
        float songTime = (float)(AudioSettings.dspTime - songStartDspTime);
        CurrentBeat = Mathf.FloorToInt(songTime / secondsPerBeat);
    }
}
