using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (MasterSpawner))]
public class MasterSpawnerEditor : Editor {


    public override void OnInspectorGUI () {
        MasterSpawner spawner = (MasterSpawner) target;
        DrawDefaultInspector ();

        GUILayout.TextArea ("Only press during play mode!!!");

        if (GUILayout.Button ("Spawn Vorpal")) {
            spawner.ManualSpawn (new List<int> () { spawner.testNumberToSpawn });
        }
        if (GUILayout.Button ("Spawn Shell")) {
            spawner.ManualSpawn (new List<int> () { 0, spawner.testNumberToSpawn });
        }
        if (GUILayout.Button ("Spawn Lurker")) {
            spawner.ManualSpawn (new List<int> () { 0, 0, spawner.testNumberToSpawn });
        }
        if (GUILayout.Button ("Spawn Wraith")) {
            spawner.ManualSpawn (new List<int> () { 0, 0, 0, spawner.testNumberToSpawn });
        }
        if (GUILayout.Button ("Spawn Fracture")) {
            spawner.ManualSpawn (new List<int> () { 0, 0, 0, 0, spawner.testNumberToSpawn });
        }
    }
}