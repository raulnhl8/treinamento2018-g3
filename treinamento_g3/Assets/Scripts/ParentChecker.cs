﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentChecker : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		if (this.transform.parent == null)
        {
            GetComponent<WeaponMovement>().enabled = false;
            GetComponent<WeaponProperties>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            GetComponent<Animator>().enabled = false;
        }
        else
            GetComponent<ItemPickUp>().enabled = false;
	}

    private void Update()
    {
        
        if (this.transform.parent != null)
        {
            if (GetComponent<SelectNPC>() != null)
            {
                GetComponent<SelectNPC>().enabled = false;
            }       
        }
        else
        {
            if (GetComponent<SelectNPC>() != null)
                GetComponent<SelectNPC>().enabled = true;
        }
            
    }
}
