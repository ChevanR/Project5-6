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
- **Hardware**: Oculus Meta Quest 3 and a laptop containing a powerfull enough gpu.  
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

## Results  

### Motion Sickness vs. Latency  
| **Latency (ms)** | **Avg. Score** | **Tester 1** | **Tester 2** | **Tester 3** | **Tester 4** |  
|------------------|----------------|--------------|--------------|--------------|--------------|  
| 0               | 10             | 10           | 10           | 10           | 10           |  
| 50              | 10             | 10           | 10           | 10           | 10           |  
| 100             | 9.25           | 10           | 10           | 7            | 10           |  
| 150             | 9.0            | 10           | 10           | 7            | 10           |  
| 200             | 8.25           | 10           | 10           | 7            | 10           |  
| 300             | 8.25           | 10           | 10           | 7            | 10           |  
| 400             | 8.25           | 10           | 10           | 3            | 10           |  

### Task Performance vs. Latency  
| **Latency (ms)** | **Avg. Score** | **Tester 1** | **Tester 2** | **Tester 3** | **Tester 4** |  
|------------------|----------------|--------------|--------------|--------------|--------------|  
| 0               | 10             | 10           | 10           | 10           | 10           |  
| 50              | 9.75           | 10           | 10           | 9            | 9            |  
| 100             | 7.5            | 8            | 8            | 6            | 8            |  
| 150             | 5.5            | 6            | 5            | 4            | 7            |  
| 200             | 4.5            | 4            | 4            | 4            | 6            |  
| 300             | 3.25           | 2            | 3            | 4            | 4            |  
| 400             | 2.0            | 2            | 2            | 2            | 2            |  

### Usability vs. Latency  
| **Latency (ms)** | **Avg. Score** | **Tester 1** | **Tester 2** | **Tester 3** | **Tester 4** |  
|------------------|----------------|--------------|--------------|--------------|--------------|  
| 0               | 10             | 10           | 10           | 10           | 10           |  
| 50              | 9.25           | 10           | 10           | 7            | 10           |  
| 100             | 8.75           | 9            | 9            | 7            | 10           |  
| 150             | 7.75           | 8            | 7            | 4            | 8            |  
| 200             | 6.0            | 6            | 6            | 4            | 6            |  
| 300             | 3.5            | 4            | 4            | 2            | 4            |  
| 400             | 2.0            | 2            | 2            | 2            | 2            |  

---

## Analysis Summary  
- **Motion Sickness**: Stable for most users up to **300ms**; Tester 3 experienced discomfort starting at **100ms**.  
- **Task Performance**: Noticeable degradation begins at **100ms latency**, with near failure beyond **200ms latency**.  
- **Usability**: Decreased usability occurs beyond **150ms**, becoming unusable at **300ms latency**.  

---

### Part 2: Haptic Feedback Delay Testing  
**Status**: Preliminary tests indicate tactile accuracy declines beyond **150ms latency**. Further testing with isolated delay conditions (150ms–300ms) is planned to confirm findings.  

---

## Conclusion  
1. **VR Streaming**:  
   - Optimal performance: **50–100ms latency**.  
   - Usability degrades: Beyond **150ms latency**.  
2. **Motion Sickness**:  
   - Tolerable latency: Up to **300ms** (individual sensitivity varies).  
3. **Haptic Feedback**:  
   - Preliminary results: Reliable up to **150ms latency**.  

**Acceptable Latency Thresholds:**  
- **VR Streaming**: 50–100ms  
- **Haptic Feedback**: Up to 150ms (pending validation).  

---

## Future Work  
1. **Refine Haptic Testing**: Improve measurement tools and isolate response times accurately.  
2. **Expand User Testing**: Increase participant diversity to validate thresholds across broader user groups.  
3. **System Optimization**: Explore predictive algorithms or network optimization techniques to mitigate latency effects.  

---

## References  
1. ALVR. (n.d.). *Open Source VR Streaming*. Retrieved from: [https://github.com/alvr-org/ALVR](https://github.com/alvr-org/ALVR) (Accessed: June 2024).  
2. Ultraleap. (n.d.). *Haptics Development Kit*. Retrieved from: [https://leap2.ultraleap.com](https://leap2.ultraleap.com) (Accessed: June 2024).  
3. Unity Technologies. (n.d.). *Unity VR Overview*. Retrieved from: [https://docs.unity3d.com](https://docs.unity3d.com) (Accessed: June 2024).  
4. Clumsy. (n.d.). *Network Latency Simulator*. Retrieved from: [https://jagt.github.io/clumsy/](https://jagt.github.io/clumsy/) (Accessed: June 2024).  

---
