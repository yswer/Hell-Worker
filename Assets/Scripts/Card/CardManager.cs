using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject card1Prefab;
    public GameObject card2Prefab;
    public GameObject card3Prefab;
    public GameObject card4Prefab;
    public Transform playerTransform;
    public float spawnRadius = 5.0f;
    public float spawnInterval = 5.0f;
    public float skill1Duration = 10.0f;
    public float skill2Duration = 10.0f;
    public float skill4Duration = 10.0f;

    private PlayerController Player;
    public int[] cardCounters = new int[4];
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
        playerTransform = Player.transform;
        InvokeRepeating("SpawnRandomCard", 0.0f, spawnInterval);
    }

    void SpawnRandomCard()
    {
        Debug.Log("SpawnRandomCard");
        Vector3 randomPosition = GetRandomSpawnPosition();
        randomPosition.z = 0.0f; // 将 Z 值设置为 0
        GameObject randomCardPrefab = GetRandomCardPrefab();

        if (randomCardPrefab != null)
        {
            Instantiate(randomCardPrefab, randomPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector2 randomCircle = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 randomPosition;
        if(playerTransform != null)  randomPosition = playerTransform.position + new Vector3(randomCircle.x, 0.0f, randomCircle.y);
        else randomPosition = new Vector3(randomCircle.x, 0.0f, randomCircle.y);
        return randomPosition;
    }

    GameObject GetRandomCardPrefab()
    {
        GameObject[] cardPrefabs = { card1Prefab, card2Prefab, card3Prefab, card4Prefab };
        int randomIndex = Random.Range(0, cardPrefabs.Length);
        return cardPrefabs[randomIndex];
    }

    public void UseSkill(string buttonName)
    {
        // int index;
        switch (buttonName)
        {
            case "PatButton":
                Skill1();
                cardCounters[0] = 0;
                break;
            case "AttackButton":
                Skill2();
                cardCounters[1] = 0;
                break;
            case "FoodButton":
                Skill3();
                cardCounters[2] = 0;
                break;
            case "CakeButton":
                Skill4();
                cardCounters[3] = 0;
                break;
        }
    }

    IEnumerator ChangePlayerSpeed(float delay)
    {
        var beginSpeed = Player.moveSpeed;
        for (int i = 0; i < cardCounters[0]; ++i)
        {
            Player.moveSpeed *= 1.5f;
        }
        Player.GetComponent<Animator>().SetBool("is speed" , true);

        yield return new WaitForSeconds(delay);
        Player.GetComponent<Animator>().SetBool("is speed" , false);
        
        // StartCoroutine(ChangeAnimator("is speed"));

        Player.moveSpeed = beginSpeed;  
    }
    
    IEnumerator ChangeShootInterval(float delay)
    {
        var beginInterval = Player.shootInterval;
        for (int i = 0; i < cardCounters[1]; ++i)
        {
            Player.shootInterval /= 2;
        }
        
        // StartCoroutine(ChangeAnimator("attack speed"));
        Player.GetComponent<Animator>().SetBool("attack speed" , true);
        yield return new WaitForSeconds(delay);
        Player.GetComponent<Animator>().SetBool("attack speed" , false);
        Player.shootInterval = beginInterval;  
    }
    
    IEnumerator StunEffect(float delay, GameObject enemy)
    {
        delay *= cardCounters[3];
        Transform originalTransform = enemy.transform;
        EnemyController enemyController = enemy.GetComponent<EnemyController>(); // 假设有 EnemyController 脚本
        var originalMoveSpeed = enemyController.moveSpeed;
        var originalDamage = enemyController.damagePerAttack;
        enemyController.moveSpeed = 0.0f; // 冻结移动
        enemyController.damagePerAttack = 0; // 伤害降为 0

        yield return new WaitForSeconds(delay);

        enemyController.moveSpeed = originalMoveSpeed; // 恢复移动速度
        enemyController.damagePerAttack = originalDamage; // 恢复伤害
        if(enemy!=null) enemy.transform.position = originalTransform.position; // 恢复位置
        
    }
    
    // 拍马屁：提高移速
    void Skill1()
    {
        if (cardCounters[0] > 0)
        {

            StartCoroutine(ChangePlayerSpeed(skill1Duration));

        }
        
    }
    // 开攻：增加攻速
    void Skill2()
    {
        if (cardCounters[1] > 0)
        {
            Debug.Log("Skill2");
            StartCoroutine(ChangeShootInterval(skill2Duration));
        }
    }
    IEnumerator ChangeAnimator(string name)
    {
        Player.GetComponent<Animator>().SetBool(name, true);
        yield return new WaitForSeconds(3.0f);
        Player.GetComponent<Animator>().SetBool(name, false);


    }
    // 回血
    void Skill3()
    {
        if (cardCounters[2] > 0)
        {
            Debug.Log("Skill3");
            StartCoroutine(ChangeAnimator("is recover"));
            Player.health += 10.0f * cardCounters[2];
            if(Player.health > 100.0f) Player.health = 100.0f;

        }
    }
    // 眩晕
    void Skill4()
    {
        if (cardCounters[3] > 0)
        {
            Debug.Log("Skill4");
            StartCoroutine(ChangeAnimator("control boss"));
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Character");
            foreach (GameObject enemy in enemies)
            {
                if (enemy.name == "Player")
                {
                    continue;
                }
                StartCoroutine(StunEffect(skill4Duration, enemy));
            }
        }
    }
    
}