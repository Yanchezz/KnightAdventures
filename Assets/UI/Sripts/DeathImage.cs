using UnityEngine;
using UnityEngine.UI;
public class DeathImage : MonoBehaviour
{
    private Image image;
    private Text text;
    private float a=0;
    void Awake()
    {
        image = GetComponent<Image>();
        text = GetComponentInChildren<Text>();
    }
    void Update()
    {
        ColorChange();
    }
    private void ColorChange()
    {
        image.color = new Color(255, 255, 255, a);
        text.color = new Color(text.color.r, text.color.g, text.color.b, a) ;
        a += Time.deltaTime;
    }
}