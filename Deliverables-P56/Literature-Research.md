# Literature review: Haptic interfaces in an extended reality (XR) environment

## 1. Introduction and problem statement
Extended reality (XR)—an umbrella term that covers virtual reality (VR), augmented reality (AR), and mixed reality (MR)—is increasingly used in applications ranging from industrial training to medical simulations. In our project, we focus on developing a networked XR environment that integrates cloud-based VR streaming with precise, real-time haptic feedback. The primary application is interactive training simulations (e.g., industrial safety drills, medical procedure rehearsals) where timely and accurate feedback is critical for effective learning and performance improvement.

This research is being investigated in collaboration with our stakeholders at R&D Royal Dutch Army and TNO. They are interested in determining whether integrating ultrasonic haptic feedback with cloud-based VR streaming is usable in demanding training scenarios and if further investment in this technology is justified. The challenge is to deliver synchronized tactile sensations (via ultrasonic arrays) together with high-quality visual and auditory cues, even under variable network conditions. Any misalignment between the haptic feedback and the visual environment can reduce immersion, compromise training outcomes, and pose safety risks. Broader consequences include the potential to scale remote training solutions and reduce dependency on expensive local hardware.

---

## 2. Research questions
To guide this review, we formulated the following questions:
1. **How can ultrasonic array technology enhance haptic feedback in XR environments, and what insights can be drawn from related haptic systems in similar scenarios?**
2. **What are the key technical requirements and challenges for streaming VR simulations over cloud networks to ensure low latency and high-quality delivery in training and simulation environments?**
3. **How do existing adaptive streaming and haptic synchronization techniques inform the integration of these technologies in real-world XR applications?**

---

## 3. Methodology

### 3.1 identifying subproblems
- **Ultrasonic arrays for haptic feedback:**  
  We reviewed the literature on ultrasonic haptic feedback as well as broader haptic systems used in various applications, including wearable and mechanical devices. Although specific studies on ultrasonic arrays in XR are limited, research on conventional haptic feedback (e.g., vibration motors, force-feedback controllers) provides insights into latency tolerance and synchronization challenges (Freeman et al., 2021). Additionally, studies such as Carter et al. (2019) offer a basis for understanding the potential of ultrasonic mid-air haptics for touchless interfaces.

- **Cloud-based VR streaming:**  
  Our review covers research on the network requirements for real-time VR applications. Key performance factors include acceptable latency thresholds, bandwidth demands, and the effectiveness of adaptive streaming algorithms (Chen et al., 2020; Shi et al., 2022; Zhang & Gupta, 2021). These findings are particularly relevant for our project, where VR streaming must remain smooth and responsive in training environments despite variable network conditions.

### 3.2 Defining search terms and strings
Key search terms included:
- “ultrasonic arrays haptic feedback,” “ultrasonic tactile systems in XR”
- “VR cloud streaming latency,” “adaptive streaming algorithms for VR”
- “haptic synchronization in XR,” “haptic feedback in training simulations”

Combined search strings used were:
- “integration of ultrasonic arrays and extended reality AND latency”
- “cloud-based VR streaming AND haptic feedback AND training simulations”
These were applied across databases such as IEEE Xplore, ACM Digital Library, and Google Scholar, and supplemented by whitepapers from industry leaders like Ultraleap.

---

## 4. Findings

### 4.1 Ultrasonic haptic feedback
Recent studies indicate that ultrasonic arrays can generate precise, contactless tactile sensations by modulating the amplitude and intensity of ultrasonic waves (Carter et al., 2019). Broader haptic research shows that non-contact systems offer benefits in terms of hygiene and comfort compared to conventional mechanical devices (Freeman et al., 2021). However, integrating ultrasonic haptics in an XR setting introduces specific challenges:
- **Latency tolerance:** Ensuring that tactile feedback is synchronized with visual and auditory cues is critical; delays or mismatches can break immersion and reduce training effectiveness (Kotranza et al., 2023).
- **User calibration:** Variability in individual perception of haptic stimuli necessitates robust calibration methods to ensure consistency.
- **Hardware integration:** Current ultrasonic devices are often bulky or expensive, which may limit their deployment in scalable, cost-effective training systems.

### 4.2 Cloud-based VR streaming
The literature on VR streaming highlights several performance requirements:
- **Latency:** Studies have shown that end-to-end latencies above 20–50 ms can impair user experience, with specific thresholds varying based on the application (Chen et al., 2020).
- **Bandwidth:** High-resolution VR streaming typically demands 50–100 Mbps, with even higher bandwidth needed for ultra-high-definition content (Shi et al., 2022).
- **Adaptive streaming algorithms:** Real-time techniques that adjust resolution and frame rate help mitigate the adverse effects of fluctuating network conditions (Zhang & Gupta, 2021).

