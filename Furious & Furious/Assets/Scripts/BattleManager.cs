using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState {START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleManager : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyLvl1Prefab;
    public GameObject explosion;
    public GameObject littleExplosion;
    public GameObject bigExplosion;

    public Transform playerInitialPosition;
    public Transform enemyInitialPosition;

    public Button attackButton;
    public Button attackTotalHP;
    public Button attackFrontWheelHP;
    public Button attackBackWheelHP;

    public Button repairButton;
    public Button repairTotalHPButton;
    public Button repairFrontWheelHPButton;
    public Button repairBackWheelHPButton;

    public GameObject restartScreen;
    public GameObject winScreen;

    CarUnit playerCarUnit;
    CarUnit enemyCarUnit;

    public BattleUIManager playerHUD;
    public BattleUIManager enemyHUD;

    public BattleState state;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        restartScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerInitialPosition);
        playerCarUnit = playerGO.GetComponent<CarUnit>();

        GameObject enemyGO = Instantiate(enemyLvl1Prefab, enemyInitialPosition);
        enemyCarUnit = enemyGO.GetComponent<CarUnit>();

        playerHUD.SetTotalHP(playerCarUnit);

        DisablePlayerAttackActions();
        DisablePlayerRepairActions();

        yield return new WaitForSeconds(1f);

        state = BattleState.PLAYERTURN;
        
    }

    IEnumerator PlayerAttackTotalHP()
    {
        bool isTotalDead = enemyCarUnit.TakeDamageTotalHP(playerCarUnit.mainWeaponDamage);

        enemyHUD.SetTotalHP(enemyCarUnit);

        Instantiate(explosion, enemyInitialPosition);

        DisablePlayerActions();
        DisablePlayerAttackActions();

        yield return new WaitForSeconds(1f);

        if (isTotalDead)
        {
            state = BattleState.WON;
            winScreen.SetActive(true);
            //EndBattle();
        } else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

    }

    IEnumerator WheelDestroyed()
    {
        bool isTotalDead = enemyCarUnit.TakeDamageTotalHP(playerCarUnit.mainWeaponDamage * 3);

        enemyHUD.SetTotalHP(enemyCarUnit);

        Instantiate(bigExplosion, enemyInitialPosition);

        yield return new WaitForSeconds(1f);

        DisablePlayerActions();
        DisablePlayerAttackActions();
    }

    IEnumerator PlayerWheelDestroyed()
    {
        playerCarUnit.TakeDamageTotalHP(enemyCarUnit.mainWeaponDamage * 3);

        playerHUD.SetTotalHP(playerCarUnit);

        Instantiate(bigExplosion, playerInitialPosition);

        yield return new WaitForSeconds(1f);

        EnablePlayerActions();
    }

    IEnumerator PlayerAttackFrontWheelHP()
    {
        bool isFrontWheelDead = enemyCarUnit.TakeDamageFrontWheelHP(playerCarUnit.mainWeaponDamage);

        enemyHUD.SetFrontWheelHP(enemyCarUnit);

        Instantiate(littleExplosion, enemyInitialPosition);

        DisablePlayerActions();
        DisablePlayerAttackActions();

        yield return new WaitForSeconds(1f);

        if (isFrontWheelDead)
        {
            StartCoroutine(WheelDestroyed());
            attackFrontWheelHP.gameObject.SetActive(false);

            if (enemyCarUnit.ReturnCarCurrentHP(enemyCarUnit.carCurrentHP))
            {
                state = BattleState.WON;
                winScreen.SetActive(true);
            } else
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            } 
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

    }

    IEnumerator PlayerAttackBackWheelHP()
    {
        bool isBackWheelDead = enemyCarUnit.TakeDamageBackWheelHP(playerCarUnit.mainWeaponDamage);

        enemyHUD.SetBackWheelHP(enemyCarUnit);

        Instantiate(littleExplosion, enemyInitialPosition);

        DisablePlayerActions();
        DisablePlayerAttackActions();

        yield return new WaitForSeconds(1f);

        if (isBackWheelDead)
        {
            StartCoroutine(WheelDestroyed());
            attackBackWheelHP.gameObject.SetActive(false);

            if (enemyCarUnit.ReturnCarCurrentHP(enemyCarUnit.carCurrentHP))
            {
                state = BattleState.WON;
                winScreen.SetActive(true);

            } else
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            }
   
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

    }

    IEnumerator PlayerRepairTotalHP()
    {
        playerCarUnit.RepairTotalHP(2);

        playerHUD.SetTotalHP(playerCarUnit);

        DisablePlayerActions();
        DisablePlayerRepairActions();

        yield return new WaitForSeconds(1f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerRepairFrontWheelHP()
    {
        playerCarUnit.RepairFrontWheelHP(2);

        playerHUD.SetFrontWheelHP(playerCarUnit);

        DisablePlayerActions();
        DisablePlayerRepairActions();

        yield return new WaitForSeconds(1f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerRepairBackWheelHP()
    {
        playerCarUnit.RepairBackWheelHP(2);

        playerHUD.SetBackWheelHP(playerCarUnit);

        DisablePlayerActions();
        DisablePlayerRepairActions();

        yield return new WaitForSeconds(1f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f);

        float randomNumber = Random.value; // pega numero aleatorio pra definir a acao do inimigo

        // A seguir a inteligencia artificial do inimigo
        if (randomNumber <= 0.5 || playerCarUnit.backWheelCurrentHP == 0 || playerCarUnit.frontWheelCurrentHP == 0) // aqui ele ataca o dano total do jogador
        {
            bool isTotalDead = playerCarUnit.TakeDamageTotalHP(enemyCarUnit.mainWeaponDamage);

            playerHUD.SetTotalHP(playerCarUnit);

            Instantiate(explosion, playerInitialPosition);

            if (isTotalDead)
            {
                state = BattleState.LOST;
                restartScreen.SetActive(true);
            } else {
                EnablePlayerActions();
                state = BattleState.PLAYERTURN;
            }

        } else if (randomNumber > 0.5 && randomNumber <= 0.75) // aqui ele ataca as rodas da frente
        {
            bool isFrontWheelDead = playerCarUnit.TakeDamageFrontWheelHP(enemyCarUnit.mainWeaponDamage);

            playerHUD.SetFrontWheelHP(playerCarUnit);

            Instantiate(littleExplosion, playerInitialPosition);

            if (isFrontWheelDead)
            {
                StartCoroutine(PlayerWheelDestroyed());
                repairFrontWheelHPButton.gameObject.SetActive(false);

                if (playerCarUnit.ReturnCarCurrentHP(playerCarUnit.carCurrentHP))
                {
                    state = BattleState.LOST;
                    restartScreen.SetActive(true);
                } else
                {
                    EnablePlayerActions();
                    state = BattleState.PLAYERTURN;
                }
            } else
            {
                EnablePlayerActions();
                state = BattleState.PLAYERTURN;
            } 

        } else // aqui ele ataca as rodas de trás
        {
            bool isBackWheelDead = playerCarUnit.TakeDamageBackWheelHP(enemyCarUnit.mainWeaponDamage);

            playerHUD.SetBackWheelHP(playerCarUnit);

            Instantiate(littleExplosion, playerInitialPosition);

            if (isBackWheelDead)
            {
                StartCoroutine(PlayerWheelDestroyed());
                repairBackWheelHPButton.gameObject.SetActive(false);

                if (playerCarUnit.ReturnCarCurrentHP(playerCarUnit.carCurrentHP))
                {
                    state = BattleState.LOST;
                    restartScreen.SetActive(true);
                } else
                {
                    EnablePlayerActions();
                    state = BattleState.PLAYERTURN;
                }
            } else
            {
                EnablePlayerActions();
                state = BattleState.PLAYERTURN;
            }

        }
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        EnablePlayerAttackActions();
        DisablePlayerRepairActions();

        //StartCoroutine(PlayerAttack());
    }

    public void OnRepairButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        EnablePlayerRepairActions();
        DisablePlayerAttackActions();
    }

    public void OnAttackTotalHPButton()
    {
        StartCoroutine(PlayerAttackTotalHP());
    }

    public void OnAttackFrontWheelHPButton()
    {
        StartCoroutine(PlayerAttackFrontWheelHP());
    }

    public void OnAttackBackWheelHPButton()
    {
        StartCoroutine(PlayerAttackBackWheelHP());
    }

    public void OnRepairTotalHPButton()
    {
        StartCoroutine(PlayerRepairTotalHP());
    }

    public void OnRepairFrontWheelHPButton()
    {
        StartCoroutine(PlayerRepairFrontWheelHP());
    }

    public void OnRepairBackWheelHPButton()
    {
        StartCoroutine(PlayerRepairBackWheelHP());
    }

    public void EnablePlayerAttackActions()
    {
        attackTotalHP.interactable = true;
        attackFrontWheelHP.interactable = true;
        attackBackWheelHP.interactable = true;
    }

    public void EnablePlayerActions()
    {
        attackButton.interactable = true;
        repairButton.interactable = true;
    }

    public void DisablePlayerAttackActions()
    {
        attackTotalHP.interactable = false;
        attackFrontWheelHP.interactable = false;
        attackBackWheelHP.interactable = false;
    }

    public void DisablePlayerActions()
    {
        attackButton.interactable = false;
        repairButton.interactable = false;
    }

    public void DisablePlayerRepairActions()
    {
        repairTotalHPButton.interactable = false;
        repairFrontWheelHPButton.interactable = false;
        repairBackWheelHPButton.interactable = false;
    }

    public void EnablePlayerRepairActions()
    {
        repairTotalHPButton.interactable = true;
        repairFrontWheelHPButton.interactable = true;
        repairBackWheelHPButton.interactable = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("BattleScene");
    }

}
