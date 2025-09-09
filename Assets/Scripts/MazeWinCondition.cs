using UnityEngine;

public class MazeWinCondition : MonoBehaviour
{
    // The target position that triggers a win
    public Transform winPoint;

    // How close the player needs to be to "win"
    public float winDistance = 5.0f;

    // Reference to the player
    public Transform player;

    void Update()
    {
        // Calculate distance between player and win point
        float distanceToWin = Vector3.Distance(player.position, winPoint.position);

        // Check if player is within winDistance
        if (distanceToWin <= winDistance)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        Debug.Log("You Win!");
        
    }
}