Although these studies offer concrete performance benchmarks, few have explored the combined impact of network-induced latency on both VR and haptic feedback. This gap is particularly significant for training simulations where any delay in haptic feedback could diminish overall effectiveness.

---

## 5. Discussion
The reviewed literature confirms that both ultrasonic haptic feedback and cloud-based VR streaming have the potential to significantly enhance XR experiences, particularly in training simulations. However, each technology faces its own set of challenges. Ultrasonic haptic systems must overcome issues of synchronization, calibration, and hardware limitations, while VR streaming requires robust adaptive techniques to maintain low latency and high visual quality. The integration of these systems introduces additional complexity, as even minor desynchronizations can lead to a reduction in immersion and training efficacy.

**Implications for our project and stakeholders (R&D Royal Dutch Army and TNO):**
- **Synchronization:** The system must ensure precise alignment between haptic feedback and VR visuals to maintain immersion and training effectiveness.
- **Application context:** As the primary use-case is training simulations for critical tasks, technical shortcomings could lead to reduced learning outcomes or even safety risks during simulated procedures.
- **Broader consequences:** Success in this integrated approach could pave the way for more accessible, remote training solutions, reducing the need for expensive on-site hardware while still delivering high-fidelity experiences. This is a key concern for our stakeholders, who are evaluating whether further investment in this technology is justified.

---

## 6. Conclusion
This literature review reveals two core opportunities:
1. **Ultrasonic haptic feedback:**  
   - Offers the potential for precise, contactless tactile sensations,  
   - but requires further research on latency optimization, user calibration, and cost-effective hardware integration.
2. **Cloud-based VR streaming:**  
   - Enables scalable, high-fidelity VR experiences through adaptive streaming,  
   - yet its interaction with haptic feedback systems under real-world network conditions is underexplored.

**Combined challenge:** Integrating these technologies presents complex synchronization issues that are crucial for maintaining effective and immersive training simulations. Targeted experimental studies are needed to establish performance thresholds and develop more robust XR systems that meet the requirements of our stakeholders.

---

## 7. Future work
1. **Experimental prototyping:**  
   - Develop a proof-of-concept XR application that integrates ultrasonic arrays with cloud-based VR streaming, measuring real-world latency and synchronization effects (Chen et al., 2020).

2. **Adaptive synchronization techniques:**  
   - Investigate predictive algorithms and edge computing solutions to pre-render haptic cues and minimize round-trip times (Zhang & Gupta, 2021).

3. **Broader haptic integration:**  
   - Compare ultrasonic feedback with other haptic modalities under similar network constraints to establish benchmarks that can guide future XR development (Freeman et al., 2021).

---

## References
- Carter, T., Seah, S. A., & Subramanian, S. (2019). *Ultrasonic mid-air haptics for touchless interfaces.* Proceedings of the ACM CHI Conference on Human Factors in Computing Systems, 1–10.  
- Chen, L., Park, S., & Kim, J. (2020). *Predictive rendering in cloud VR environments.* IEEE Transactions on Visualization and Computer Graphics, 26(5), 2350–2360.  
- Freeman, I., Kelly, S., & Patel, R. (2021). *Evaluating user acceptance of haptic feedback in VR training.* International Journal of Human–Computer Interaction, 37(4), 303–315.  
- Kotranza, A., Snyder, J., & Kim, Y. (2023). *Ultrasonic tactile feedback for immersive medical simulations.* Journal of Virtual Reality and Healthcare, 2(2), 44–58.  
- Mandal, S., Roy, T., & Xu, W. (2021). *Extended reality: Challenges and opportunities in modern applications.* ACM Computing Surveys, 53(6), 121–144.  
- Shi, W., Cao, J., & Zhang, L. (2022). *Edge computing for low-latency VR streaming.* IEEE Internet of Things Journal, 9(3), 1765–1776.  
- Ultraleap. (n.d.). *Haptics development kit.* Retrieved from [https://leap2.ultraleap.com/products/haptics-development-kit](https://leap2.ultraleap.com/products/haptics-development-kit)  
- Zhang, Q., & Gupta, A. (2021). *Adaptive streaming algorithms for immersive VR.* Proceedings of the IEEE Conference on Multimedia & Expo, 99–106.
