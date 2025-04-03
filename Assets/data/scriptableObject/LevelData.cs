using UnityEngine;

[CreateAssetMenu(fileName = "New Level data", menuName = "Levels data")]
public class LevelData : ScriptableObject
{
    public string RussianText;
    public string EnglishText;
    [Tooltip("����� �� ����������")]
    public AudioClip AudioTranslate;
    public Variable[] Variables;
}
