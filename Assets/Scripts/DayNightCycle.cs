using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Header("Configuración del Ciclo")]
    public float dayDurationInMinutes = 60f; // Duración de un día en minutos
    public float startHour = 17f; // Hora inicial del ciclo (17:00)
    public Light directionalLight; // Luz direccional que simula el sol
    public float minSunIntensity = 0.01f; // Intensidad mínima del sol para que sea visible
    public float maxSunIntensity = 1f; // Intensidad máxima del sol durante el día

    [Header("Configuración del Fog")]
    public float fogStartDistance = 10f; // Distancia de inicio del Fog
    public float fogEndDistance = 50f; // Distancia final del Fog
    public Color nightFogColor = Color.black; // Color del Fog durante la noche
    public Color dayFogColor = new Color(0.6f, 0.8f, 1f); // Color del Fog durante el día
    public float transitionDuration = 2f; // Duración de la transición entre el día y la noche en horas

    private float secondsPerDay;
    private float currentTimeOfDay; // Tiempo actual del día (en horas)

    void Start()
    {
        secondsPerDay = dayDurationInMinutes * 60f;
        currentTimeOfDay = startHour;

        RenderSettings.fog = true;
        RenderSettings.fogMode = FogMode.Linear;
        RenderSettings.fogStartDistance = fogStartDistance;
        RenderSettings.fogEndDistance = fogEndDistance;
        RenderSettings.fogColor = GetFogColor(currentTimeOfDay); // Inicializar el color del Fog
    }

    void Update()
    {
        float deltaTime = Time.deltaTime;
        float timeIncrement = (deltaTime / secondsPerDay) * 24f;
        currentTimeOfDay += timeIncrement;

        if (currentTimeOfDay >= 24f)
        {
            currentTimeOfDay -= 24f;
        }

        UpdateSunPosition();
        RenderSettings.fogColor = GetFogColor(currentTimeOfDay);
    }

    void UpdateSunPosition()
    {
        // Calcular el ángulo del sol basado en el tiempo actual del día
        float sunAngle = (currentTimeOfDay / 24f) * 360f - 90f;
        directionalLight.transform.rotation = Quaternion.Euler(new Vector3(sunAngle, -30f, 0f));

        // Ajustar la intensidad del sol para que nunca sea completamente nula
        float intensity = Mathf.Clamp01(Mathf.Cos((currentTimeOfDay - 6f) / 12f * Mathf.PI));
        directionalLight.intensity = Mathf.Lerp(minSunIntensity, maxSunIntensity, intensity);

        // Cambiar el color de la luz según el día o la noche
        directionalLight.color = Color.Lerp(Color.black, Color.white, intensity);
    }

    Color GetFogColor(float timeOfDay)
    {
        float transitionStartMorning = 6f; // Hora de inicio de la transición al día
        float transitionEndMorning = transitionStartMorning + transitionDuration;
        float transitionStartEvening = 18f; // Hora de inicio de la transición a la noche
        float transitionEndEvening = transitionStartEvening + transitionDuration;

        if (timeOfDay >= transitionStartMorning && timeOfDay <= transitionEndMorning)
        {
            float t = Mathf.InverseLerp(transitionStartMorning, transitionEndMorning, timeOfDay);
            return Color.Lerp(nightFogColor, dayFogColor, t);
        }
        else if (timeOfDay >= transitionStartEvening && timeOfDay <= transitionEndEvening)
        {
            float t = Mathf.InverseLerp(transitionStartEvening, transitionEndEvening, timeOfDay);
            return Color.Lerp(dayFogColor, nightFogColor, t);
        }
        else if (timeOfDay > transitionEndMorning && timeOfDay < transitionStartEvening)
        {
            return dayFogColor;
        }
        else
        {
            return nightFogColor;
        }
    }

    public string GetFormattedTime()
    {
        int hours = Mathf.FloorToInt(currentTimeOfDay);
        int minutes = Mathf.FloorToInt((currentTimeOfDay - hours) * 60f);
        return $"{hours:D2}:{minutes:D2}";
    }
}




