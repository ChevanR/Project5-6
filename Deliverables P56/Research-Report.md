# Research Report: VR and Haptic Feedback Integration in a Networked XR Environment  

---

## Cover Page  
**Title**: VR and Haptic Feedback Integration in a Networked XR Environment  
**Authors**: Chevan Ramcharan, Pirmin Kalbermatter, Derk Ottersberg & Pepijn Brinkman  
**Student Number**: 1072166, 1069542, 1076265, 1078024
**Supervisors**: Mrs. Colleen Chen, Mr. Milan Wijnmalen
**Submission Date**: 2nd of February, 2025  
**Submission Opportunity**: First Attempt  

---

## Summary  
This research investigates the integration of **VR streaming** and **haptic feedback** into a networked XR environment while evaluating the impact of **network degradation** on performance and usability.  

### Research Questions  
1. How does network latency affect VR performance?  
2. How does latency influence the effectiveness of haptic feedback?  
3. Can VR streaming and haptic feedback function effectively as an integrated system?  

### Methodology  
The study utilized experimental testing and literature research. Tools used include **ALVR** for VR streaming, **Ultraleap** for tactile feedback, and **Clumsy** for network degradation simulation. Performance data was logged (JSON format) and analyzed alongside user experience feedback.  

### Results  
- VR streaming performance declines significantly at **100ms latency**, impacting frame rates and input lag.  
- Haptic feedback becomes unreliable beyond **150ms latency** but remains functional up to this point.  
- Combined VR and haptic systems require latency below **100ms** for optimal performance.  

### Conclusion  
The integration of VR and haptic systems in a networked XR environment is feasible but sensitive to latency. Optimized networks and further refinement of feedback synchronization are necessary for smooth operation.  

---

## Introduction  
### Background  
Extended Reality (XR) integrates **Virtual Reality (VR)** with **haptic feedback**, enhancing realism and immersion in virtual environments. XR systems are used for simulations, education, and gaming but face significant challenges in networked environments, primarily due to **latency** and **input delays**.  

### Problem Statement  
The primary challenges include:  
1. **Network Latency**: Delayed streaming disrupts real-time VR rendering and haptic responses.  
2. **Haptic Integration**: Tactile devices are sensitive to network delays, leading to reduced accuracy.  
3. **System Integration**: Synchronizing VR visuals and haptic feedback under network degradation remains complex.  

### Importance  
This research addresses these challenges to benefit:  
- **TNO**: Research into latency effects on networked XR systems.  
- **Royal Dutch Army**: Investigation into haptic-enabled XR for training simulations.  
- **Target Users**: XR developers, trainers, and immersive technology users.  

### Objective  
To evaluate the feasibility of integrating VR streaming and haptic feedback into a networked XR environment and measure their performance under simulated network degradation.  

### Research Question  
**"How does network degradation impact VR and haptic feedback integration within a networked XR environment?"**  

**Sub-Questions**:  
1. How does network latency affect VR streaming performance?  
2. What impact does latency have on haptic feedback responsiveness?  
3. Can both systems function effectively when combined under degraded network conditions?  

---

## Theoretical Framework  
### Existing Challenges  
1. **Latency in XR Systems**: Platforms like NVIDIA GeForce Now and Stadia demonstrate how latency disrupts real-time streaming but do not integrate haptic feedback.  
2. **Haptic Feedback Sensitivity**: Ultraleap Haptic Devices provide tactile sensations locally, but their performance under network degradation has not been fully tested.  

### Existing Solutions  
- **ALVR**: Open-source tool for streaming VR content to wireless headsets.  
- **Clumsy**: Network simulation tool to introduce latency, jitter, and packet loss.  
- **Ultraleap**: Haptic devices using ultrasonic waves for tactile feedback integration in Unity.  

### Knowledge Gap  
Limited research exists on combining VR streaming and haptic feedback systems under network degradation scenarios. This study addresses this gap through practical testing and data analysis.  

---

## Methodology  
### Research Design  
The study uses a mix of **experimental testing** and **literature research** to evaluate VR and haptic system performance under varying network conditions.  

### Tools and Software  
- **VR Streaming**: ALVR  
- **Haptic Feedback**: Ultraleap Haptic Feedback Kit  
- **Network Simulation**: Clumsy  
- **Development Environment**: Unity with SteamVR  

### Experimental Setup  
1. **Baseline Testing**: Establish VR and haptic feedback performance without network interference.  
2. **Network Degradation Simulation**: Introduce latency increments (50ms, 100ms, 200ms) using Clumsy.  
3. **Data Collection**:  
   - Log frame rates, input delays, and haptic responsiveness (stored in JSON).  
   - Gather user feedback through structured surveys.  
4. **Analysis**: Correlate network latency, system performance, and user experience.  

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
- At **50ms latency**, VR and haptic feedback systems function smoothly.  
- At **100ms latency**, minor delays occur but remain acceptable for users.  
- At **200ms latency**, both VR visuals and haptic responses experience severe disruptions, reducing usability.  

---

## Conclusion and Recommendations  
### Conclusion  
This research evaluated how network degradation impacts the integration of VR streaming and haptic feedback systems in XR environments.  

**Findings**:  
1. VR streaming remains smooth up to **100ms** latency but degrades significantly beyond that.  
2. Haptic feedback performs reliably up to **150ms latency** but becomes inaccurate at higher delays.  
3. Combining both systems requires maintaining network latency below **100ms** for optimal user experience.  

### Recommendations  
1. **Optimize Network Conditions**: Ensure latency remains below **100ms** to achieve smooth performance.  
2. **System Synchronization**: Further develop synchronization between VR visuals and haptic feedback systems.  
3. **User Testing**: Conduct larger-scale user tests to refine system performance and usability.  

---

## References  
1. ALVR. (n.d.). *Open Source VR Streaming*. Retrieved from: [https://github.com/alvr-org/ALVR](https://github.com/alvr-org/ALVR)  
2. Ultraleap. (n.d.). *Haptics Development Kit*. Retrieved from: [https://leap2.ultraleap.com](https://leap2.ultraleap.com)  
3. Clumsy Network Tool. (n.d.). Retrieved from: [https://jagt.github.io/clumsy/](https://jagt.github.io/clumsy/)  
4. Unity Technologies. (n.d.). *Unity VR Overview*. Retrieved from: [https://docs.unity3d.com](https://docs.unity3d.com)  

---

## Glossary  
- **Latency**: Delay between user input and system response.  
- **Haptic Feedback**: Tactile sensations generated by devices like Ultraleap.  
- **ALVR**: Open-source software for VR streaming over networks.  

---

## Appendices  
1. **VR-output**: JSON files of recorded performance data.  
2. **C# Scripts**: Code for VR and haptic integration.  
3. **VR-output**: User feedback on system usability and performance.  
4. **VR-scripts**: Settings used for latency simulation.  
