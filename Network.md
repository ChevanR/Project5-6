# VR in a networked environment

## Problem
For the project it is needed to simulate a networked environment were the silumation runs on a remote device and stream to the VR headset. Such that network degredation can be tested in the environment.

## Solution
- Use ALVR for VR game streaming
- Use Clumsy for Network latency introduction

## Pre-research
At first there were some known applications that could maybe help:
- Moonlight (streaming)
- Parsec (streaming)
- The streaming software of the VR headset (Meta link, vive buissiness streaming)

There was also the choice between a streamer in Unity/Unreal or a 3rd party application for streaming, the networked envourment part came at a later decision point.

### Comparisons table
| Feature               | NVIDIA CloudXR                     | ALVR                                    | Moonlight/Parsec                     |
|-----------------------|-------------------------------------|-----------------------------------------|-------------------------------|
| **Cost**              | Paid*                              | Free & Open-source                      | Free                          |
| **Purpose**           | Professional VR/AR cloud streaming | PC VR wireless streaming to headsets    | General game streaming (non-VR focus) |
| **Supported Platforms** | Cloud & PC                        | PC (Windows, Linux)                     | PC (Windows, Linux, macOS)    |
| **Wireless Streaming** | Yes (optimized for cloud-based VR) | Yes                                     | Yes (but focused on general gaming) |
| **VR Support**         | Fully optimized for VR & AR        | Designed specifically for VR streaming  | Not designed for VR           |
| **Additional Advantage** | Clearly supports for cloud       | Supports PhoneVR, great for testing     | Ease of setup for streaming   |

To get acces to NVIDIA CloudXR, you need to join as a developer and accept to the terms and conditions, meaning we cannot distribute the demo would make, even if we were to be allowed to join as developer.
As stated in section 5e of the [nvidia developer terms](https://developer.nvidia.com/legal/terms)

Moonlight and Parsec were bundled together as they are quite similair in regards to this research.
The problem with these applications lies in the fact that they do not natively support VR streaming.

The desicion as to why the specific streaming software per VR headset was left out, is the fact that a specific VR headset was not yet aquired and a simulation with different VR headsets was a requirement with the MoSCoW term 'should' in the product backlog, which could make development easier in the later parts of the project.

### Conclusion
NVIDIA CloudXR was not chosen as everyone part of the project would need to have a developer account.

Moonlight or Parsec were not chosen as they did not have native support for VR streaming.

Specific VR headset streaming software were not chosen as it looked like they could make development in future parts of the project harder.

ALVR was chosen since it had our requirements of basic VR streaming, but in addition to that it is:
- Open source
  - Great if changes need to be made for our needs
- Free
  - No additional costs
- Wireless/Cable connection
  - The more kind of connections can be used, the better the final result can be
- Multi VR support, and PhoneVR
  - Can reduce development time in the project, by not needed multi software or the actual VR headset during development at home

- The experience for the end users with using different VR headsets
- Development/testing time for compatibilty with different VR headsets

##Research

## Sources
https://developer.nvidia.com/legal/terms
https://moonlight-stream.org/
https://github.com/alvr-org/ALVR
