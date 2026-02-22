using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public RhythmManager rhythm;
    public Animator npcAnimator;
    public Animator PlayerAnimator;

    private enum GameState {NPCTurn, PlayerTurn }
    private GameState state = GameState.NPCTurn;

    private List<string> sequence = new List<string>();
    private int inputIndex = 0;

    private int lastBeat = -1;
    private int beatsPlayed = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateSequence(4);
    }

    // Update is called once per frame
    void Update()
    {
        if (rhythm.CurrentBeat != lastBeat)
        {
            lastBeat = rhythm.CurrentBeat;
            OnBeat();
        }
    }

    void GenerateSequence(int length)
    {
        string[] moves = { "Left", "Right", "Up", "Down" };

        for (int i = 0; i < length; i++)
        {
            sequence.Add(moves[Random.Range(0, moves.Length)]);
        }
    }

    void OnBeat()
    {
        if (state == GameState.NPCTurn)
        {
            if (beatsPlayed < sequence.Count)
            {
                npcAnimator.SetTrigger(sequence[beatsPlayed]);
                beatsPlayed++;
            }
            else
            {
                state = GameState.PlayerTurn;
                beatsPlayed = 0;
                inputIndex = 0;
            }
        }
    }

    public void PlayerInput(string move)
    {
        if (state != GameState.PlayerTurn)
            return;

        if (move == sequence[inputIndex])
        {
            PlayerAnimator.SetTrigger(move);
            inputIndex++;

            if (inputIndex >= sequence.Count)
            {
                Debug.Log("SUCCESS");
                state = GameState.NPCTurn;
                beatsPlayed = 0;
            }
        }
        else
        {
            Debug.Log("FAIL");
            state = GameState.NPCTurn;
            beatsPlayed = 0;
        }
    }

}
