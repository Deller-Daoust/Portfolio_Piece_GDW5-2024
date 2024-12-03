using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int sanity = 0;
    private int speed;
    public int health = 200;
    int headsThreshold;

    [SerializeField] GameObject gameManager;
    GameManager gameScript;

    [SerializeField] GameObject[] totalCoins;

    [SerializeField] GameObject Enemy;

    [SerializeField] Text healthText;
    [SerializeField] Text sanityText;
    [SerializeField] Text clashValueText;

    [SerializeField] Text coinOneText;
    [SerializeField] Text coinTwoText;
    [SerializeField] Text coinThreeText;
    [SerializeField] Text coinFourText;
    [SerializeField] Text coinFiveText;

    public bool clashComplete = false;

    public int selectedSkill = 0;

    public int totalClashValue = 0;
    public int coinCount = 0;

    bool playerWon = false;
    bool turnStarted = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < totalCoins.Length; i++)
        {
            totalCoins[i].SetActive(false);
        }

        gameScript = gameManager.GetComponent<GameManager>();
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

        // UI

        healthText.text = health.ToString();
        sanityText.text = sanity.ToString();
        clashValueText.text = totalClashValue.ToString();
    }

    public void NewTurn()
    {
        if(playerWon == true)
        {
            Enemy.GetComponent<Enemy>().NewTurn();
            playerWon = false;
        }

        speed = UnityEngine.Random.Range(2, 7);

        headsThreshold = 50 + sanity;

        totalClashValue = 0;

        turnStarted = true;

        for(int i = 0; i < totalCoins.Length; i++)
        {
            totalCoins[i].SetActive(false);
        }

        /*  To accurately determine whether a coin rolls heads or tails, we have headsThreshold.
         *  This takes the base percentage for a coin to be heads, which is 50%, and adds Sanity to it.
         *  If Sanity is positive, this will at most be a 95. Meaning, a 95% chance to roll heads.
         *  Alternative, if Sanity is negative, it will at minimum be 5. Meaning a 5% chance to roll heads.
         *  To determine the roll, I will just have an if statement checking to see if a random.range() returns a value greater than the threshold.
         *  If it does, then it is tails. Otherwise, it's heads.
         */
    }

    public void SkillOne()
    {
        if(turnStarted == true)
        {
            gameScript.startOfTurn = true;
            turnStarted = false;
        }

        selectedSkill = 1;
        coinCount = 1;
        int coinValue = 15;

        // Minimum: 0
        // Maximum: 15

        totalClashValue = 0;

        if (totalCoins[2].activeSelf == false)
        {
            totalCoins[2].SetActive(true);
        }

        for (int i = 1; i <= coinCount; i++)
        {
            int headsOrTails = UnityEngine.Random.Range(0, 100);

            if (headsOrTails <= headsThreshold) // heads
            {
                totalClashValue += coinValue;

                switch(i)
                {
                    case 1:
                        coinOneText.text = "H";
                        break;
                    case 2:
                        coinTwoText.text = "H";
                        break;
                    case 3:
                        coinThreeText.text = "H";
                        break;
                    case 4:
                        coinFourText.text = "H";
                        break;
                    case 5:
                        coinFiveText.text = "H";
                        break;
                }
            }
            else // Tails
            {
                switch (i)
                {
                    case 1:
                        coinOneText.text = "T";
                        break;
                    case 2:
                        coinTwoText.text = "T";
                        break;
                    case 3:
                        coinThreeText.text = "T";
                        break;
                    case 4:
                        coinFourText.text = "T";
                        break;
                    case 5:
                        coinFiveText.text = "T";
                        break;
                }
            }
        }

        gameScript.TurnStart();
    }

    public void SkillOneDamage()
    {
        coinCount = 1;
        playerWon = true;

        for (int i = 1; i <= coinCount; i++)
        {
            int headsOrTails = UnityEngine.Random.Range(0, 100);

            if (headsOrTails <= headsThreshold) // heads
            {
                Enemy.GetComponent<Enemy>().health -= 10;

                switch (i)
                {
                    case 1:
                        coinOneText.text = "H";
                        break;
                    case 2:
                        coinTwoText.text = "H";
                        break;
                    case 3:
                        coinThreeText.text = "H";
                        break;
                    case 4:
                        coinFourText.text = "H";
                        break;
                    case 5:
                        coinFiveText.text = "H";
                        break;
                }
            }
            else // tails
            {
                Enemy.GetComponent<Enemy>().health -= 5;

                switch (i)
                {
                    case 1:
                        coinOneText.text = "T";
                        break;
                    case 2:
                        coinTwoText.text = "T";
                        break;
                    case 3:
                        coinThreeText.text = "T";
                        break;
                    case 4:
                        coinFourText.text = "T";
                        break;
                    case 5:
                        coinFiveText.text = "T";
                        break;
                }
            }
        }

        NewTurn();
    }

    public void SkillTwo()
    {
        // this skill I'm using to simulate a negative coin ID, meaning tails increases clash power

        if (turnStarted == true)
        {
            gameScript.startOfTurn = true;
            turnStarted = false;
        }

        selectedSkill = 2;

        coinCount = 3;
        int coinValue = 7;

        // Minimum: 0
        // Maximum: 21

        totalClashValue = 0;

        if (totalCoins[1].activeSelf == false)
        {
            totalCoins[1].SetActive(true);
        }
        if (totalCoins[2].activeSelf == false)
        {
            totalCoins[2].SetActive(true);
        }
        if (totalCoins[3].activeSelf == false)
        {
            totalCoins[3].SetActive(true);
        }

        for (int i = 1; i <= coinCount; i++)
        {
            int headsOrTails = UnityEngine.Random.Range(0, 100);

            if (headsOrTails >= headsThreshold) // tails
            {
                totalClashValue += coinValue;

                switch (i)
                {
                    case 1:
                        coinOneText.text = "H";
                        break;
                    case 2:
                        coinTwoText.text = "H";
                        break;
                    case 3:
                        coinThreeText.text = "H";
                        break;
                    case 4:
                        coinFourText.text = "H";
                        break;
                    case 5:
                        coinFiveText.text = "H";
                        break;
                }
            }
            else // Tails
            {
                switch (i)
                {
                    case 1:
                        coinOneText.text = "T";
                        break;
                    case 2:
                        coinTwoText.text = "T";
                        break;
                    case 3:
                        coinThreeText.text = "T";
                        break;
                    case 4:
                        coinFourText.text = "T";
                        break;
                    case 5:
                        coinFiveText.text = "T";
                        break;
                }
            }
        }

        gameScript.TurnStart();
    }

    public void SkillTwoDamage()
    {
        coinCount = 3;
        playerWon = true;

        for (int i = 1; i <= coinCount; i++)
        {
            int headsOrTails = UnityEngine.Random.Range(0, 100);

            if (headsOrTails <= headsThreshold) // heads
            {
                Enemy.GetComponent<Enemy>().health -= 14;

                switch (i)
                {
                    case 1:
                        coinOneText.text = "H";
                        break;
                    case 2:
                        coinTwoText.text = "H";
                        break;
                    case 3:
                        coinThreeText.text = "H";
                        break;
                    case 4:
                        coinFourText.text = "H";
                        break;
                    case 5:
                        coinFiveText.text = "H";
                        break;
                }
            }
            else // tails
            {
                Enemy.GetComponent<Enemy>().health -= 7;

                switch (i)
                {
                    case 1:
                        coinOneText.text = "T";
                        break;
                    case 2:
                        coinTwoText.text = "T";
                        break;
                    case 3:
                        coinThreeText.text = "T";
                        break;
                    case 4:
                        coinFourText.text = "T";
                        break;
                    case 5:
                        coinFiveText.text = "T";
                        break;
                }
            }
        }

        NewTurn();
    }

    public void SkillThree()
    {
        if (turnStarted == true)
        {
            gameScript.startOfTurn = true;
            turnStarted = false;
        }

        selectedSkill = 3;

        coinCount = 5;
        int coinValue = 6;

        // Minimum: 0
        // Maximum: 30

        totalClashValue = 0;

        for (int i = 1; i <= totalCoins.Length; i++)
        {
            if (totalCoins[i].activeSelf == false)
            {
                totalCoins[i].SetActive(true);
            }
        }

        for (int i = 0; i <= coinCount; i++)
        {
            int headsOrTails = UnityEngine.Random.Range(0, 100);

            if (headsOrTails <= headsThreshold) // heads
            {
                totalClashValue += coinValue;

                switch (i)
                {
                    case 1:
                        coinOneText.text = "H";
                        break;
                    case 2:
                        coinTwoText.text = "H";
                        break;
                    case 3:
                        coinThreeText.text = "H";
                        break;
                    case 4:
                        coinFourText.text = "H";
                        break;
                    case 5:
                        coinFiveText.text = "H";
                        break;
                }
            }
            else // Tails
            {
                switch (i)
                {
                    case 1:
                        coinOneText.text = "T";
                        break;
                    case 2:
                        coinTwoText.text = "T";
                        break;
                    case 3:
                        coinThreeText.text = "T";
                        break;
                    case 4:
                        coinFourText.text = "T";
                        break;
                    case 5:
                        coinFiveText.text = "T";
                        break;
                }
            }
        }

        gameScript.TurnStart();
    }

    public void SkillThreeDamage()
    {
        coinCount = 5;
        playerWon = true;

        for (int i = 1; i <= coinCount; i++)
        {
            int headsOrTails = UnityEngine.Random.Range(0, 100);

            if (headsOrTails <= headsThreshold) // heads
            {
                Enemy.GetComponent<Enemy>().health -= 20;

                switch (i)
                {
                    case 1:
                        coinOneText.text = "H";
                        break;
                    case 2:
                        coinTwoText.text = "H";
                        break;
                    case 3:
                        coinThreeText.text = "H";
                        break;
                    case 4:
                        coinFourText.text = "H";
                        break;
                    case 5:
                        coinFiveText.text = "H";
                        break;
                }
            }
            else // tails
            {
                Enemy.GetComponent<Enemy>().health -= 10;

                switch (i)
                {
                    case 1:
                        coinOneText.text = "T";
                        break;
                    case 2:
                        coinTwoText.text = "T";
                        break;
                    case 3:
                        coinThreeText.text = "T";
                        break;
                    case 4:
                        coinFourText.text = "T";
                        break;
                    case 5:
                        coinFiveText.text = "T";
                        break;
                }
            }
        }

        NewTurn();
    }
}
