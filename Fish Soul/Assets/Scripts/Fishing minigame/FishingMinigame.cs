using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FishingMinigame : MonoBehaviour
{
    [Header("Fishing Area")]
    [SerializeField] Transform topBounds;
    [SerializeField] Transform bottomBounds;

    [Header("Fish Settings")]
    [SerializeField] Transform fish;
    [SerializeField] float smoothMotion = 5f;
    [SerializeField] float fishTimeRandomizer = 5f;
    float fishPosition;
    float fishSpeed;
    float fishTimer;
    float fishTargetPosition;

    [Header("Hook Settings")]
    [SerializeField] Transform hook;
    [SerializeField] float hookSize = .18f;
    [SerializeField] float hookSpeed = .1f;
    [SerializeField] float hookGravity = .05f;
    float hookPosition;
    float hookPullVelocity;

    [Header("Progress Bar Settings")]
    [SerializeField] Transform progressBarContainer;
    [SerializeField] float hookPower;
    [SerializeField] float progressBarDecay;
    float catchProgress;

    private void Start()
    {
        catchProgress = .1f;
    }

    private void FixedUpdate()
    {
        MoveFish();
        MoveHook();
        CheckProgress();
    }

    private void CheckProgress()
    {
        Vector3 progressBarScale = progressBarContainer.localScale;
        progressBarScale.y = catchProgress;
        progressBarContainer.localScale = progressBarScale;


        float min = hookPosition - hookSize / 2;
        float max = hookPosition + hookSize / 2;

        if (min < fishPosition && fishPosition < max)
        {
            catchProgress += hookPower * Time.deltaTime;
            if (catchProgress >= 1)
            {
                //Won the game
                Debug.Log("You win!");
                SceneManager.UnloadSceneAsync("FishingMinigame");

                PlayerMovement.moveSpeed = 5f;
                //Do win logic here
            }
        }
        else
        {
            catchProgress -= progressBarDecay * Time.deltaTime;
            if (catchProgress <= 0)
            {
                //You lose
                Debug.Log("You lose!");
                SceneManager.UnloadSceneAsync("FishingMinigame");

                PlayerMovement.moveSpeed = 5f;
                //Lose logic here
            }
        }
        catchProgress = Mathf.Clamp(catchProgress, 0, 1);
    }

    private void MoveHook()
    {
        if (Input.GetMouseButton(0))
        {
            hookPullVelocity += hookSpeed * Time.deltaTime;
        }
        hookPullVelocity -= hookGravity * Time.deltaTime;

        hookPosition += hookPullVelocity;

        if (hookPosition - hookSize / 2 <= 0 && hookPullVelocity < 0)
        {
            hookPullVelocity = 0;
        }

        if (hookPosition + hookSize / 2 >= 1 && hookPullVelocity > 0)
        {
            hookPullVelocity = 0;
        }

        hookPosition = Mathf.Clamp(hookPosition, hookSize / 2, 1 - hookSize / 2);
        hook.position = Vector3.Lerp(bottomBounds.position, topBounds.position, hookPosition);
    }

    private void MoveFish()
    {
        fishTimer -= Time.deltaTime;
        if(fishTimer < 0)
        {
            fishTimer = Random.value * fishTimeRandomizer;
            fishTargetPosition = Random.value;
        }
        fishPosition = Mathf.SmoothDamp(fishPosition, fishTargetPosition, ref fishSpeed, smoothMotion);
        fish.position = Vector3.Lerp(bottomBounds.position, topBounds.position, fishPosition);
    }

}
