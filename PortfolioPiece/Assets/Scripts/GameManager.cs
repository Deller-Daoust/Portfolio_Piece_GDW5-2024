using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameManager instance;

    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;

    Player playerScript;
    Enemy enemyScript;

    public bool startOfTurn = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(instance != null && instance != this)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }

        playerScript = player.GetComponent<Player>();
        enemyScript = enemy.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnStart()
    {
        if (startOfTurn == true)
        {
            switch (enemyScript.selectedSkill)
            {
                case 1:
                    enemyScript.SkillOne();
                    break;
                case 2:
                    enemyScript.SkillTwo();
                    break;
                case 3:
                    enemyScript.SkillThree();
                    break;
            }

            startOfTurn = false;
        }

        if (playerScript.totalClashValue > enemyScript.totalClashValue)
        {
            if(enemyScript.coinCount > 0)
            {
                enemyScript.coinCount -= 1;

                switch (playerScript.selectedSkill)
                {
                    case 1:
                        playerScript.SkillOne();
                        break;
                    case 2:
                        playerScript.SkillTwo();
                        break;
                    case 3:
                        playerScript.SkillThree();
                        break;
                }

                switch (enemyScript.selectedSkill)
                {
                    case 1:
                        enemyScript.SkillOne();
                        break;
                    case 2:
                        enemyScript.SkillTwo();
                        break;
                    case 3:
                        enemyScript.SkillThree();
                        break;
                }
            }
            else
            {
                switch(playerScript.selectedSkill)
                {
                    case 1:
                        playerScript.SkillOneDamage();
                        break;
                    case 2:
                        playerScript.SkillTwoDamage();
                        break;
                    case 3:
                        playerScript.SkillThreeDamage();
                        break;
                }
            }
        }
        else if (playerScript.totalClashValue < enemyScript.totalClashValue)
        {
            if (enemyScript.coinCount > 0)
            {
                playerScript.coinCount -= 1;

                switch (playerScript.selectedSkill)
                {
                    case 1:
                        playerScript.SkillOne();
                        break;
                    case 2:
                        playerScript.SkillTwo();
                        break;
                    case 3:
                        playerScript.SkillThree();
                        break;
                }

                switch (enemyScript.selectedSkill)
                {
                    case 1:
                        enemyScript.SkillOne();
                        break;
                    case 2:
                        enemyScript.SkillTwo();
                        break;
                    case 3:
                        enemyScript.SkillThree();
                        break;
                }
            }
            else
            {
                switch (enemyScript.selectedSkill)
                {
                    case 1:
                        enemyScript.SkillOneDamage();
                        break;
                    case 2:
                        enemyScript.SkillTwoDamage();
                        break;
                    case 3:
                        enemyScript.SkillThreeDamage();
                        break;
                }
            }
        }
        else
        {
            switch(playerScript.selectedSkill)
            {
                case 1:
                    playerScript.SkillOne();
                    break;
                case 2:
                    playerScript.SkillTwo();
                    break;
                case 3:
                    playerScript.SkillThree();
                    break;
            }

            switch (enemyScript.selectedSkill)
            {
                case 1:
                    enemyScript.SkillOne();
                    break;
                case 2:
                    enemyScript.SkillTwo();
                    break;
                case 3:
                    enemyScript.SkillThree();
                    break;
            }
        }
    }
}
