using System;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private int sanity = 0;
    private int speed;
    public int health = 200;
    int headsThreshold;

    [SerializeField] GameObject gameManager;
    GameManager gameScript;

    [SerializeField] GameObject[] totalCoins;

    public int selectedSkill;

    [SerializeField] GameObject Player;

    [SerializeField] Text healthText;
    [SerializeField] Text sanityText;

    [SerializeField] Text coinOneText;
    [SerializeField] Text coinTwoText;
    [SerializeField] Text coinThreeText;
    [SerializeField] Text coinFourText;
    [SerializeField] Text coinFiveText;

    public int totalClashValue = 0;
    public int coinCount = 0;

    bool enemyWon = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < totalCoins.Length; i++)
        {
            totalCoins[i].SetActive(false);
        }

        selectedSkill = UnityEngine.Random.Range(1, 3);

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
        else if (sanity < -45)
        {
            sanity = -45;
        }

        healthText.text = health.ToString();
        sanityText.text = sanity.ToString();
    }

    public void NewTurn()
    {
        if(enemyWon == true)
        {
            Player.GetComponent<Player>().NewTurn();
            enemyWon = false;
        }

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

    public void SkillOne()
    {
        coinCount = 1;
        int coinValue = 15;

        // Minimum: 0
        // Maximum: 15

        totalClashValue = 0;

        totalCoins[2].SetActive(true);

        for (int i = 1; i <= coinCount; i++)
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
    }

    public void SkillOneDamage()
    {
        coinCount = 1;
        enemyWon = true;

        for (int i = 1; i <= coinCount; i++)
        {
            int headsOrTails = UnityEngine.Random.Range(0, 100);

            if (headsOrTails <= headsThreshold) // heads
            {
                Player.GetComponent<Player>().health -= 10;

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
                Player.GetComponent<Player>().health -= 5;

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
    }

    public void SkillTwo()
    {
        // this skill I'm using to simulate a negative coin ID, meaning tails increases clash power

        coinCount = 3;
        int coinValue = 7;

        // Minimum: 0
        // Maximum: 21

        totalClashValue = 0;

        totalCoins[1].SetActive(true);
        totalCoins[2].SetActive(true);
        totalCoins[3].SetActive(true);

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
    }

    public void SkillTwoDamage()
    {
        coinCount = 3;
        enemyWon = true;

        for (int i = 1; i <= coinCount; i++)
        {
            int headsOrTails = UnityEngine.Random.Range(0, 100);

            if (headsOrTails <= headsThreshold) // heads
            {
                Player.GetComponent<Player>().health -= 14;

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
                Player.GetComponent<Player>().health -= 7;

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
    }

    public void SkillThree()
    {
        coinCount = 5;
        int coinValue = 6;

        // Minimum: 0
        // Maximum: 30

        totalClashValue = 0;

        for (int i = 0; i < totalCoins.Length; i++)
        {
            totalCoins[i].SetActive(true);
        }

        for (int i = 1; i <= coinCount; i++)
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
    }

    public void SkillThreeDamage()
    {
        coinCount = 5;
        enemyWon = true;

        for (int i = 1; i <= coinCount; i++)
        {
            int headsOrTails = UnityEngine.Random.Range(0, 100);

            if (headsOrTails <= headsThreshold) // heads
            {
                Player.GetComponent<Player>().health -= 20;

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
                Player.GetComponent<Player>().health -= 10;

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
    }
}
