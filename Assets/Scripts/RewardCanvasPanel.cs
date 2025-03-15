using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardCanvasPanel : MonoBehaviour
{
    [SerializeField] GameObject ForwardCanvas;
    [SerializeField] GameObject BackwardCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressForwardButton()
    {
        Instantiate(ForwardCanvas);
        Destroy(this.gameObject);
    }
    public void PressBackwardButton()
    {
        Instantiate(BackwardCanvas);
        Destroy(this.gameObject);
    }
}
