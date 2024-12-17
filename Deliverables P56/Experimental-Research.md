## Experimental Research: Measuring VR Latency Impact and Haptic Feedback Delays

### Introduction  
This experiment evaluates the impact of latency on VR user experience and task performance, alongside an ongoing investigation into the latency introduced by ultrasonic haptic devices. The goal is to determine the maximum acceptable delay for usability and performance.

---

### Research Question  
1. **What is the maximum acceptable latency in VR environments before performance, usability, and user comfort are disrupted?**  
2. **How much delay can ultrasonic arrays introduce before haptic feedback becomes unusable?**

---

### Methodology  

#### Part 1: VR Latency Impact Testing  
**Setup**  
- **Hardware Used**: Oculus Meta Quest 3, a VR system, and a standard laptop.  
- **Software Used**: ALVR for VR streaming, Unity for controlled latency simulation.  
- **Measurement Tools**: Unity Profiler for input latency and frame timing, user feedback forms.  

**Procedure**  
1. **Latency Simulation**: Simulated network latency in controlled increments (0ms, 50ms, 100ms, 150ms, 200ms, 300ms, 400ms).  
2. **User Testing**:
   - Users completed tasks (e.g., object manipulation and navigation) under each latency condition.
   - Feedback was collected for:
     - **Motion Sickness Level** (Scale: 1-10)
     - **Task Performance Score** (Scale: 1-10)
     - **Usability Score** (Scale: 1-10)
3. **Data Collection**: Results were recorded per tester for each latency level.  

---

### Results: VR Latency Impact  

#### Motion Sickness vs. Latency
| **Latency (ms)** | **Tester 1** | **Tester 2** | **Tester 3** | **Tester 4** |
|------------------|--------------|--------------|--------------|--------------|
| 0               | 10           | 10           | 10           | 10           |
| 50              | 10           | 10           | 10           | 10           |
| 100             | 10           | 10           | 7            | 10           |
| 150             | 10           | 10           | 7            | 10           |
| 200             | 10           | 10           | 7            | 10           |
| 300             | 10           | 10           | 7            | 10           |
| 400             | 10           | 10           | 3            | 10           |

#### Task Performance vs. Latency
| **Latency (ms)** | **Tester 1** | **Tester 2** | **Tester 3** | **Tester 4** |
|------------------|--------------|--------------|--------------|--------------|
| 0               | 10           | 10           | 10           | 10           |
| 50              | 10           | 10           | 9            | 9            |
| 100             | 8            | 8            | 6            | 8            |
| 150             | 6            | 5            | 4            | 7            |
| 200             | 4            | 4            | 4            | 6            |
| 300             | 2            | 3            | 4            | 4            |
| 400             | 2            | 2            | 2            | 2            |

#### Usability vs. Latency
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

### Analysis  
- **Motion Sickness**: Most testers reported no motion sickness until latency exceeded **400ms**. Tester 3 showed sensitivity starting at 100ms.  
- **Task Performance**: Performance scores declined significantly after **100ms**, with tasks becoming nearly impossible at **400ms** latency.  
- **Usability**: Delays above **150ms** caused noticeable usability degradation, while delays beyond **300ms** made the VR experience unusable for all testers.

---

### Part 2: Haptic Feedback Delay Testing  
**Status**:  
The haptic feedback delay testing is still in progress. Preliminary results suggest a need to refine the test setup to measure tactile delays accurately.

---

### Conclusion  
- For **VR latency**, delays above **100ms** noticeably impact task performance and usability. Motion sickness levels remain stable for most users up to **300ms**, except for sensitive individuals.  
- The acceptable latency threshold for an immersive and usable VR experience is approximately **50-100ms**.  
- The results for haptic feedback latency are pending, with ongoing testing to determine usability thresholds for tactile response delays.

---

### Future Work  
- Complete the **haptic feedback latency** testing and integrate findings into the XR environment.  
- Explore hardware solutions to improve response times for both visual and haptic interactions.

---

### References  
- [ALVR - Open Source VR Streaming](https://github.com/alvr-org/ALVR)  
- [Ultraleap Haptics Development Kit](https://leap2.ultraleap.com/products/haptics-development-kit)  
- [Unity Manual - Virtual Reality Overview](https://docs.unity3d.com/Manual/VROverview.html)  
- **Clumsy Network Tool** - A tool for simulating network conditions such as latency and packet loss.

---
