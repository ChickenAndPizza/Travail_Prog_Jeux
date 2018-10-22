using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interaction : MonoBehaviour {

    public abstract void Interact();

    public abstract bool IsChangingSceneDialog { get; set; }

}
