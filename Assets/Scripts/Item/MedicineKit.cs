using UnityEngine;

public class MedicineKit : MonoBehaviour
{
    private int _heal = 20;

    public int Heal => _heal;

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
