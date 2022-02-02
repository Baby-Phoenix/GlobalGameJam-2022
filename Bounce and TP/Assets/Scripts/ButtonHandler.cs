using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public GameObject instructionScene;
    public GameObject loadingScene;
    public Slider loadingBar;
    public Text loadingNumber;

   public void StartButton(int sceneNumber)
    {
        loadingScene.SetActive(true);
        StartCoroutine(Loading(sceneNumber));
    }

    IEnumerator Loading(int sceneNumber)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneNumber);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            loadingBar.value = progress;
            loadingNumber.text = (progress * 100) + "%";

            yield return null;
        }
    }

    public void InstructionsButton()
    {
        instructionScene.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) 
        EscapeInsturction();
    }

    void EscapeInsturction()
    {
        instructionScene.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
