using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LevelItem : MonoBehaviour, IInteract
{
    [SerializeField] private LevelData LevelData;
    [SerializeField] private GameObject itemPanel;
    [SerializeField] private DataViewItem dataViewItem;
    public void Interact()
    {
        dataViewItem.Contruct(LevelData);
        itemPanel.SetActive(true);
    }
}
