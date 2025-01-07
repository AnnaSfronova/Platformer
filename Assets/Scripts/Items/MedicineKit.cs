using UnityEngine;

public class MedicineKit : MonoBehaviour, ICollectable
{
    private int _heal = 20;

    public int Heal => _heal;

    public void Collect()
    {
        gameObject.SetActive(false);
    }
}
