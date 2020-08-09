﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forrest : MonoBehaviour
{
  public int forestSize = 25;
  public int elementSpacing = 3;

  public Element[] elements;

  private void Start(){
      for(int x = 0; x < forestSize; x += elementSpacing){
          for(int z = 0; z < forestSize; z += elementSpacing){
              for(int i = 0; i < elements.Length; i++){


              Element element = elements[i];

              if(element.CanPlace()){
              Vector3 position = new Vector3(x, 0f, z);
              Vector3 offset = new Vector3(Random.Range(-0.75f, 0.75f),0f, Random.Range(-0.75f, 0.75f));
              Vector3 rotation = new Vector3(Random.Range(0, 5f), Random.Range(0, 360f), Random.Range(0, 5f));
              Vector3 scale = Vector3.one * Random.Range(0.75f, 1.25f);

              GameObject newElement = Instantiate(element.GetRandom());
              newElement.transform.SetParent(transform);
              newElement.transform.position = position + offset;
              newElement.transform.eulerAngles = rotation;
              newElement.transform.localScale = scale;
              break;
              }
            }
          }
      }
  }
}

[System.Serializable]
public class Element{
    public string name;
    [Range(1,10)]
    public int density;

    public GameObject[] prefabs;

    public bool CanPlace(){
        if (Random.Range(0, 10) < density)
        return true;
        else 
        return false;
    }

    public GameObject GetRandom(){
        return prefabs[Random.Range(0, prefabs.Length)];
    }
}