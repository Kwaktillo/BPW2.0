using UnityEngine;

public class WindController : MonoBehaviour
{
    private int windStrengthID;

    void Start()
    {
        windStrengthID = Shader.PropertyToID("_WindStrength");
    }

    public void SetWindStrength(float strength)
    {
        Shader.SetGlobalFloat(windStrengthID, strength);
    }
}
