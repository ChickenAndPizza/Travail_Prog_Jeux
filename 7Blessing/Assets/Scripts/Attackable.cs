using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Attackable  {
    void Attacked(int damage);
    void Heal(int healPower);
}
