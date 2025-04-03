using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataViewItem : MonoBehaviour
{
    [SerializeField] private TMP_Text rusText;
    [SerializeField] private TMP_Text engText;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Image imageSound;
    private LevelData levelData;
    private AudioClip audioClip;
    public void Contruct(LevelData levelData)
    {
        this.levelData = levelData;
        audioClip = levelData.AudioTranslate;
        rusText.text = levelData.RussianText;
        engText.text = levelData.EnglishText;
    }

    public void PlaySoundTranslate()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        StartCoroutine(PlaceFilled());
    }

    private IEnumerator PlaceFilled()
    {
        imageSound.fillAmount = 0;
        float lenght = audioClip.length;
        float filled = 0;
        float time = 0;
        while (time / lenght <= 1)
        {
            time += Time.deltaTime;
            filled = time / lenght;
            imageSound.fillAmount = filled;
            yield return null;
        }
        KnowledgeTesting.Instance.Checking(levelData.Variables);
        gameObject.SetActive(false);
    }
}
