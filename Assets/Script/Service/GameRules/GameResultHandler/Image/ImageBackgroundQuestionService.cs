using UnityEngine.UI;
using UnityEngine;

public class ImageBackgroundQuestionService : MonoBehaviour, IImageBackgroundQuestion
{
    [SerializeField] private Color _enableAlphaColor;
    [SerializeField] private Color _disableAlphaColor;
    [SerializeField] private Image _background;
    public void OnSwitchSprite(Sprite? active)
    {
        if (active != null)
        {
            _background.color = _enableAlphaColor;
            _background.sprite = active;
          
        }
        else
        {
           
            _background.color = _disableAlphaColor;
            _background.sprite = null;
        }
    }
}
