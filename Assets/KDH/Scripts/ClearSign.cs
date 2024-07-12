using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ClearSign : MonoBehaviour
{
    public Image image;
    public float fadeInDuration = 1f;
    public float displayDuration = 2f;
    public float fadeOutDuration = 1f;

    public void Start()
    {
        Color color = image.color;
        color.a = 0;
        image.color = color;
    }
    private void OnTriggerEnter(Collider other)
    {
        // DOTween�� ����Ͽ� ���� ���� 1�� �����ϸ� ���̵��� ȿ���� �ݴϴ�.
        Sequence sequence = DOTween.Sequence();
        sequence.Append(image.DOFade(1, fadeInDuration)) // ���̵���
                .AppendInterval(displayDuration) // ���� �ð� ���� ����
                .Append(image.DOFade(0, fadeOutDuration)); // ���̵�ƿ�
    }
}
