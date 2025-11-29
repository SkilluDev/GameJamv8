using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
  public Image bar;

  public void SetHealth(float hpPercent)
  {
    bar.fillAmount = hpPercent;
  }
}