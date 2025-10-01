using UnityEngine;

public class CurveDistributionVisualizer : MonoBehaviour
{
    [Header("Settings")]
    public AnimationCurve remapCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public int sampleCount = 100000;
    public int binCount = 50;

    private int[] bins;

    private void Start()
    {
        bins = new int[binCount];
        GenerateDistribution();
    }

    private void GenerateDistribution()
    {
        for (int i = 0; i < sampleCount; i++)
        {
            float randomValue = Random.value;
            float remappedValue = remapCurve.Evaluate(randomValue);

            int binIndex = Mathf.Clamp(Mathf.FloorToInt(remappedValue * binCount), 0, binCount - 1);
            bins[binIndex]++;
        }
    }

    private void OnDrawGizmos()
    {
        if (bins == null || bins.Length == 0) return;

        Gizmos.color = Color.green;

        float width = 10f;
        float height = 5f;
        Vector3 origin = transform.position;

        int maxBin = 0;
        foreach (var count in bins)
            if (count > maxBin)
                maxBin = count;

        for (int i = 0; i < bins.Length; i++)
        {
            float normalizedHeight = (float)bins[i] / maxBin;
            Vector3 binPos = origin + new Vector3((i / (float)binCount) * width, 0, 0);
            Vector3 binSize = new Vector3(width / binCount * 0.9f, normalizedHeight * height, 0.1f);

            Gizmos.DrawCube(binPos + new Vector3(0, binSize.y / 2f, 0), binSize);
        }
    }
}