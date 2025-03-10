using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
public class coinUpdate : MonoBehaviour
    {
    [SerializeField] private TextMeshProUGUI current;
    [SerializeField] private TextMeshProUGUI toUpdate;
    [SerializeField] private Transform coinTextContainer;
    [SerializeField] private float duration;

    private float containerInitPosition;
    private float moveAmount;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Canvas.ForceUpdateCanvases();
        current.SetText("0");
        toUpdate.SetText("0");
        containerInitPosition = coinTextContainer.localPosition.y;
        moveAmount = current.rectTransform.rect.height;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int score){
        toUpdate.SetText($"{score}");
        coinTextContainer.DOLocalMoveY(containerInitPosition + moveAmount, duration);
    }
}
