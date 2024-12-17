# Research Report: VR and Haptic Feedback Integration in a Networked XR Environment  

---

## Cover Page  
**Title**: VR and Haptic Feedback Integration in a Networked XR Environment  
**Authors**: Chevan Ramcharan, Pirmin Kalbermatter, Derk Ottersberg & Pepijn Brinkman  
**Student Numbers**: 1072166, 1069542, 1076265, 1078024  
**Supervisors**: Mrs. Colleen Chen, Mr. Milan Wijnmalen  
**Submission Date**: 2nd of February, 2025  
**Submission Opportunity**: First Attempt  

---

## Summary  
This research investigates the integration of **VR streaming** and **haptic feedback** into a networked XR environment, focusing on the impact of **network degradation** on system performance and usability.  

### Research Questions  
1. How does network latency affect VR streaming performance?  
2. How does network latency influence haptic feedback accuracy?  
3. Can VR streaming and haptic feedback function effectively as an integrated system?  

### Methodology  
The study combines **experimental testing** and **literature research**. Tools used include **ALVR** for VR streaming, **Ultraleap** for tactile feedback, and **Clumsy** for network degradation simulation. Performance data, such as latency, frame rates, and input delays, were logged in JSON format and analyzed alongside structured user experience feedback.

### Results  
- **VR Streaming**: Performance significantly declines at **100ms latency**, resulting in reduced frame rates and increased input lag.  
- **Haptic Feedback**: Feedback accuracy deteriorates beyond **150ms latency** but remains functional up to this point.  
- **Combined System**: VR streaming and haptic feedback require latency below **100ms** to deliver a smooth and integrated experience.  

### Conclusion  
Integrating VR streaming and haptic systems in a networked XR environment is feasible but highly sensitive to latency. Future research should optimize network stability and refine synchronization to improve system performance.  

---

## Introduction  
### Background  
Extended Reality (XR) technologies integrate **Virtual Reality (VR)** and **haptic feedback**, delivering immersive and interactive experiences for simulations, education, gaming, and industrial applications. However, networked XR systems face challenges, particularly in environments impacted by **latency** and **network variability**.

### Problem Statement  
The key challenges addressed in this research are:  
1. **Network Latency**: Delayed VR streaming disrupts real-time rendering and user inputs.  
2. **Haptic Feedback Sensitivity**: Tactile feedback devices are vulnerable to latency, reducing responsiveness.  
3. **System Integration**: Achieving synchronization between VR visuals and haptic feedback under degraded network conditions.  

### Importance  
This research is relevant to:  
- **TNO**: Supporting research on latency effects in networked XR systems.  
- **Royal Dutch Army**: Exploring haptic-enabled XR for immersive training simulations.  
- **XR Developers**: Enhancing tools and technologies for networked immersive environments.  

### Research Objective  
To evaluate the integration of VR streaming and haptic feedback within a networked XR environment and measure their performance under simulated network degradation.  

**Main Research Question**:  
*How does network degradation impact VR and haptic feedback integration within a networked XR environment?*  

**Sub-Questions**:  
1. How does network latency affect VR streaming performance?  
2. What impact does latency have on haptic feedback accuracy and responsiveness?  
3. Can both systems deliver an integrated user experience under degraded network conditions?  

---

## Theoretical Framework  
### Existing Challenges  
1. **Latency in XR Systems**: Streaming platforms like **NVIDIA GeForce Now** and **Google Stadia** demonstrate how latency can disrupt real-time rendering. These systems do not incorporate haptic feedback, which introduces additional complexities.  
2. **Haptic Feedback Sensitivity**: Devices like **Ultraleap** provide accurate tactile sensations locally, but their behavior under network latency remains under-researched.  

### Existing Solutions  
- **ALVR**: Open-source tool for streaming VR content wirelessly to headsets.  
- **Clumsy**: Tool for simulating network latency, jitter, and packet loss.  
- **Ultraleap**: Haptic feedback devices using ultrasonic waves for tactile interactions in Unity environments.  

