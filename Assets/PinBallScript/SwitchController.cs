using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public ScoreManager scoreManager;
    public float score;
    enum SwitchState
    {
        on, off, blink
    }

    public Collider bola;
    public Material offMaterial;
    public Material onMaterial;


    private Renderer rend;
    private SwitchState state;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        Set(false);

        StartCoroutine(BlinkStartTime(5)); //tunggu 5 detik dulu baru blinking 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            Toggle(); //saat state dalam kondisi apapun (kita ga bisa prediksi) maka jalankan kondisi yang ada pada fungsi toggle()
        }
    }
    public void Set(bool active)
    {
        /*isOn = active;*/
        // rend.material = isOn ? onMaterial : offMaterial;
        if (active == true)
        {
            state = SwitchState.on;
            rend.material = onMaterial;
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.off;
            rend.material = offMaterial;
            StartCoroutine(BlinkStartTime(5));
        }
    }
    public void Toggle()
    {
        scoreManager.AddScore(score);
        if (state == SwitchState.on)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }
    }
    public IEnumerator Blink(int times)
    {
        state = SwitchState.blink;
        for (int i = 0; i < times; i++)
        {
            rend.material = onMaterial;
            yield return new WaitForSeconds(0.5f);

            rend.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }
        state = SwitchState.off;
        StartCoroutine(BlinkStartTime(5));
    }

    public IEnumerator BlinkStartTime(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }

}
