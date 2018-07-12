using UnityEngine;
using System.Collections;
using System.IO;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CreateFiles();
	}


    private void CreateFiles()
    {
        byte[] ted = new byte[500];
        for (int i = 0; i < ted.Length; i++)
        {
            ted[i] =(byte)Random.Range(0,255);
        }

        File.WriteAllBytes(Application.dataPath+"/dfasd.bin",ted);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