### Knowledge Gap  
Existing research has not adequately addressed the combined effects of network degradation on VR streaming and haptic feedback systems. This study aims to bridge that gap through practical testing and detailed performance analysis.  

---

## Methodology  
### Research Design  
The research uses a **mixed-method approach**: experimental testing to gather quantitative data and literature review for theoretical insights.

### Tools and Software  
- **VR Streaming**: ALVR for wireless VR streaming.  
- **Haptic Feedback**: Ultraleap Haptic Feedback Kit.  
- **Network Simulation**: Clumsy for latency and packet loss simulation.  
- **Development Platform**: Unity with SteamVR integration.  

### Experimental Setup  
1. **Baseline Testing**: Measure VR and haptic feedback performance in ideal conditions (0ms latency).  
2. **Simulated Network Degradation**: Use Clumsy to simulate incremental latencies (50ms, 100ms, 200ms).  
3. **Performance Logging**: Capture frame rates, input delays, and haptic accuracy in JSON format.  
4. **User Feedback**: Collect structured survey data to evaluate usability and user experience.  

---

## Results  
### VR Streaming Performance  
| **Latency (ms)** | **Frame Rate (FPS)** | **Input Delay (ms)** | **User Feedback**             |  
|------------------|----------------------|----------------------|--------------------------------|  
| 50               | 72                   | 20                   | "Smooth and responsive."       |  
| 100              | 60                   | 50                   | "Slight lag, still acceptable."|  
| 200              | 40                   | 150                  | "Severe lag, unusable."        |  

### Haptic Feedback Performance  
| **Latency (ms)** | **Feedback Accuracy** | **User Comments**                    |  
|------------------|-----------------------|--------------------------------------|  
| 50               | 95%                   | "Accurate and immersive response."   |  
| 100              | 80%                   | "Slight delay, still functional."    |  
| 200              | 50%                   | "Noticeable lag, unreliable feedback."|  

### Combined System Performance  
- At **50ms latency**, VR streaming and haptic feedback systems performed smoothly.  
- At **100ms latency**, users reported minor delays but still found the system usable.  
- At **200ms latency**, both VR and haptic systems experienced severe disruptions, rendering the experience unusable.  

---

## Conclusion and Recommendations  
### Conclusion  
This study demonstrates that network degradation significantly impacts the performance and usability of integrated VR streaming and haptic feedback systems.  

**Key Findings**:  
1. VR streaming is significantly impacted at **100ms latency**, reducing frame rates and increasing lag.  
2. Haptic feedback remains functional up to **150ms** but degrades beyond this threshold.  
3. For optimal performance, both systems require network latency below **100ms**.  

### Recommendations  
1. **Network Optimization**: Maintain latency below **100ms** to ensure smooth operation.  
2. **Synchronization Improvements**: Develop algorithms to enhance VR-haptic synchronization under latency conditions.  
3. **Broader Testing**: Conduct tests with larger user groups and diverse network conditions for comprehensive analysis.  

---

## References  
1. ALVR. (n.d.). *Open Source VR Streaming*. Retrieved from: [https://github.com/alvr-org/ALVR](https://github.com/alvr-org/ALVR)  
2. Ultraleap. (n.d.). *Haptics Development Kit*. Retrieved from: [https://leap2.ultraleap.com](https://leap2.ultraleap.com)  
3. Clumsy Network Tool. (n.d.). Retrieved from: [https://jagt.github.io/clumsy/](https://jagt.github.io/clumsy/)  
4. Unity Technologies. (n.d.). *Unity VR Overview*. Retrieved from: [https://docs.unity3d.com](https://docs.unity3d.com)  

---

## Glossary  
- **Latency**: Delay between user input and system response.  
- **Haptic Feedback**: Tactile sensations generated using ultrasonic waves.  
- **ALVR**: Software for VR streaming over networks.  

---

## Appendices  
1. **Performance Logs**: JSON files recording latency, FPS, and user inputs.  
2. **Scripts**: C# code for VR and haptic integration.  
3. **Survey Results**: User feedback on usability and performance.  
4. **Latency Simulation Settings**: Clumsy configuration files.  

---
