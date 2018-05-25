using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrum : MonoBehaviour {

	private void Update()
    {
        AudioListener.GetSpectrumData(m_audioSpectrum, 0, fftWindow);

        if (m_audioSpectrum != null && m_audioSpectrum.Length > 0)
            spectrumValue = m_audioSpectrum[0] * 100;
    }

    private void Start()
    {
    	m_audioSpectrum = new float[64];
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public float spectrumValue { get; private set; }

	public FFTWindow fftWindow;

	private float[] m_audioSpectrum;

    public static AudioSpectrum instance;
    
}
