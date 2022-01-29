using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawPlayerInput;
    Vector2 minimumBoundry;
    Vector2 maximumBoundry;

    [Header("Movement")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingBottom;
    [SerializeField] float paddingTop;

    [Header("Upgrades")]
    [SerializeField] int playerDamage;
    [SerializeField] List<GameObject> weaponUpgrades;

    Shooter shooter;

    void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    void Start()
    {
        InitBoundries();
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        Vector2 delta = rawPlayerInput * moveSpeed * Time.deltaTime;
        Vector2 newPosition = new Vector2();
        newPosition.x = Mathf.Clamp(transform.position.x + delta.x, minimumBoundry.x + paddingLeft, maximumBoundry.x - paddingRight);
        newPosition.y = Mathf.Clamp(transform.position.y + delta.y, minimumBoundry.y + paddingBottom, maximumBoundry.y - paddingTop);
        transform.position = newPosition;
    }

    void InitBoundries()
    {
        Camera mainCamera = Camera.main;
        minimumBoundry = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maximumBoundry = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void OnMove(InputValue value)
    {
        rawPlayerInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }

    public int GetPlayerDamage()
    {
        return playerDamage;
    }

    public void SetPlayerDamage(int value)
    {
        playerDamage += value;
    }

    public GameObject GetWeaponFromPlayerList(int index)
    {
        return weaponUpgrades[index];
    }

    public void AdjustMoveSpeed(float value)
    {
        moveSpeed += value;
        if (moveSpeed > 10f)
        {
            moveSpeed = 10f;
        }
    }
}
