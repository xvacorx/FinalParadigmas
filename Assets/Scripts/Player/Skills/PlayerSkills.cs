using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{

    [SerializeField] GameObject weapon;
    PlayerMovement player;
    private void Start()
    {
        player = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryAttack(20);
        }
    }

    public void TryAttack(int cost)
    {
        if (HUD.Instance.score >= cost)
        {
            HUD.Instance.score -= cost;
            HUD.Instance.ScoreUpdate(0);
            Attack();
        }
        else
        {
            Debug.Log("Not enough score to attack");
        }
    }

    public void Attack()
    {
        GameObject newWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
        PlayerWeapon weaponScript = newWeapon.GetComponent<PlayerWeapon>();

        Vector2 direction = player.lookingLeft ? Vector2.left : Vector2.right;
        weaponScript.SetDirection(direction);
    }
}
