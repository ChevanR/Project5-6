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
- **Hardware**: Oculus Meta Quest 3 and a laptop with compatible GPU-specs.  
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
See the json and html files [here](/Deliverables-P56/Degradation/)
Users 1-4 where tested without using haptics.
### Setup
The setup consisted of:  
- ALVR (VR streaming)
  - Testers 1-2 used wired(TCP) connection, with Oculus Meta Quest 3
  - Testers 3-4 used wireless(UDP) connection, with VIVE Focus 3
  - Tester 1 used a localhost degradation, whilst Tester 2 was specifically for the AVLR streaming port (this impacts anything to do with FPS)
- ALVR settings (All the settings that mostly matter, or have been changed):
  - Resolution: 4288
  - Preferred framerate: 90Hz
  - Encoder preset: Speed
  - Bitrate: 30Mbps Constant
  - Adept to framerate: True
  - Preferred codec: h264
- The Lab on [Steam](https://store.steampowered.com/app/450390/The_Lab/) -- General movement in the lobby and using the bow to shoot balloons
- Clumsy (Network degradation)
- Laptop specs:
  - CPU: i7 12700h
  - GPU: RTX A1000
  - RAM: 32GB 4800MHZ

More info can be found [here](/Deliverables-P56/Usage-guide.md)

### Motion Sickness vs. Latency  
| **Latency (ms)** | **Avg. Score** | **Tester 1** | **Tester 2** | **Tester 3** | **Tester 4** |
| ---------------- | -------------- | ------------ | ------------ | ------------ | ------------ |
| 0                | 10             | 10           | 10           | 10           | 10           |
| 50               | 10             | 10           | 10           | 10           | 10           |
| 100              | 9.25           | 10           | 10           | 7            | 10           |
| 150              | 9.0            | 10           | 10           | 7            | 10           |
| 200              | 8.25           | 10           | 10           | 7            | 10           |
| 300              | 8.25           | 10           | 10           | 7            | 10           |
| 400              | 8.25           | 10           | 10           | 3            | 10           |

### Task Performance(Hitting target with bow) vs. Latency  
| **Latency (ms)** | **Avg. Score** | **Tester 1** | **Tester 2** | **Tester 3** | **Tester 4** |
| ---------------- | -------------- | ------------ | ------------ | ------------ | ------------ |
| 0                | 10             | 10           | 10           | 10           | 10           |
| 50               | 9.75           | 10           | 10           | 9            | 9            |
| 100              | 7.5            | 8            | 8            | 6            | 8            |
| 150              | 5.5            | 6            | 5            | 4            | 7            |
| 200              | 4.5            | 4            | 4            | 4            | 6            |
| 300              | 3.25           | 2            | 3            | 4            | 4            |
| 400              | 2.0            | 2            | 2            | 2            | 2            |

### Overall Usability vs. Latency  
| **Latency (ms)** | **Avg. Score** | **Tester 1** | **Tester 2** | **Tester 3** | **Tester 4** |
| ---------------- | -------------- | ------------ | ------------ | ------------ | ------------ |
| 0                | 10             | 10           | 10           | 10           | 10           |
| 50               | 9.25           | 10           | 10           | 7            | 10           |
| 100              | 8.75           | 9            | 9            | 7            | 10           |
| 150              | 7.75           | 8            | 7            | 4            | 8            |
| 200              | 6.0            | 6            | 6            | 4            | 6            |
| 300              | 3.5            | 4            | 4            | 2            | 4            |
| 400              | 2.0            | 2            | 2            | 2            | 2            |

See the combined graphed out data below.  
![](/Deliverables-P56/Degradation/output/Experience%20data/VR/user-experience.png)

### Bitrate
Also users 3 and 4 have been tested on bitrate, this is harder to document or show since the low bitrate can happen at different times, but there are some boundaries that were found:
**Artifacts** started appearing around 3800 KB/s.  
**The usability limit** was found to be around 2600 KB/s.  
**Crash limit** the simulation crashed at 1300 KB/s.  
Note that values can be different for different protocols, settings or hardware used.

### ALVR logging outcome
Taking a look at the [ALVR streaming data](/Deliverables-P56/Degradation/output/ALVR%20data/html/) from the test sessions of users 3 and 4.  
There seems to be a correlation between high latency and low bitrate, with a simple explanation being the fact that with more latency frames are send later meaning it might cost less bitrate to actually send these frames, because of how ALVR streams the scenes. This is just an educated guess, but might give an idea on how it could work.  

FPS does not seem to be impacted, but it is also the fact that the option "adapt to framerate" was turned on, which will change the bitrate output based on the framerate to keep it at the desired level.

---

## Analysis Summary  
### Latency
- **Motion Sickness**: Stable for most users up to **300ms**; Tester 3 experienced discomfort starting at **100ms**.  
- **Task Performance**: Noticeable degradation begins at **100ms latency**, with near failure beyond **200ms latency**.  
- **Usability**: Decreased usability occurs beyond **150ms**, becoming unusable at **300ms latency**.  
### Bitrate
- **Artifacts**: Starting around **3800 KB/s**.  
- **Usability limit**: Starting around **2600 KB/s**.  
- **Crash limit**: Starting around **1300 KB/s**.  

---

### Part 2: Haptic Feedback Delay Testing  
### Setup
See the json and html files [here](/Deliverables-P56/Degradation/)
Users 1-4 where tested without using haptics.
The setup consisted of:  
- ALVR (VR streaming)
  - wired(TCP) connection
  - ALVR streaming port latency
- ALVR settings (All the settings that mostly matter, or have been changed):
  - Resolution: 4288
  - Preferred framerate: 90Hz
  - Encoder preset: Speed
  - Bitrate: adaptive no limit (around 300-600 mbps)
  - Adept to framerate: True
  - Preferred codec: h264
- The Unity world provided from this project
- Clumsy (Network degradation)
- Ultrasonic array (Haptic)
- Laptop specs:
  - CPU: i7 12700h
  - GPU: RTX A1000
  - RAM: 32GB 4800MHZ 

### Results  

See the results from the concluded tests in the graph below:  
![](/Deliverables-P56/Degradation/output/Experience%20data/Haptic/user-experience.png)

---

## Analysis Summary  
### Latency
- In the small test sample it seems like a latency of below **400 ms** is viable for the simplistic application in the Unity project.  
- If an actual big terrain were to be applied it will most definitely will be lower.

---

## Part 3 combined
### Setup
See the json and html files [here](/Deliverables-P56/Degradation/)
Users 1-4 where tested without using haptics.
The setup consisted of:  
- ALVR (VR streaming)
  - wired(TCP) connection
  - ALVR streaming port latency
- ALVR settings (All the settings that mostly matter, or have been changed):
  - Resolution: 4288
  - Preferred framerate: 90Hz
  - Encoder preset: Speed
  - Bitrate: adaptive no limit (around 300-600 mbps)
  - Adept to framerate: True
  - Preferred codec: h264
- The Unity world provided from this project
- Clumsy (Network degradation)
- Ultrasonic array (Haptic)
- Laptop specs:
  - CPU: i7 12700h
  - GPU: RTX A1000
  - RAM: 32GB 4800MHZ 

### Results
From the graphs below it can clearly be seen that the latency impact from the VR part impacts the experience with the haptic device, the red dots have the same haptic latency as the blue ones but also include some kind of vr latency shown by the tag.
#### User 5
![](/Deliverables-P56/Degradation/output/Experience%20data/Combined/user5.png)
#### User 6
![](/Deliverables-P56/Degradation/output/Experience%20data/Combined/user6.png)
#### User 7
![](/Deliverables-P56/Degradation/output/Experience%20data/Combined/user7.png)

---

## Analysis Summary  
### Latency
- From the test it can be concluded that vr latency has noticeable impact on the haptic feedback responsiveness and accuracy, but because of the small sample size we cannot tell how much it impacts the haptic feedback.
- During testing it was also concluded that the ultrasonic device cannot really be used when using wireless headset or a microphone, as it creates a lot of noise and makes the user unhearable.
---

## Conclusion  
1. **VR Streaming**:  
   - Optimal performance: Below **125ms latency**.  
   - Usability degrades: Beyond **150ms latency**.  
   - Bitrate: Above **4000 KB/s** to prevent artifacts, but it also depends on the situation.
2. **Motion Sickness**:  
   - Tolerable latency: Up to **300ms** (individual sensitivity varies).  
3. **Haptic Feedback**:  
   - Accuracy results: Mostly reliable up to **300ms latency**.  
   - Responsiveness results: Mostly reliable up to **300ms latency**. 
   - With regards to communication in the VR world using the ultrasonic array, it cannot be advised to use it, as users will be difficult to understand.

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
