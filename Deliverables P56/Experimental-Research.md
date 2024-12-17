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
- **Hardware Used**: Oculus Meta Quest 3 and a standard laptop.  
- **Software Used**: ALVR for VR streaming, Unity for controlled latency simulation.  
- **Measurement Tools**: Unity Profiler for input latency and frame timing, user feedback forms used to assess the subjective experience of latency impacts on usability and comfort.

**Procedure**  
1. **Latency Simulation**: Using Clumsy, network latency was simulated in controlled increments from 0ms to 400ms to mimic varying network conditions.
2. **User Testing**:
   - Participants were instructed to complete a series of VR tasks, including object manipulation and navigation, under each latency setting.
   - After each session, participants rated their experience based on motion sickness, task performance, and overall usability.
3. **Data Collection**: Detailed logs were kept for each session, recording both quantitative data (frame rates, input delays) and qualitative feedback (user comfort levels and task difficulty).

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

#### Part 2: Haptic Feedback Delay Testing  
**Status**: Initial tests have begun to measure the response times of ultrasonic haptic devices under similar latency conditions. Preliminary findings suggest variability in feedback accuracy, prompting further investigation into optimal latency thresholds for effective tactile feedback.

---

### Conclusion  
- For **VR latency**, delays above **100ms** noticeably impact task performance and usability. Motion sickness levels remain stable for most users up to **300ms**, except for sensitive individuals.  
- The acceptable latency threshold for an immersive and usable VR experience is approximately **50-100ms**.  
- The results for haptic feedback latency are pending, with ongoing testing to determine usability thresholds for tactile response delays.

---

**Future Steps**:
   - Refine the experimental setup to isolate and measure specific delays introduced by haptic devices.
   - Expand the user testing pool to gather a broader range of responses on the usability and comfort of haptic feedback under different latency conditions.

---

### References  
- [ALVR - Open Source VR Streaming](https://github.com/alvr-org/ALVR)  
- [Ultraleap Haptics Development Kit](https://leap2.ultraleap.com/products/haptics-development-kit)  
- [Unity Manual - Virtual Reality Overview](https://docs.unity.com/Manual/VROverview.html)  
- **Clumsy Network Tool** - A tool for simulating network conditions such as latency and packet loss.

---
