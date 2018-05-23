using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncer : MonoBehaviour {

	private void Update()
    {
        audio.GetSpectrumData(m_audioSpectrum, 0, fftWindow);

        m_audioValue = 0;

        for (int i = 1; i < m_audioSpectrum.Length - 1; i++)
        {
            /*Debug.DrawLine(new Vector3(i - 1, m_audioSpectrum[i] + 10, 0), new Vector3(i, m_audioSpectrum[i + 1] + 10, 0), Color.red);
            Debug.DrawLine(new Vector3(i - 1, Mathf.Log(m_audioSpectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(m_audioSpectrum[i]) + 10, 2), Color.cyan);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), m_audioSpectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), m_audioSpectrum[i] - 10, 1), Color.green);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(m_audioSpectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(m_audioSpectrum[i]), 3), Color.blue);*/

            m_audioValue -= Mathf.Log(m_audioSpectrum[i - 1]) / 50;
        }

        Debug.DrawLine(Vector3.zero, new Vector3(0, 15 - m_audioValue, 0), Color.white);
        Debug.DrawLine(Vector3.zero, new Vector3(0, minimumThreshold, 0), Color.green);
        Debug.DrawLine(new Vector3(0, maxThreshold, 0), new Vector3 (0, 15 - m_audioValue, 0), Color.red);
        Debug.Log(m_audioValue);
    }

    private void Start()
    {
    	m_audioSpectrum = new float[64];
    }

	public AudioSource audio;
	public FFTWindow fftWindow;
	public float minimumThreshold;
	public float maxThreshold;

	private float[] m_audioSpectrum;
	private float m_audioValue;
}
