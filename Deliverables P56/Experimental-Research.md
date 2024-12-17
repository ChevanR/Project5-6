# Experimental Research: Measuring VR Latency Impact and Haptic Feedback Delays  

---

## Introduction  
This experiment evaluates the impact of **network latency** on **VR user experience** and task performance while investigating the latency tolerance of ultrasonic **haptic feedback devices**. The primary goal is to identify the maximum acceptable delays for usability, performance, and user comfort.  

---

## Research Questions  
1. **What is the maximum acceptable latency in VR environments before performance, usability, and user comfort are disrupted?**  
2. **How much delay can ultrasonic arrays introduce before haptic feedback becomes unusable?**  

---

## Methodology  

### Part 1: VR Latency Impact Testing  
**Setup**  
- **Hardware**: Oculus Meta Quest 3 and a standard laptop.  
- **Software**: ALVR for VR streaming, Unity for latency simulation.  
- **Measurement Tools**: Unity Profiler (input latency, frame timing), user feedback forms (motion sickness, usability).  

**Procedure**  
1. **Latency Simulation**: Simulate network latency increments (0ms, 50ms, 100ms, 150ms, 200ms, 300ms, 400ms) using **Clumsy**.  
2. **User Testing**:  
   - Participants completed VR tasks, including object manipulation and navigation, under each latency condition.  
   - Participants rated their experiences based on:  
     - **Motion Sickness**: 1–10 scale  
     - **Task Performance**: 1–10 scale  
     - **Usability**: 1–10 scale  
3. **Data Collection**:  
   - Quantitative: Frame rates, input delays (Unity Profiler).  
   - Qualitative: User feedback logs (motion sickness, comfort, usability).  

---

## Results: VR Latency Impact  

### Motion Sickness vs. Latency  
| **Latency (ms)** | **Tester 1** | **Tester 2** | **Tester 3** | **Tester 4** |  
|------------------|--------------|--------------|--------------|--------------|  
| 0               | 10           | 10           | 10           | 10           |  
| 50              | 10           | 10           | 10           | 10           |  
| 100             | 10           | 10           | 7            | 10           |  
| 150             | 10           | 10           | 7            | 10           |  
| 200             | 10           | 10           | 7            | 10           |  
| 300             | 10           | 10           | 7            | 10           |  
| 400             | 10           | 10           | 3            | 10           |  

### Task Performance vs. Latency  
| **Latency (ms)** | **Tester 1** | **Tester 2** | **Tester 3** | **Tester 4** |  
|------------------|--------------|--------------|--------------|--------------|  
| 0               | 10           | 10           | 10           | 10           |  
| 50              | 10           | 10           | 9            | 9            |  
| 100             | 8            | 8            | 6            | 8            |  
| 150             | 6            | 5            | 4            | 7            |  
| 200             | 4            | 4            | 4            | 6            |  
| 300             | 2            | 3            | 4            | 4            |  
| 400             | 2            | 2            | 2            | 2            |  

### Usability vs. Latency  
| **Latency (ms)** | **Tester 1** | **Tester 2** | **Tester 3** | **Tester 4** |  
|------------------|--------------|--------------|--------------|--------------|  
| 0               | 10           | 10           | 10           | 10           |  
| 50              | 10           | 10           | 7            | 10           |  
| 100             | 9            | 9            | 7            | 10           |  
| 150             | 8            | 7            | 4            | 8            |  
| 200             | 6            | 6            | 4            | 6            |  
| 300             | 4            | 4            | 2            | 4            |  
| 400             | 2            | 2            | 2            | 2            |  

---

## Analysis  
- **Motion Sickness**: Most participants reported stable comfort levels until latency exceeded **400ms**. Tester 3 showed sensitivity starting at **100ms**.  
- **Task Performance**: Performance scores declined sharply beyond **100ms latency**, with significant degradation at **200ms** and near-failure at **400ms**.  
- **Usability**: Usability ratings decreased significantly beyond **150ms**, rendering the VR experience unusable past **300ms** latency.

---

### Part 2: Haptic Feedback Delay Testing  
**Status**: Preliminary tests of **Ultraleap Haptic Devices** indicate variability in response times under simulated latency. Initial results suggest tactile accuracy declines beyond **150ms latency**, but further testing is required to confirm thresholds.  

---

## Conclusion  
1. **VR Streaming**: Usability and task performance decline noticeably at **100ms latency**. Latency beyond **150ms** significantly impacts user experience.  
2. **Motion Sickness**: Most participants tolerated latency up to **300ms**. Sensitivity varies among individuals.  
3. **Haptic Feedback**: Preliminary results indicate feedback degradation beyond **150ms latency**. Further testing is ongoing.  

**Acceptable Latency Threshold**:  
- VR Streaming: **50–100ms** for optimal usability.  
- Haptic Feedback: Under investigation (preliminary: **up to 150ms**).  

---

## Future Work  
1. **Refine Haptic Testing**: Improve measurement tools to isolate and evaluate haptic response delays.  
2. **Expand User Testing**: Increase participant diversity to gather broader data on latency tolerances.  
3. **System Optimization**: Develop solutions to mitigate latency, such as predictive algorithms or optimized streaming protocols.

---

## References  
1. ALVR. (n.d.). *Open Source VR Streaming*. Retrieved from: [https://github.com/alvr-org/ALVR](https://github.com/alvr-org/ALVR)  
2. Ultraleap. (n.d.). *Haptics Development Kit*. Retrieved from: [https://leap2.ultraleap.com](https://leap2.ultraleap.com)  
3. Unity Technologies. (n.d.). *Unity VR Overview*. Retrieved from: [https://docs.unity3d.com](https://docs.unity3d.com)  
4. Clumsy. (n.d.). *Network Latency Simulator*. Retrieved from: [https://jagt.github.io/clumsy/](https://jagt.github.io/clumsy/)

---
