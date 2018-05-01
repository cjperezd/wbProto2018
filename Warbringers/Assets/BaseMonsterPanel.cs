using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMonsterPanel : MonoBehaviour {

    // TODO: se podria refactorizar para que quede mejor: esto recibiria un T de un tipo de interfaz particular, 
    // y entonces la logica de los start y del setAllMonsters... que es igual para todos los hijos se mueve aca, siento T el tipo del script que muestra la data de los monstruos.

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public abstract void SetAllMonstersLabels();
}
