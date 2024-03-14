using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class GameManager : MonoBehaviour
{
    public Button Spin;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Move()
    {
        transform.DOMove(new Vector3(0, 1, 0), 1f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
