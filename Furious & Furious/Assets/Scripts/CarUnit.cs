using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarUnit : MonoBehaviour
{

    public string carName;

    public int speed;

    public int carHP;
    public int carCurrentHP;
    public int frontWheelHP;
    public int frontWheelCurrentHP;
    public int backWheelHP;
    public int backWheelCurrentHP;

    public int mainWeaponDamage;

    public bool TakeDamageTotalHP(int dmg)
    {
        carCurrentHP -= dmg;

        if (carCurrentHP <= 0)
        {
            carCurrentHP = 0;
            return true;
        } else
            return false;
    }

    public bool TakeDamageFrontWheelHP(int dmg)
    {
        frontWheelCurrentHP -= dmg;

        if (frontWheelCurrentHP <= 0)
        {
            frontWheelCurrentHP = 0;
            return true;
        } else
            return false;
    }

    public bool TakeDamageBackWheelHP(int dmg)
    {
        backWheelCurrentHP -= dmg;

        if (backWheelCurrentHP <= 0)
        {
            backWheelCurrentHP = 0;
            return true;
        } else
            return false;
    }

    public void RepairTotalHP(int amount)
    {
        carCurrentHP += amount;
        if (carCurrentHP > carHP)
            carCurrentHP = carHP;
    }

    public void RepairFrontWheelHP(int amount)
    {
        frontWheelCurrentHP += amount;

        if (frontWheelCurrentHP > frontWheelHP)
            frontWheelCurrentHP = frontWheelHP;
    }

    public void RepairBackWheelHP(int amount)
    {
        backWheelCurrentHP += amount;

        if (backWheelCurrentHP > backWheelHP)
            backWheelCurrentHP = backWheelHP;
    }

    public bool ReturnCarCurrentHP(int hp)
    {
        if (hp <= 0)
            return true;
        else
            return false;
    }



}
