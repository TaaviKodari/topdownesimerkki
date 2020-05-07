using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool GameOn = true;
    public List<GameObject> collectables = new List<GameObject>();
    public TMP_Text collectablesLeftText;
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        collectablesLeftText.text = "Left: " + GetCollectableAmount().ToString();
    }

    public void AddCollectableOnList(GameObject obj)
    {
        collectables.Add(obj);
    }

    public void RemoveCollatableOnList(GameObject obj)
    {
        collectables.Remove(obj);
    }

    public int GetCollectableAmount()
    {
        return collectables.Count;
    }
}
