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
This research investigates the integration of **VR streaming** and **haptic feedback** into a networked XR environment, focusing on the impact of **network degradation** on performance and usability.  

### Research Questions  
1. **How does network latency affect VR streaming performance?**  
2. **How does network latency influence haptic feedback accuracy?**  
3. **Can VR streaming and haptic feedback function effectively as an integrated system?**  

### Methodology  
The study combines **experimental testing** and **literature research**. Tools include **ALVR** for VR streaming, **Ultraleap** for haptic feedback, and **Clumsy** for network degradation simulation. Performance data (e.g., latency, frame rates, and input delays) were logged in JSON format and analyzed alongside user feedback.  

### Results  
- **VR Streaming**: Performance declines significantly at **150ms latency**, reducing frame rates and increasing lag.  
- **Haptic Feedback**: Accuracy deteriorates beyond **300ms latency**, but remains functionally viable up to this point.  
- **Combined System**: Latency below **125ms** is required for smooth operation, depending on the use and user.  

You can read more about the results in the [experimental research](/Deliverables-P56/Experimental-Research.md).

#### Architecture diagram
![](Architecture%20diagram.png)

Note that the delayed data sources can be modified with the latency needed.

##### Sources:
- Haptic: [Ultraleap](https://leap2.ultraleap.com/wp-content/uploads/2024/05/compact-array.png)
- Unity Script: [cloudinary](https://res.cloudinary.com/upwork-cloud/image/upload/c_scale,w_1000/v1709143446/catalog/1597899066014560256/qtkclgncqpdd7ciftxfc.webp)
- Clumsy: Screenshot
- ALVR: [ALVR github](https://github.com/alvr-org/alvr)
- Unity: [logos world](https://logos-world.net/wp-content/uploads/2021/11/Unity-Emblem.png)
- SteamVR: [kxcdn](https://roadtovrlive-5ea0.kxcdn.com/wp-content/uploads/2020/07/steamvr-logo.png)
- VR headset: [Notebookcheck](https://www.notebookcheck.net/fileadmin/Notebooks/News/_nc3/FxivtNGaEAYau59.jpeg)

### Conclusion  
VR streaming and haptic feedback can be integrated into a networked XR environment but are highly sensitive to latency. Network optimization and improved synchronization are key to enhancing system performance.  

---

## Introduction  
### Background  
**Extended Reality (XR)** integrates **Virtual Reality (VR)** with **haptic feedback**, enhancing immersion for simulations, education, and gaming. However, networked XR systems are particularly vulnerable to **latency** and **network variability**, which affect real-time interactivity.  

### Problem Statement  
This research tackles the following challenges:  
1. **Network Latency**: Disrupted VR rendering and input delays.  
2. **Haptic Feedback Sensitivity**: Reduced accuracy under network latency.  
3. **Synchronization**: Difficulty aligning VR visuals and haptic feedback under degraded conditions.  

### Importance  
This research benefits:  
- **TNO**: Supporting latency-focused XR research.  
- **Royal Dutch Army**: Exploring immersive XR training solutions.  
- **XR Developers**: Enhancing tools for networked environments.  

### Research Objective  
Evaluate the impact of network degradation on **VR streaming** and **haptic feedback**, and explore their integration in XR environments.  

**Main Research Question**:  
*How does network degradation impact VR and haptic feedback integration in a networked XR environment?*  

**Sub-Questions**:  
1. How does latency affect VR streaming performance?  
2. What impact does latency have on haptic feedback accuracy?  
3. Can VR streaming and haptic feedback function smoothly as an integrated system?  

---

## Theoretical Framework  
### Existing Challenges  
1. **Latency in XR Systems**:  
   - Real-time streaming tools like **NVIDIA GeForce Now** highlight the disruption caused by latency.  
2. **Haptic Feedback Sensitivity**:  
   - Devices such as **Ultraleap** provide local tactile responses, but little research explores their behavior under network latency.  

### Existing Solutions  
- **ALVR**: Open-source tool for wireless VR streaming.  
- **Clumsy**: Simulates latency, jitter, and packet loss.  
- **Ultraleap**: Generates ultrasonic-based tactile feedback in Unity.  

### Knowledge Gap  
Existing literature lacks research on integrating VR streaming with haptic feedback under network degradation. This study addresses that gap using controlled experiments.  

---

## Methodology  
### Research Design  
A **mixed-method approach** combining experimental testing and literature analysis.  

### Tools and Software  
- **VR Streaming**: ALVR  
- **Haptic Feedback**: Ultraleap Haptic Feedback Kit  
- **Network Simulation**: Clumsy  
- **Development Platform**: Unity with SteamVR  

### Experimental Setup  
1. **Baseline Testing**: Measure VR streaming and haptic feedback performance at 0ms latency.  
2. **Simulated Network Degradation**: Incremental latency added (50ms, 100ms, 200ms) using **Clumsy**.  
3. **Performance Logging**: Frame rates, input lag, and haptic response times logged in JSON format.  
4. **User Feedback**: Surveys assessing usability, task performance, and motion sickness.  

---

## Results  
### VR Streaming Performance  
| **Latency (ms)** | **Frame Rate (FPS)** | **Input Delay (ms)** | **User Feedback**               |
| ---------------- | -------------------- | -------------------- | ------------------------------- |
| 50               | 72                   | 20                   | "Smooth and responsive."        |
| 100              | 60                   | 50                   | "Slight lag, still acceptable." |
| 200              | 40                   | 150                  | "Severe lag, unusable."         |

### Haptic Feedback Performance  
| **Latency (ms)** | **Feedback Accuracy** | **User Comments**                      |
| ---------------- | --------------------- | -------------------------------------- |
| 50               | 95%                   | "Accurate and immersive response."     |
| 100              | 80%                   | "Slight delay, still functional."      |
| 200              | 50%                   | "Noticeable lag, unreliable feedback." |

---

## Conclusion and Recommendations  
### Conclusion  
Network latency significantly impacts VR streaming and haptic feedback performance.  

**Key Findings**:  
1. VR streaming performance declines noticeably at **125ms latency**.  
2. Haptic feedback remains functional up to **300ms latency** but degrades thereafter.  
3. Combined VR and haptic systems require latency below **125ms** for smooth integration.  
4. The ultrasonic array makes it difficult to use communication involving headsets and microphones, because of the noise they make in a ~5m radius.

### Recommendations  
1. **Optimize Network Conditions**: Maintain latency below **125ms**.  
2. **Refine Synchronization**: Develop algorithms to improve VR-haptic synchronization.  
3. **Broader Testing**: Conduct larger-scale tests under varying network conditions.  

---

## References  
1. ALVR. (n.d.). *Open Source VR Streaming*. Retrieved from: [https://github.com/alvr-org/ALVR](https://github.com/alvr-org/ALVR)  
2. Ultraleap. (n.d.). *Haptics Development Kit*. Retrieved from: [https://leap2.ultraleap.com](https://leap2.ultraleap.com)  
3. Clumsy. (n.d.). *Network Latency Simulator*. Retrieved from: [https://jagt.github.io/clumsy/](https://jagt.github.io/clumsy/)  
4. Unity Technologies. (n.d.). *Unity VR Overview*. Retrieved from: [https://docs.unity3d.com](https://docs.unity3d.com)  

---

## Glossary  
- **Latency**: Delay between user input and system response.  
- **Haptic Feedback**: Tactile sensations generated by ultrasonic waves.  
- **ALVR**: Open-source VR streaming software.  

---

## Appendices  
1. **Performance Logs**: JSON files recording latency, FPS, and input delays.  
2. **C# Scripts**: Code for VR and haptic feedback integration.  
3. **User Surveys**: Structured questionnaires for user feedback.  
4. **Latency Simulation Settings**: Clumsy configuration files.  

---
