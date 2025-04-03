using Assets.scripts.Models;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARTrakedImagePrefabs : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager imageManager;
    [SerializeField] private List<LevelsDTo> LevelsDto;
    private GameObject levelItem;
    private Transform PosePrefab;
    private ARTrackedImage currentImage;
    private void OnEnable()
    {
        imageManager.trackedImagesChanged += TestChangeImages;
    }
    public void TestChangeImages(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var item in eventArgs.added)
        {
            AddImage(item);
        }
        foreach (var item in eventArgs.updated)
        {
            UpdateImage(item);
        }
    }

    private void AddImage(ARTrackedImage aRTrackedImage)
    {
        currentImage = aRTrackedImage;
        Debug.Log("Нашли картинку");
        levelItem = LevelsDto.FirstOrDefault(x => x.Key == aRTrackedImage.referenceImage.name).LevelItem;
        PosePrefab = (aRTrackedImage.gameObject.transform);
        levelItem = Instantiate(levelItem, PosePrefab.position, PosePrefab.rotation);
    }

    private void UpdateImage(ARTrackedImage aRTrackedImage)
    {
        if (aRTrackedImage == null) return;

        PosePrefab = (aRTrackedImage.gameObject.transform);

        levelItem.transform.SetPositionAndRotation(PosePrefab.position, PosePrefab.rotation);
    }
}
