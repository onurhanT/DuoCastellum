using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController
{
    int GetHealth();
    void TakeDamage(int damage);
}
