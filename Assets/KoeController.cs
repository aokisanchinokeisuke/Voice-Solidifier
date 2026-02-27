using UnityEngine;
using Whisper;
using Whisper.Utils;
using TMPro;

public class KoeController : MonoBehaviour
{
    public WhisperManager whisper;
    public MicrophoneRecord microphoneRecord;
    public GameObject wordPrefab;
    public Transform shootPoint;

    private float _maxVolume;

    void Start()
    {
        if (microphoneRecord != null)
        {
            microphoneRecord.OnRecordStop += async (chunk) => 
            {
                if (whisper == null || !whisper.IsLoaded) return;
                var result = await whisper.GetTextAsync(chunk.Data, chunk.Frequency, chunk.Channels);
                if (result != null && !string.IsNullOrEmpty(result.Result))
                {
                    SpawnWord(result.Result);
                }
            };
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _maxVolume = 0;
            if (microphoneRecord != null) microphoneRecord.StartRecord();
            Debug.Log("録音中...");
        }

        if (Input.GetKey(KeyCode.Space)) UpdateVolume();

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (microphoneRecord != null) microphoneRecord.StopRecord();
            Debug.Log("解析中...");
        }
    }

    void UpdateVolume()
    {
        float[] data = new float[128];
        if (Microphone.IsRecording(null))
        {
            AudioSource source = GetComponent<AudioSource>();
            if (source != null)
            {
                source.GetOutputData(data, 0);
                float currentSum = 0;
                foreach (var s in data) currentSum += Mathf.Abs(s);
                float avg = currentSum / 128;
                if (avg > _maxVolume) _maxVolume = avg;
            }
        }
    }

void SpawnWord(string text)
{
    Vector3 spawnPos = shootPoint.position + (shootPoint.forward * 2.0f);
    GameObject go = Instantiate(wordPrefab, spawnPos, shootPoint.rotation);
    
    var tmp = go.GetComponentInChildren<TextMeshPro>();
    if (tmp != null) 
    {
        // ここを書き換えます。text（認識した言葉）をそのまま表示します。
        tmp.text = text; 
        tmp.fontSize = 10;
        
        // 暴言なら赤、それ以外は白にする演出は残しておくとスペキュラティブです
        if (text.Contains("しね") || text.Contains("バカ")) {
            tmp.color = Color.red;
        } else {
            tmp.color = Color.white;
        }
    }

    var rb = go.GetComponent<Rigidbody>();
    if (rb != null)
    {
        // 呪いの力（飛ばす力）をここでお好みの強さに調整してください
        rb.AddForce(shootPoint.forward * 25f, ForceMode.Impulse);
    }
}
}