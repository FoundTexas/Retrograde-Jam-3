using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamaged
{
    void Heal(int hp);
    void TakeDamage(int dmg);
    void dead();
}
