using System;
using System.Collections;
using UnityEngine;

public class KnowledgeTesting : MonoBehaviour
{
    public static Action<bool> OnClickChecking;
    public static KnowledgeTesting Instance;
    [SerializeField] private VariableButton[] variableButtons;
    public GameObject VariantPanel;
    [Header("Звуки")]
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip callback;
    [SerializeField] private AudioClip fallback;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        OnClickChecking += ButtonCheckResult;
    }

    private void OnDisable()
    {
        OnClickChecking -= ButtonCheckResult;
    }

    public void Checking(Variable[] variables)
    {
        Debug.Log("Обращение через синглтон");

        for (int i = 0; i < variables.Length; i++)
        {
            variableButtons[i].Construct(variables[i]);
        }
        VariantPanel.SetActive(true);
    }

    public void ButtonCheckResult(bool value)
    {
        source.clip = value ? callback : fallback;
        source.Play();

        if(value)
            StartCoroutine(DelayAudioClipToButton(source.clip.length));
    }
    private IEnumerator DelayAudioClipToButton(float time)
    {
        yield return new WaitForSeconds(time);

        VariantPanel.SetActive(false);
    }
}
