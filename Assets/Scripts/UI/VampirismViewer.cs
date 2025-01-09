using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class VampirismViewer : MonoBehaviour
{
    [SerializeField] private Vampirism _vampirism;

    private Image _image;

    private Color visible = new(1, 0, 0.6f, 0.4f);
    private Color invisible = new(1, 0, 0.6f, 0f);

    private void OnEnable()
    {
        _vampirism.Activated += TurnOn;
        _vampirism.Deactivated += TurnOff;
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.color = invisible;
    }

    private void OnDisable()
    {
        _vampirism.Activated -= TurnOn;
        _vampirism.Deactivated -= TurnOff;
    }

    private void TurnOn()
    {
        _image.color = visible;
    }

    private void TurnOff()
    {
        _image.color = invisible;
    }
}
