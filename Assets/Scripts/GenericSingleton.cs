using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T : MonoBehaviour {

	 static GenericSingleton<T> instance;
    public static GenericSingleton<T> Instance { get { return instance; } }

	void Awake () {
		if (instance && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
	}

}
