using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int sanity = 0;
    private int speed;
    int headsThreshold;

    [SerializeField] GameObject[] totalCoins;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < totalCoins.Length; i++)
        {
            totalCoins[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Clamping sanity to a maximum of 45, and minimum of -45
        // Meaning, a 45% additional chance to roll heads, or 45% less chance to roll heads

        if (sanity > 45)
        {
            sanity = 45;
        }
        else if(sanity < -45)
        {
            sanity = -45;
        }
    }

    void newTurn()
    {
        speed = UnityEngine.Random.Range(2, 7);

        headsThreshold = 50 + sanity;

        /*  To accurately determine whether a coin rolls heads or tails, we have headsThreshold.
         *  This takes the base percentage for a coin to be heads, which is 50%, and adds Sanity to it.
         *  If Sanity is positive, this will at most be a 95. Meaning, a 95% chance to roll heads.
         *  Alternative, if Sanity is negative, it will at minimum be 5. Meaning a 5% chance to roll heads.
         *  To determine the roll, I will just have an if statement checking to see if a random.range() returns a value greater than the threshold.
         *  If it does, then it is tails. Otherwise, it's heads.
         */
    }

    void SkillOne()
    {
        int coinCount = 1;
        int coinValue = 15;

        // Minimum: 0
        // Maximum: 15

        int clashValue = 0;

        for (int i = 0; i <= coinCount; i++)
        {
            int headsOrTails = UnityEngine.Random.Range(0, 100);

            if (headsOrTails <= headsThreshold) // heads
            {
                clashValue += coinValue;
            }
        }
    }

    void SkillTwo()
    {
        // this skill I'm using to simulate a negative coin ID, meaning tails increases clash power

        int coinCount = 3;
        int coinValue = 7;

        // Minimum: 0
        // Maximum: 21

        int clashValue = 0;

        for (int i = 0; i <= coinCount; i++)
        {
            int headsOrTails = UnityEngine.Random.Range(0, 100);

            if (headsOrTails >= headsThreshold) // tails
            {
                clashValue += coinValue;
            }
        }
    }

    void SkillThree()
    {
        int coinCount = 5;
        int coinValue = 6;

        // Minimum: 0
        // Maximum: 30

        int clashValue = 0;

        for (int i = 0; i <= coinCount; i++)
        {
            int headsOrTails = UnityEngine.Random.Range(0, 100);

            if (headsOrTails <= headsThreshold) // heads
            {
                clashValue += coinValue;
            }
        }
    }
}
