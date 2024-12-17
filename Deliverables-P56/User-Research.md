# User Research  
This document contains information about the user tests conducted for the **VR and Haptic** parts of the project. The aim of the research is to gather user feedback, assess usability, and measure system performance under real-world conditions.

---

## 1. Pre-Research  

### Goals  
Clearly define the goals of the user research:  
- Assess the usability of the VR system under normal and degraded network conditions.  
- Evaluate the accuracy and user experience of the haptic feedback system.  
- Identify areas for improvement based on user feedback and performance results.

### Research Questions  
1. How usable and immersive is the VR system for users under simulated network conditions?  
2. How effective is the haptic feedback in enhancing user experience (e.g., tactile responses to terrain)?  
3. What are the users’ comfort levels, usability ratings, and performance scores for the integrated VR and haptic systems?  

---

## 2. User Testing  

### 2.1 Setup  

#### Testing Environment  
- **Location**: Specify where the test is conducted (e.g., lab, controlled environment).  
- **Equipment**:  
   - VR Headset: Oculus Quest 3  
   - Haptic Device: Ultraleap Haptic Feedback Kit  
   - Software: Unity, ALVR, Clumsy (network simulation tool)  
   - Performance Logging: JSON file outputs, feedback forms  

#### User Selection  
- **Participants**: Define number of participants, demographics (age, experience level, VR familiarity), and any inclusion/exclusion criteria.  
- **Participant Categories**:  
   - Experienced VR Users  
   - Inexperienced Users  
   - Users sensitive to haptic feedback (optional)  

---

### 2.2 Testing Procedure  

#### VR Testing  

| **Task**                      | **Description**                                   | **Success Metrics**                  | **Latency Simulations**               |  
| ----------------------------- | ----------------------------------------------- | ------------------------------------ | ------------------------------------ |  
| Basic Navigation              | Move around a VR environment.                   | User can navigate fluidly.           | 0ms, 50ms, 100ms, 200ms, 300ms       |  
| Object Interaction            | Pick up and manipulate virtual objects.         | Object movement and feedback sync.   | 0ms, 50ms, 100ms, 200ms, 300ms       |  
| Motion Sickness Assessment    | Evaluate user comfort level.                    | Motion sickness score (1–10).        | All latency levels                   |  

#### Haptic Testing  

| **Task**                      | **Description**                                   | **Success Metrics**                  | **Latency Simulations**               |  
| ----------------------------- | ----------------------------------------------- | ------------------------------------ | ------------------------------------ |  
| Tactile Response to Terrain   | Users feel terrain height variations.           | Accurate and responsive feedback.    | 0ms, 50ms, 100ms, 150ms, 200ms       |  
| Gesture-based Controls        | Perform gestures to control VR elements.        | Gestures trigger correct actions.    | 0ms, 50ms, 100ms, 150ms              |  
| Feedback Usability            | Rate overall usability of haptic feedback.      | Usability score (1–10).              | All latency levels                   |  

---

## 3. Data Collection  

### Metrics Logged  
1. **Quantitative Data**:  
   - **Performance Metrics**: Frame rate (FPS), input delay, latency levels  
   - **Motion Sickness**: User ratings on a scale of 1–10  
   - **Usability Scores**: User ratings for each task (1–10)  
2. **Qualitative Data**:  
   - User comments and observations during the tests  
   - Open-ended feedback about usability, immersion, and system shortcomings  

---

## 4. Results  

### 4.1 VR Testing Results  

| **Task**                      | **Latency (ms)** | **Success Rate (%)** | **Motion Sickness Avg (1-10)** | **User Comments**             |  
| ----------------------------- | ---------------- | ---------------------| ------------------------------ | ----------------------------- |  
| Basic Navigation              | 50               | 100%                 | 1.5                           | "Smooth navigation."          |  
| Object Interaction            | 100              | 85%                  | 3.0                           | "Slight delay, still usable." |  
| ...                           | ...              | ...                  | ...                            | ...                           |  

### 4.2 Haptic Testing Results  

| **Task**                      | **Latency (ms)** | **Accuracy (%)**     | **Usability Avg (1-10)**       | **User Comments**             |  
| ----------------------------- | ---------------- | ---------------------| ------------------------------ | ----------------------------- |  
| Tactile Response to Terrain   | 50               | 95%                  | 9.0                           | "Feels very realistic."       |  
| Gesture-based Controls        | 100              | 80%                  | 7.5                           | "Gestures worked with delay." |  
| ...                           | ...              | ...                  | ...                            | ...                           |  

---

## 5. Analysis  

- Summarize the results, highlighting:  
   - The latency thresholds where usability starts to degrade.  
   - Key trends in user feedback and performance.  
   - Performance differences between VR tasks and haptic tasks.  

**Example Summary Points**:  
- VR usability drops significantly above **150ms latency**, particularly for object interactions.  
- Haptic feedback remains usable up to **100ms latency**, but accuracy declines beyond **150ms**.  
- Motion sickness levels remain low for most participants until latency exceeds **300ms**.  

---

## 6. User Feedback  

### Key Takeaways  
- Strengths:  
   - "The VR environment is smooth and immersive under ideal conditions."  
   - "Haptic feedback enhances immersion, especially for terrain changes."  
- Weaknesses:  
   - "Latency makes gestures frustrating when delayed."  
   - "Haptic feedback accuracy declines noticeably under high latency."  

### Suggestions for Improvement  
1. Optimize synchronization between VR visuals and haptic feedback.  
2. Improve latency handling to ensure usability under degraded network conditions.  
3. Add further gesture-based features for smoother user control.  

---

## 7. Conclusion  

This user research demonstrated:  
1. Latency thresholds where VR and haptic usability degrade.  
2. Positive feedback on the realism and immersion of the systems.  
3. Areas for optimization, particularly for network latency and feedback accuracy.  

Future testing will incorporate larger participant groups and refined latency-handling mechanisms to further validate system improvements.

---

## Appendix  

1. **User Feedback Forms**: Include templates used to gather feedback.  
2. **Performance Logs**: JSON files containing frame rates, input delays, and latency metrics.  
3. **Test Scenarios**: Detailed descriptions of VR and haptic tasks for reproducibility.  
