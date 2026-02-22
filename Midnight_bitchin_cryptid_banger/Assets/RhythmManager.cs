using UnityEngine;

public class RhythmManager : MonoBehaviour
{
    public AudioSource audioSource;
    public float bpm = 110f;

    private float secondsPerBeat;
    private float songPosition;
    private float songStartDspTime;

    public int currentBeat {get; private set;}

    void Start()
    {   
        audioSource = GetComponent<AudioSource>();
        secondsPerBeat = 60f / bpm;
        audioSource.Play();
        Debug.Log("rhythm manager has started ");
    }

    void Update()
    {
        songPosition = audioSource.time;
        int newBeat = Mathf.FloorToInt(songPosition/secondsPerBeat);
        
        if (newBeat != currentBeat)
        {  
            currentBeat = newBeat;
        }
        Debug.Log("song time: " + audioSource.time);
        
    }
}
