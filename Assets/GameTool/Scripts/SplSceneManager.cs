using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

// ReSharper disable once CheckNamespace
namespace GameTool
{
    public class SplSceneManager : MonoBehaviour
    {
        private void Start()
        {
            //AudioManager.Instance.PlayMusic(eMusicName.Loading);
            StartCoroutine(nameof(LoadSceneHome));
        }

        IEnumerator LoadSceneHome()
        {
            yield return new WaitForSeconds(5);
            LoadSceneManager.Instance.LoadSceneHome();
        }
    }
}