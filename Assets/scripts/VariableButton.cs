using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VariableButton : MonoBehaviour
{
    private Variable variable;
    [SerializeField] private TMP_Text title;
    [SerializeField] private Color startColor;
    private Button button;

    public void Construct(Variable variable)
    {
        button = GetComponent<Button>();
        button.image.color = startColor;
        this.variable = variable;
        title.text = this.variable.Description;
    }

    public void ChekingClick()
    {
        //доп логика
        button.image.color = variable.GoodResult ? Color.green : Color.red;
        Debug.Log(variable.GoodResult ? "Правильно": "Не правильно");
        KnowledgeTesting.OnClickChecking?.Invoke(variable.GoodResult);
    }
}
